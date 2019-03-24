using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WinForms.Models
{
    public class Library
    {
        public List<Book> Books { protected set; get; }

        string _pathToFile { set; get; }

        public Library(string pathToFile)
        {
            _pathToFile = pathToFile;
            if (File.Exists(_pathToFile)) {
                LoadBooks();
            } else {
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
                    int id = Convert.ToInt32(s);
                    var title = reader.ReadLine();
                    var authors = reader.ReadLine();
                    Books.Add(new Book(id, title, authors));
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

        public void AddBook(Book book)
        {
            book.Id = Books.Count() == 0 ? 1 : Books.Max(b => b.Id) + 1;
            Books.Add(book);
        }

        public void RemoveBook(int id)
        {
            int idx = Books.TakeWhile(b => b.Id != id).Count();
            Books.RemoveAt(idx);
        }
    }
}
