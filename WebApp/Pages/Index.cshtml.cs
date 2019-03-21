using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Pages
{
    public class IndexModel : PageModel
    {
        
        readonly Library _lib;

        public List<Book> Books { set; get; }

        public IndexModel(Library lib)
        {
            _lib = lib;            
        }


        public void OnGet()
        {
            Books = new List<Book>(_lib.Get());
        }
    }
}
