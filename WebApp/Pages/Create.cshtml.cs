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
        readonly Library _db;

        public CreateModel(Library lib)
        {
            _db = lib;
        }

        [BindProperty(SupportsGet = true)]
        public Book Book { set; get; }

        public void OnGet()
        {
        }

        public IActionResult OnPostAsync()
        {
            if (ModelState.IsValid) {                
                _db.Create(Book);
                return RedirectToPage("/Index");
            }
            return Page();
        }
    }
}