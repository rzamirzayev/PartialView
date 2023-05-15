using Microsoft.AspNetCore.Mvc;

namespace PartialviewPage.Areas.Manage.Controllers
{
    [Area("manage")]
    public class DashBoardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
