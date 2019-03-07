using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BookLibrary
{
    public class Library
    {
        public List<Book> Books { set; get; }
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
                    Books.Add(new Book(id, authors, title));
                }
            }
        }
    }
}
