using Microsoft.AspNetCore.Mvc;

namespace Final_Project.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
