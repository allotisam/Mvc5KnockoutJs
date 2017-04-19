using BootstrapIntro.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BootstrapIntro.Controllers
{
    public class BooksController : Controller
    {
        private BookContext db = new BookContext();
        
        [Route("authors/{id}/books")]
        public async Task<ActionResult> ByAuthor(int id)
        {
            var books = await db.Books.Where(b => b.AuthorId == id).ToListAsync();
            return View(books);
        }
    }
}