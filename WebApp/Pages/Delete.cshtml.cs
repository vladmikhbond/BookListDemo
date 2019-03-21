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
        readonly Library _lib;

        public DeleteModel(Library lib)
        {
            _lib = lib;
        }

        [BindProperty(SupportsGet = true)]
        public string Id { set; get; }

        [BindProperty]
        [Required]
        public string Title { set; get; }
        [BindProperty]
        [Required]
        public string Authors { set; get; }

        public void OnGet()
        {
            Book book = _lib.Get().SingleOrDefault(b => b.Id == Id);
            if (book != null)
            {
                Title = book.Title;
                Authors = book.Authors;
            }
        }

        public IActionResult OnPostAsync()
        {
            Book book = _lib.Get().SingleOrDefault(b => b.Id == Id);
            if (book != null)
            {
                _lib.Remove(book.Id);
            }
            return RedirectToPage("/Index");
        }
    }
}