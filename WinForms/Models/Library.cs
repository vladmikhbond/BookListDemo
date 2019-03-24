using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WinForms.Models
{
    public class Library: ILibrary
    {
        public List<Book> Books { protected set; get; }

        string _pathToFile { set; get; }

        public Library(string pathToFile)
        {
            _pathToFile = pathToFile;
            if (File.Exists(_pathToFile))
            {
                LoadBooks();
            }
            else
            {
                Books = new List<Book>();
            }
        }

        void LoadBooks()
        {
            Books = new List<Book>();
            using (TextReader reader = new StreamReader(File.OpenRead(_pathToFile)))
            {
                string s = null;
                while ((s = reader.ReadLine()) != null)
                {                   
                    var title = reader.ReadLine();
                    var authors = reader.ReadLine();
                    Books.Add(new Book { Id = s, Title = title, Authors = authors });
                }
            }
        }

        public void SaveChanges()
        {
            using (TextWriter writer = new StreamWriter(_pathToFile))
            {
                foreach (Book book in Books)
                {
                    writer.WriteLine(book.Id);
                    writer.WriteLine(book.Title);
                    writer.WriteLine(book.Authors);
                }
            }
        }

        public Book AddBook(Book book)
        {

            book.Id = Books.Count() == 0 ? "1" : (Books.Max(b => Convert.ToInt32(b.Id)) + 1).ToString();
            Books.Add(book);
            return book;
        }

        public void RemoveBook(string id)
        {
            int idx = Books.TakeWhile(b => b.Id != id).Count();
            Books.RemoveAt(idx);
        }
    }
}
