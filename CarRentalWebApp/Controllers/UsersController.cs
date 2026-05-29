using Microsoft.AspNetCore.Mvc;

namespace CarRentalWebApp.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
