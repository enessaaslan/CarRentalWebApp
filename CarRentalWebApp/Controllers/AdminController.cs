using Microsoft.AspNetCore.Mvc;

namespace CarRentalWebApp.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
