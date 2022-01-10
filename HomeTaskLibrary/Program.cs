using HomeTaskLibrary.Service;
using System;
using System.Collections.Generic;

namespace HomeTaskLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();
            do
            {
                Console.WriteLine("1. Kitab daxil et:");
                Console.WriteLine("2 .Kitablarin siyahisi");
                Console.WriteLine("3. Kitabi ada gore tap");
                Console.WriteLine("4. Kitabi ada gore sil");
                Console.WriteLine("5. Kitabi axtar");
                Console.WriteLine("6. Sehife araligina gore kitabi axtar");
                Console.WriteLine("7. Kitabi nomreye gore sil");

                string selectedopr = Console.ReadLine();
                switch (selectedopr)
                {
                    case "1":
                        Console.Clear();
                        Addbook(ref library);
                        break;
                    case "2":
                        Console.Clear();
                        GetBooks(ref library);
                        break;
                    case "3":
                        Console.Clear();
                        FindAllBooksbyName(ref library);
                        break;
                    case "4":
                        Console.Clear();
                        RemoveAllBookbyName(ref library);
                       
                        break;
                    case "5":
                        Console.Clear();
                        SearchBooks(ref library);
                       
                        break;
                    case "6":
                        Console.Clear();
                        FindAllbookbyPageCountRange(ref library);
                        break;
                    case "7":
                        Console.Clear();
                        RemovebyNo(ref library);
                        break;
                    default:
                        Console.WriteLine("Duzgun daxil et");
                        break;
                }
            } while (true);
        }
        static void Addbook(ref Library library)
        {
            Console.WriteLine("Kitab adini daxil et");
            string name = Console.ReadLine();
            Console.WriteLine("Muellifi daxil et");
            string authorname = Console.ReadLine();
            Console.WriteLine("Sehife sayini daxil et");
            string pagecount = Console.ReadLine();
            int Pagecount;
            while (!int.TryParse(pagecount, out Pagecount))
            {
                Console.WriteLine("Sehife sayini duzgun daxil edin");
                pagecount = Console.ReadLine();
            }
            Console.WriteLine("Kitab ugurla elave olundu");

            library.Books.Add(new Book(name, authorname, Pagecount));
        }
        static void GetBooks(ref Library library)
        {
            Console.WriteLine("Kitablarin siyahisi");
            if (library.Books.Count > 0)
            {
                foreach (Book item in library.Books)
                {
                    Console.WriteLine(item);
                }
            }
        }
        static void FindAllBooksbyName(ref Library library)
        {
            if (library.Books.Count<0)
            {
                Console.WriteLine("Once kitab daxil edin");
            }
            Console.WriteLine("Axtaris edeceyiniz kitabin adini daxil edin");
        CheckN:
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))

            {
                Console.WriteLine("Duzgun daxil edin");
                goto CheckN;
            }
           
            List<Book> book = new List<Book> (library.Books.FindAll(b => b.Name.Contains(name)));
            foreach (Book item in book)
            {
                Console.WriteLine(item);
            }
           
            library.FindAllBooksbyName(name);
        }
        static void RemoveAllBookbyName(ref Library library)
        {
            GetBooks(ref library);
            Console.WriteLine("Sileceyiniz kitabin adini daxil edin");
            string name = Console.ReadLine();
            foreach (Book item in library.Books)
            {
                if (!library.Books.Exists(b => b.Name.ToUpper().Contains(name.ToUpper())))
                {
                    Console.WriteLine("Duzgun daxil edin");
                  
                    return;
                }
            }
            int count = 0;
            foreach (Book item in library.Books)
            {
                if (item.Name.Contains(name))
                {
                    count++;
                }
            }
            Console.WriteLine("Kitab silindi");
             library.RemoveAllBooksbyName(name);
        }
        static void SearchBooks(ref Library library)
        {
            if (library.Books.Count<0)
            {
                Console.WriteLine("Once kitab daxil edin");
            }
            Console.WriteLine("Axtaris etmek istediyiniz kitabin deyerini daxil edin");
        checkV:
            string value = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(value))
            {
                Console.WriteLine("Duzgun daxil edin");
                goto checkV;

            }
            List<Book> book1 = new List<Book> (library.Books.FindAll(b => b.Name.Contains(value) || b.Authorname.Contains(value) || b.Pagecount.ToString().Contains(value)));
            foreach (Book item in book1)
            {
                Console.WriteLine(item);
            }
            
            library.SearchBooks(value);
        }
        static void RemovebyNo(ref Library library)
        {
            GetBooks(ref library);
            Console.WriteLine("Sileceyiniz kitabin nomresini daxil edin");
            string no = Console.ReadLine();
            foreach (Book item in library.Books)
            {
                if (item.Code.ToUpper() == no.ToUpper())
                {
                    library.Books.Remove(item);
                    Console.WriteLine("Kitab silindi");
                    return;
                }
                else
                {
                    Console.WriteLine("Bu nomrede kitab movcud deyil");
                    return;
                }

            }
            library.RemovebyNo(no);
        }
        static void FindAllbookbyPageCountRange(ref Library library)
        {
            string startP = string.Empty;
            Console.WriteLine("Minimum sehife sayi");
        CheckMin:
            startP = Console.ReadLine();
            int min;
            if (!int.TryParse(startP, out min) || min < 0)
            {
                Console.WriteLine("Duzgun daxil edin");
                goto CheckMin;
            }
            string endP = string.Empty;
            Console.WriteLine("Maximum sehife sayi");
        checkMax:
            endP = Console.ReadLine();
            int max;
            if (!int.TryParse(endP, out max) || max < 0)
            {
                Console.WriteLine("Duzgun daxil edin");
                goto checkMax;
            }
           
            List<Book> book = (library.Books.FindAll(b => b.Pagecount >= min && b.Pagecount <= max));
            foreach (Book item in book)
            {
                Console.WriteLine(item);
            }
            library.FindAllbookbyPageCountRange(min, max);
        }
    }
} 
