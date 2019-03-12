using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BookLibrary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Pages.Pages.Books
{

    public class EditModel : PageModel
    {
        readonly Library _lib;

        public EditModel(Library lib)
        {
            _lib = lib;
        }

        [BindProperty(SupportsGet = true)]
        public int Id { set; get; }

        [BindProperty]
        [Required]
        public string Title { set; get; }
        [BindProperty]
        [Required]
        public string Authors { set; get; }

        public void OnGet()
        {
            Book book = _lib.Books.SingleOrDefault(b => b.Id == Id);
            if (book != null)
            {               
                Title = book.Title;
                Authors = book.Authors;
            }
        }

        public IActionResult OnPostAsync()
        {
            if (ModelState.IsValid) {
                Book book = _lib.Books.SingleOrDefault(b => b.Id == Id);
                if (book != null)
                {
                    book.Title = Title;
                    book.Authors = Authors;
                }
                return RedirectToPage("/books/Index");
            }
            return Page();
        }
    }
}