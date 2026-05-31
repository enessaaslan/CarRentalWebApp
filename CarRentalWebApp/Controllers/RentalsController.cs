using CarRentalWebApp.Data;
using CarRentalWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CarRentalWebApp.Controllers
{
    [Authorize(Roles = "Admin")]
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

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Approve(int id)
        {
            var rental = await _context.Rentals
                .Include(r => r.Car)
                .FirstOrDefaultAsync(r => r.Id == id);
            if (rental == null || rental.IsApproved)
            {
                return NotFound();
            }
            rental.IsApproved = true;

            if (rental.Car != null)
            {
                rental.Car.IsAvailable = false;
            }
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Kiralama başarıyla onaylandı.";
            return RedirectToAction(nameof(Index));
        }
    }
}