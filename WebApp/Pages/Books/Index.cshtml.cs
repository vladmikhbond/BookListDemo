using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Pages.Books
{
    public class IndexModel : PageModel
    {
        
        readonly Library _db;

        public List<Book> Books { set; get; }

        public IndexModel(Library library)
        {
            _db = library;            
        }


        public void OnGet()
        {
            Books = new List<Book>(_db.Get());
        }
    }
}
