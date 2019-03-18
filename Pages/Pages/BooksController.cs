using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Pages.Pages
{
    
    [ApiController]
    public class BooksController : ControllerBase
    {
        readonly Library _lib;


        public BooksController(Library lib)
        {
            _lib = lib;           
        }

        [Route("api/books")]
        public IActionResult CreateBook([FromForm] string title, [FromForm] string authors)
        {
            if (ModelState.IsValid)
            {
                _lib.AddBook(title, authors);
                return Ok();
            }
            return BadRequest();
        }

    }
}