using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Models;

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
