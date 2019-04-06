using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;

namespace WinForms.Models
{
    public class LibraryM: ILibrary
    {
        public List<Book> Books {
            get {
                return _books.Find(book => true).ToList();
            }
        }

        private readonly IMongoCollection<Book> _books;

        string _pathToFile { set; get; }

        public LibraryM(string conStr)
        {            
            var client = new MongoClient(conStr);
            var colNames = client.ListDatabaseNames().ToList();
      
            

            var database = client.GetDatabase("LibraryDb");
            _books = database.GetCollection<Book>("Books");
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public Book AddBook(Book book)
        {
            _books.InsertOne(book);
            return book;
        }

        public void RemoveBook(string id)
        {
            _books.DeleteOne(book => book.Id == id);
        }
    }
}
