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

    public class CreateModel : PageModel
    {
        readonly Library _lib;

        public CreateModel(Library lib)
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
        }

        public IActionResult OnPostAsync()
        {
            if (ModelState.IsValid) {
                _lib.AddBook(Title, Authors);
                return RedirectToPage("/books/Index");
            }
            return Page();
        }
    }
}