using CarRentalWebApp.Data;
using CarRentalWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CarRentalWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly CarRentalDbContext _context;

        public HomeController(CarRentalDbContext context)
        {
            _context = context;
        }

        //Araç Görüntüleme Tarafı

        public async Task<IActionResult> Index()
        {
            var availableCars = await _context.Cars
                .Where(c => c.IsAvailable)
                .ToListAsync();
            return View(availableCars);
        }

        //Kira Talep Tarafı

        public async Task<IActionResult> RentalRequest(int carId)
        {
            var car = await _context.Cars.FindAsync(carId);
            if (car == null)
            {
                return NotFound();
            }

            var model = new RentalRequestViewModel
            {
                CarId = car.Id,
                CarInfo = $"{car.Brand} {car.Model} ({car.Year}) - {car.DailyPrice:C}/Gün",
                StartDate = DateTime.Now.Date,
                EndDate = DateTime.Now.Date.AddDays(1)
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RentalRequest(RentalRequestViewModel model)
        {
            var car = await _context.Cars.FindAsync(model.CarId);
            if (car == null || !car.IsAvailable)
            {
                return NotFound();
            }

            model.CarInfo = $"{car.Brand} {car.Model} ({car.Year}) - {car.DailyPrice:C}/Gün";

            if (model.EndDate <= model.StartDate)
            {
                ModelState.AddModelError("EndDate", "Bitiş tarihi başlangıç tarihinden sonra olmalıdır.");
            }

            if (ModelState.IsValid)
            {
                var customer = await _context.Customers
                    .FirstOrDefaultAsync(c => c.Email == model.Email);

                if (customer == null)
                {
                    customer = new Customer
                    {
                        Name = model.CustomerName,
                        PhoneNumber = model.PhoneNumber,
                        Email = model.Email,
                        RegistrationDate = DateTime.Now
                    };
                    _context.Customers.Add(customer);
                    await _context.SaveChangesAsync();
                }

                var rental = new Rental
                {
                    CustomerId = customer.Id,
                    CarId = model.CarId,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    IsCompleted = false
                };

                _context.Rentals.Add(rental);
                car.IsAvailable = false;

                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Kiralama başarı ile oluşturuldu.";
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
    }
}
