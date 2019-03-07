using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BookLibrary
{
    public class Library
    {
        public List<Book> Books { private set; get; }
        public string PathToFile { set; get; }

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

        public void AddBook(string title, string authors)
        {
            int id = Books.Max(b => b.Id) + 1;
            Books.Add(new Book(id, title, authors));

        }

        public void RemoveBookAt(int idx)
        {
            Books.RemoveAt(idx);
        }
    }
}
