using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookLibrary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Pages.Pages.Books
{
    public class Index2Model : PageModel
    {
        readonly Library _lib;

        public List<Book> Books { set; get; }

        public Index2Model(Library lib)
        {
            _lib = lib;
            Books = new List<Book>(lib.Books);
        }
        public void OnGet()
        {

        }
    }
}