using System;

namespace BookLibrary
{
    public class Book
    {
        public Book(int id, string authors, string title)
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
