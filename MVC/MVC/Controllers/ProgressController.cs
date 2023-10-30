using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class ProgressController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
