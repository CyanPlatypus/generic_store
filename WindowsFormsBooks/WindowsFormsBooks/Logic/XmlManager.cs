using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Xml.Xsl;
using System.Xml.XPath;
using System.Xml;

namespace WindowsFormsBooks
{
    public class XmlManager<T>
    {
        public bool TrySerializeToXML(string filepath, T whatToSerialize, out string message)
        {
            message = string.Empty; 

            //serialize to xml
            using (StreamWriter fs = new StreamWriter(new FileStream(filepath, FileMode.Create), Encoding.UTF8))
            {
                try
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    XmlSerializerNamespaces nS = new XmlSerializerNamespaces();
                    nS.Add(string.Empty, string.Empty);

                    serializer.Serialize(fs, whatToSerialize, nS);
                    return true;
                }
                catch (Exception e)
                {
                    message = "Can't serialize.";
                    return false; 
                }
            }
        }

        public bool TryDeserializeFromXML(string filepath, ref T whereToDeserialize, out string message) 
        {
            message = string.Empty;

            //deserialize from xml
            if (FileExists(filepath))
                using (StreamReader fs = new StreamReader(new FileStream(filepath, FileMode.Open), Encoding.UTF8))
                {
                    try
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(T));

                        whereToDeserialize = (T)serializer.Deserialize(fs);
                        return true;
                    }
                    catch (Exception e)
                    { 
                        message = "Can't deserialize.";
                        return false; 
                    }
                }
            message = "File doesn't exist.";
            return false;
        }

        public bool TryConvertFromXMLAndXSLToHTML(string htmlPath, string xmlPath, string xslPath, T whatToserialize, out string message)
        {
            message = string.Empty;

            if (TrySerializeToXML(xmlPath, whatToserialize, out message))
            {
                try
                {
                    var myXslTrans = new XslCompiledTransform();
                    myXslTrans.Load(xslPath);
                    myXslTrans.Transform(xmlPath, htmlPath);

                    if (FileExists(xmlPath))
                        File.Delete(xmlPath);
                    return true;
                }
                catch (Exception e)
                {
                    message = "Can't transform to html.";
                    return false;
                }
                finally 
                {
                    if (FileExists(xmlPath))
                        File.Delete(xmlPath);
                }
            }
            else
                return false;
        }

        public bool TryConvertFromXMLAndResourcesToHTML(string htmlPath, string xmlPath, string resources, T whatToserialize, out string message) 
        {
            string xslPath = "bookstoreStyle.xsl";
            File.WriteAllText(xslPath, resources);

            message = string.Empty;
            bool result = false;
            if (TryConvertFromXMLAndXSLToHTML(htmlPath, xmlPath, xslPath, whatToserialize, out message))
                result = true;

            if (FileExists(xslPath))
                File.Delete(xslPath);

            return result;
        }

        private bool FileExists(string path) 
        {
            return File.Exists(path);
        }
    }
}
