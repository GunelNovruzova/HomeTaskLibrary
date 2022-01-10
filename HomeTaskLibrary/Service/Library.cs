using System;
using System.Collections.Generic;
using System.Text;

namespace HomeTaskLibrary.Service
{
    class Library
    {
        public List<Book> Books = new List<Book>();

       
       
        public void AddBook(string name,string authorname,int pagecount)
        {
            Books.Add(new Book(name, authorname, pagecount));
        }
        public void GetBooks()
        {
            if (Books.Count > 0)
            {
                foreach (Book item in Books)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("Once kitab daxil edin");
            }
        }
        public List<Book> FindAllBooksbyName(string name)
        {
            return Books.FindAll(b => b.Name.Contains(name));
        }
        public void RemoveAllBooksbyName(string name)
        {
            Books.RemoveAll(b => b.Name.Contains(name));
        }
        public List<Book> SearchBooks(string value)
        {
            return Books.FindAll(b => b.Name.Contains(value) || b.Authorname.Contains(value) || value.Equals(b.Pagecount.ToString()));
        }
        public List<Book> FindAllbookbyPageCountRange(int a, int c)
        {
            return Books.FindAll(b => b.Pagecount > a || b.Pagecount < c);
        }
        public void RemovebyNo(string name)
        {
            Books.Remove(Books.Find(b => b.Code.Contains(name)));
        }
    }

}
