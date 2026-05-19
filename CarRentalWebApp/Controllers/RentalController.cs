using CarRentalWebApp.Data;
using CarRentalWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CarRentalWebApp.Controllers
{
    public class RentalController : Controller
    {
        private readonly CarRentalDbContext _context;

        public RentalController(CarRentalDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var rental = await _context.Rentals
                .Include(r => r.Customer)
                .Include(r => r.Car)
                .OrderByDescending(r => r.StartDate)
                .ToListAsync();
            return View(rental);
        }

        public async Task<IActionResult> Create()
        {
            var availableCars = await _context.Cars
                .Where(c => c.IsAvailable)
                .Select(c => new { c.Id, c.Brand, c.Model, c.PlateNumber })
                .ToListAsync();

            ViewData["AvailableCars"] = availableCars.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = $"{c.Brand} {c.Model} ({c.PlateNumber})"
            }).ToList();
            return View(new Rental());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Rental rental)
        {

        }

    }
}
