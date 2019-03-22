using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Pages
{

    public class EditModel : PageModel
    {
        readonly Library _db;

        public EditModel(Library lib)
        {
            _db = lib;
        }

        [BindProperty(SupportsGet = true)]
        public Book Book { set; get; }

        public void OnGet()
        {
            Book = _db.Get(Book.Id);
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid) {
                _db.Update(Book.Id, Book);
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}