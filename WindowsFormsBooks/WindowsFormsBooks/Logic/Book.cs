using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Text.RegularExpressions;

namespace WindowsFormsBooks
{
    [Serializable]
    [XmlType("title")]
    public class Title 
    {
        [XmlAttribute("lang")]
        public string Lang { get; set; }

        [XmlText]
        public string TitleName { get; set; }

        public Title(string title, string lan) 
        {
            TitleName = title;
            Lang = lan;
        }

        public Title() { }

    }

    [Serializable]
    [XmlType("book")]
    public class Book
    {
        [XmlIgnore] //makes this prorerty not xml serializable
        public string Title 
        { 
            get { return BookTitle.TitleName; }
            private set { BookTitle.TitleName = value; }
        }

        [XmlIgnore] //makes this prorerty not xml serializable
        [Browsable(false)] //makes this propery not represented in DataGridView
        public string Language
        {
            get { return BookTitle.Lang; }
            private set { BookTitle.Lang = value; }
        }

        private string author;

        [XmlIgnore] //makes this prorerty not xml serializable
        public string Author 
        {
            get 
            {
                UpdateAuthor();
                return author;
            }
            set { author = value; }
        }

        [Browsable(false)] //makes this propery not represented in DataGridView
        [XmlElement("title")]
        public Title BookTitle { get; set; }

        [XmlAttribute("category")] // mekes this property look like attribute in xml
        public string Category { get; set; }
        
        [Browsable(false)] //makes this propery not represented in DataGridView
        [XmlElement("year")]
        public int Year { get; set; }

        [Browsable(false)] //makes this propery not represented in DataGridView
        [XmlAttribute("cover")] // mekes this property look like attribute in xml
        public string Cover { get; set; }
        
        [XmlElement("price")]
        public double Price { get; set; }

        [Browsable(false)] //makes this propery not represented in DataGridView
        [XmlElement("author")]
        public List<string> Authors { get; set; }

        public Book(string title, string lang, List<string> authors, string category, int year, double price, string cover = null)
        {
            Edit(title, lang, authors, category, year, price, cover);
        }

        public Book() 
        {
            this.Authors = new List<string>();
        }

        private void InitFields(string title, string lang, string category, int year, double price, string cover = null) 
        {
            BookTitle = new Title(title, lang);
            this.Title = title;
            this.Category = category;
            this.Year = year;
            this.Price = price;

            if (cover == string.Empty)
                this.Cover = null;
            else
                this.Cover = cover;
        }

        public void Edit(string title, string lang, List<string> authors, string category, int year, double price, string cover = null) 
        {
            this.Authors = new List<string>();

            foreach (var a in authors)
            {
                if (OkForAuthor(a))
                    this.Authors.Add(a);
            }

            InitFields(title, lang, category, year, price, cover);
        }

        //makes the string of authors in the list
        private void UpdateAuthor() 
        {
            author = string.Empty;

            for (int i = 0; i < Authors.Count; i++ )
            {
                author += Authors[i];
                if ((i + 1) != Authors.Count)
                    author += "; ";
            }
        }

        public static bool OkForAuthor(string str) 
        {
            //no numbers and ;=+()
            Regex regex = new Regex("^([^0-9;=+()]*)$");
            return (regex.IsMatch(str) && (str != string.Empty));
        }

        public static bool OkForCover(string str)
        {
            //only letters
            Regex regex = new Regex("^([a-zA-Zа-яА-Я]*)$");
            return (regex.IsMatch(str) || (str == string.Empty) );
        }

        public static bool OkForCategory(string str)
        {
            //only letters
            Regex regex = new Regex("^([a-zA-Zа-яА-Я]*)$");
            return (regex.IsMatch(str) && (str != string.Empty));
        }

        public static bool OkForLanguage(string str)
        {
            //only letters and -
            Regex regex = new Regex("^([a-zA-Zа-яА-Я-]*)$");
            return (regex.IsMatch(str) && (str != string.Empty));
        }

        public static bool OkForTitle(string str)
        {
            //only letters and spaces
            Regex regex = new Regex("^([a-zA-Zа-яА-Я ]*)$");
            return (regex.IsMatch(str) && (str != string.Empty));
        }

        public static bool OkForPrice(string str)
        {
            double res;
            if (Double.TryParse(str, out res) && (res > 0))
                return true;
            return false;
        }

        public static bool OkForYear(string str)
        {
            int year = DateTime.Now.Year;
            int res;
            if (Int32.TryParse(str, out res) && (res <= year) && (res > 0))
                return true;
            return false;
        }
    }
}
