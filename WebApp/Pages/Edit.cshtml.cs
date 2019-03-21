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

    public class EditModel : PageModel
    {
        readonly Library _lib;

        public EditModel(Library lib)
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
            Book book = _lib.Get(Id);
            if (book != null)
            {               
                Title = book.Title;
                Authors = book.Authors;
            }
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid) {
                var newBook = new Book { Authors = Authors, Id = Id, Title = Title };
                _lib.Update(Id, newBook);
                return RedirectToPage("/Index");
            }
            return Page();
        }
    }
}