using Microsoft.AspNetCore.Mvc;

namespace awww_az.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
