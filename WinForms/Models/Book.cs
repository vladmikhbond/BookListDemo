using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForms.Models
{
    public class Book
    {
        public Book(int id, string title, string authors)
        {
            Id = id;
            Authors = authors;
            Title = title;
        }

        public int Id { set; get; }
        public string Title { set; get; }
        public string Authors { set; get; }
    }
}
