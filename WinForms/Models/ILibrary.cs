using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WinForms.Models
{
    public interface ILibrary
    {
        List<Book> Books { get; }
        Book AddBook(Book book);
        void RemoveBook(string id);
        void SaveChanges();
    }
}
