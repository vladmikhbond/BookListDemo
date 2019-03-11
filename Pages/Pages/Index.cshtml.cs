using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookLibrary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Pages.Pages
{
    public class IndexModel : PageModel
    {
        readonly Library _lib;

        public List<Book> Books { set; get; }

        public IndexModel(Library lib)
        {
            _lib = lib;
            Books = new List<Book>(lib.Books);
        }


        public void OnGet()
        {

        }
    }
}
