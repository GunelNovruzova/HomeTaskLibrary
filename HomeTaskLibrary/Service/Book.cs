using System;
using System.Collections.Generic;
using System.Text;

namespace HomeTaskLibrary.Service
{
    class Book
    {
        private static int count = 0;
        public string Name { get; set; }
        public string Authorname { get; set; }
        public int Pagecount { get; set; }
        public string Code { get; set; }

        public Book(string name,string authorname,int pagecount)
        {
            count++;
            Code += name.ToUpper().Substring(0, 2) + count;
            Name = name;
            Authorname = authorname;
            Pagecount = pagecount;
        }

        public override string ToString()
        {
            return $"Ad: {Name}\nMuellif: {Authorname}\nSehifesayi: {Pagecount}\nID: {Code}";
        }
    }
}
