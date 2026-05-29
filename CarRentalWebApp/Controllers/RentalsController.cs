using CarRentalWebApp.Data;
using CarRentalWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CarRentalWebApp.Controllers
{
    public class RentalsController : Controller
    {
        private readonly CarRentalDbContext _context;

        public RentalsController(CarRentalDbContext context)
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
            return View(new RentalModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RentalModel rental)
        {
            if (rental.StartDate >= rental.EndDate)
            {
                ModelState.AddModelError("EndDate", "Bitiş Tarihi başlangıç tarihinden önce olamaz.");
            }

            if (ModelState.IsValid)
            {
                var car = await _context.Cars.FindAsync(rental.CarId);
                if (car == null || !car.IsAvailable)
                {
                    ModelState.AddModelError("CarId", "Seçilen araba şuan müsait değil.");
                }
                else
                {
                    rental.IsCompleted = false;
                    _context.Add(rental);
                    car.IsAvailable = false;
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }

            var availableCars = await _context.Cars
                .Where(c => c.IsAvailable)
                .Select(c => new { c.Id, c.Brand, c.Model, c.PlateNumber })
                .ToListAsync();

            ViewData["AvailableCars"] = availableCars.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = $"{c.Brand} {c.Model} ({c.PlateNumber})"
            }).ToList();
            return View(rental);
        }

        public async Task<IActionResult> Return(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rental = await _context.Rentals
                .Include(r => r.Car)
                .Include(r => r.Customer)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (rental == null)
            {
                return NotFound();
            }

            return View(rental);
        }

        [HttpPost, ActionName("Return")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ReturnConfirm(int id)
        {
            var rental = await _context.Rentals
                .Include(r => r.Car)
                .FirstOrDefaultAsync(r => r.Id == id);
            if (rental != null && !rental.IsCompleted)
            {
                rental.IsCompleted = true;
                if (rental.Car != null)
                {
                    rental.Car.IsAvailable = true;
                }

                await _context.SaveChangesAsync();
            }
            
            return RedirectToAction(nameof(Index));

        }
    }
}