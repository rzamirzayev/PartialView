using Microsoft.AspNetCore.Mvc;
using PartialviewPage.DAL;
using PartialviewPage.Models;
using PartialviewPage.ViewModels;

namespace PartialviewPage.Areas.Manage.Controllers
{
    [Area("manage")]
    public class SliderController : Controller
    {
        private readonly DataContext _context;
        public SliderController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index(int page = 1)
        {
            var questoin = _context.Sliders;
            return View(PaginatedList<Slider>.Create(questoin, page, 3));
        }
    }
}
