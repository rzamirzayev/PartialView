using Microsoft.AspNetCore.Mvc;
using PartialviewPage.Models;
using Microsoft.EntityFrameworkCore;
using PartialviewPage.DAL;

namespace PartialviewPage.Controllers
{
    public class BookController : Controller
    {
        private readonly DataContext _context;
        public BookController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Booksearch(int id)
        {
            Book book = _context.Books.Include(x => x.Author).Include(x => x.BookImages).FirstOrDefault(x => x.Id == id);
            return PartialView("_BookPartial", book);
        }
    }
}
