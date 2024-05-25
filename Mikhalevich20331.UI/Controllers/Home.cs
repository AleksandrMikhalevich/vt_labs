using Microsoft.AspNetCore.Mvc;

namespace Mikhalevich20331.UI.Controllers
{
    public class Home : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
