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

    public class CreateModel : PageModel
    {
        readonly Library _lib;

        public CreateModel(Library lib)
        {
            _lib = lib;
        }

        //[BindProperty(SupportsGet = true)]
        //public int Id { set; get; }

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
                var book = new Book { Authors = Authors, Title = Title };
                book = _lib.Create(book);
                return RedirectToPage("/Index");
            }
            return Page();
        }
    }
}