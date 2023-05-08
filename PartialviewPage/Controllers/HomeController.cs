using Microsoft.AspNetCore.Mvc;
using PartialviewPage.DAL;
using PartialviewPage.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace PartialviewPage.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext _context;
        public HomeController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            HomeViewModel ViewModel = new HomeViewModel()
            {
                Features = _context.Features.ToList(),
                Sliders = _context.Sliders.ToList(),
                FeaturedBooks = _context.Books.Include(x => x.Author).Include(x => x.BookImages).Where(x => x.IsFeatured).Take(10).ToList(),
                NewBooks = _context.Books.Include(x => x.Author).Include(x => x.BookImages).Where(x => x.IsNew).Take(10).ToList(),
                DiscountedBooks = _context.Books.Include(x => x.Author).Include(x => x.BookImages).Where(x => x.DiscountPercent > 0).Take(10).ToList(),
            };
            return View(ViewModel);
        }
    }
}
