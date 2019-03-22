using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Pages
{

    public class DeleteModel : PageModel
    {
        readonly Library _db;

        public DeleteModel(Library lib)
        {
            _db = lib;
        }

        [BindProperty(SupportsGet = true)]
        public Book Book { set; get; }

        public void OnGet()
        {
            Book = _db.Get().SingleOrDefault(b => b.Id == Book.Id);
        }

        public IActionResult OnPostAsync()
        {
            Book book = _db.Get().SingleOrDefault(b => b.Id == Book.Id);
            if (book != null)
            {
                _db.Remove(book.Id);
            }
            return RedirectToPage("/Index");
        }
    }
}