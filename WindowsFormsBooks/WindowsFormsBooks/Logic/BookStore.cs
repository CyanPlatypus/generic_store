using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Xml.Serialization;

namespace WindowsFormsBooks
{
    [Serializable]
    [XmlType("bookstore")]
    public class BookStore<T>
    {
        [XmlElement("book")]
        public BindingList<T> StoreBooksBindingList { get; set; }

        public BookStore() 
        {
            StoreBooksBindingList = new BindingList<T>();
        }

        public void AddBook(T book)
        {
            StoreBooksBindingList.Add(book);
        }

        public void RemoveBookAt(int index)
        {
            if (InRange(index))
                StoreBooksBindingList.RemoveAt(index);
        }

        public T ReturnBookAt(int index) 
        {
            if (InRange(index))
                return StoreBooksBindingList[index];
            return default(T);
        }

        private bool InRange(int index) 
        {
            return (index >= 0) && (index < StoreBooksBindingList.Count);
        }


    }
}
