using Microsoft.AspNetCore.Mvc;
using PartialviewPage.DAL;

namespace PartialviewPage.ViewComponents
{
    public class NavGenresViewComponent : ViewComponent
    {
        private readonly DataContext _context;

        public NavGenresViewComponent(DataContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var data = _context.Genres.ToList();
            return View(data);
        }
    }
}
