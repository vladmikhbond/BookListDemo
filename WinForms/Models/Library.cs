using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WinForms.Models
{
    public class Library
    {
        public List<Book> Books { protected set; get; }

        public string PathToFile { set; get; }

        public Library()
        { }

        public Library(string pathToFile)
        {
            PathToFile = pathToFile;
            LoadFromFile();
        }

        public void SaveToFile()
        {
            using (TextWriter writer = new StreamWriter(PathToFile))
            {
                foreach (Book book in Books)
                {
                    writer.WriteLine(book.Id);
                    writer.WriteLine(book.Title);
                    writer.WriteLine(book.Authors);
                }
            }
        }

        public void LoadFromFile()
        {
            Books = new List<Book>();
            using (TextReader reader = new StreamReader(File.OpenRead(PathToFile)))
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

        public void AddBook(Book book)
        {
            book.Id = Books.Count() == 0 ? 1 : Books.Max(b => b.Id) + 1;
            Books.Add(book);
        }

        public void RemoveBookAt(int idx)
        {
            Books.RemoveAt(idx);
        }

        public void RemoveBookById(int id)
        {
            int idx = Books.TakeWhile(b => b.Id != id).Count();
            Books.RemoveAt(idx);
        }
    }
}
