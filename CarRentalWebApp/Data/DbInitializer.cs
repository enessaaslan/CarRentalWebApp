using CarRentalWebApp.Models;
using System;
using System.Linq;

namespace CarRentalWebApp.Data
{
    public static class DbInitializer
    {
        public static void Initialize(CarRentalDbContext context)
        {
            // Veritabanının oluşturulduğundan emin ol
            context.Database.EnsureCreated();

            if (context.Cars.Any())
            {
                return;
            }

            var cars = new CarModel[]
            {
                new CarModel { Brand = "Mercedes-Benz", Model = "C200 AMG", Year = 2024, PlateNumber = "34 MER 01", DailyPrice = 3500 },
                new CarModel { Brand = "Mercedes-Benz", Model = "E300d", Year = 2023, PlateNumber = "34 MER 02", DailyPrice = 5000 },
                new CarModel { Brand = "Mercedes-Benz", Model = "S400d Long", Year = 2024, PlateNumber = "34 MER 03", DailyPrice = 12000 },
                new CarModel { Brand = "Mercedes-Benz", Model = "G63 AMG", Year = 2023, PlateNumber = "34 MER 04", DailyPrice = 25000 },
                
                new CarModel { Brand = "BMW", Model = "320i M Sport", Year = 2024, PlateNumber = "34 BMW 01", DailyPrice = 3300 },
                new CarModel { Brand = "BMW", Model = "520i", Year = 2023, PlateNumber = "34 BMW 02", DailyPrice = 4800 },
                new CarModel { Brand = "BMW", Model = "740d xDrive", Year = 2024, PlateNumber = "34 BMW 03", DailyPrice = 11000 },
                new CarModel { Brand = "BMW", Model = "X5 xDrive40i", Year = 2023, PlateNumber = "34 BMW 04", DailyPrice = 9000 },

                new CarModel { Brand = "Audi", Model = "A3 Sportback", Year = 2024, PlateNumber = "34 AUD 01", DailyPrice = 2500 },
                new CarModel { Brand = "Audi", Model = "A4 Sedan", Year = 2023, PlateNumber = "34 AUD 02", DailyPrice = 3200 },
                new CarModel { Brand = "Audi", Model = "A6 Quattro", Year = 2024, PlateNumber = "34 AUD 03", DailyPrice = 5500 },
                new CarModel { Brand = "Audi", Model = "Q7 S-Line", Year = 2023, PlateNumber = "34 AUD 04", DailyPrice = 9500 },

                new CarModel { Brand = "Porsche", Model = "Macan", Year = 2024, PlateNumber = "34 POR 01", DailyPrice = 10000 },
                new CarModel { Brand = "Porsche", Model = "Cayenne", Year = 2023, PlateNumber = "34 POR 02", DailyPrice = 15000 },
                new CarModel { Brand = "Porsche", Model = "Panamera", Year = 2024, PlateNumber = "34 POR 03", DailyPrice = 18000 },

                new CarModel { Brand = "Volvo", Model = "S90 Inscription", Year = 2023, PlateNumber = "34 VOL 01", DailyPrice = 4500 },
                new CarModel { Brand = "Volvo", Model = "XC90 Recharge", Year = 2024, PlateNumber = "34 VOL 02", DailyPrice = 8500 },

                new CarModel { Brand = "Land Rover", Model = "Range Rover Velar", Year = 2023, PlateNumber = "34 LND 01", DailyPrice = 8000 },
                new CarModel { Brand = "Land Rover", Model = "Range Rover Sport", Year = 2024, PlateNumber = "34 LND 02", DailyPrice = 14000 },

                new CarModel { Brand = "Tesla", Model = "Model S Plaid", Year = 2024, PlateNumber = "34 TSL 01", DailyPrice = 12500 }
            };

            foreach (var c in cars)
            {
                context.Cars.Add(c);
            }
            
            if (!context.Customers.Any())
            {
                var customers = new CustomerModel[]
                {
                    new CustomerModel { Name = "Ahmet", LastName = "Yılmaz", Email = "ahmet.yilmaz@test.com", PhoneNumber = "5551112233", RegistrationDate = DateTime.Now.AddDays(-10) },
                    new CustomerModel { Name = "Ayşe", LastName = "Kaya", Email = "ayse.kaya@test.com", PhoneNumber = "5552223344", RegistrationDate = DateTime.Now.AddDays(-15) },
                    new CustomerModel { Name = "Mehmet", LastName = "Demir", Email = "mehmet.demir@test.com", PhoneNumber = "5553334455", RegistrationDate = DateTime.Now.AddDays(-20) },
                    new CustomerModel { Name = "Fatma", LastName = "Çelik", Email = "fatma.celik@test.com", PhoneNumber = "5554445566", RegistrationDate = DateTime.Now.AddDays(-5) },
                    new CustomerModel { Name = "Ali", LastName = "Şahin", Email = "ali.sahin@test.com", PhoneNumber = "5555556677", RegistrationDate = DateTime.Now.AddDays(-30) },
                    new CustomerModel { Name = "Zeynep", LastName = "Öztürk", Email = "zeynep.ozturk@test.com", PhoneNumber = "5556667788", RegistrationDate = DateTime.Now.AddDays(-2) },
                    new CustomerModel { Name = "Burak", LastName = "Yıldız", Email = "burak.yildiz@test.com", PhoneNumber = "5557778899", RegistrationDate = DateTime.Now.AddDays(-40) },
                    new CustomerModel { Name = "Elif", LastName = "Doğan", Email = "elif.dogan@test.com", PhoneNumber = "5558889900", RegistrationDate = DateTime.Now.AddDays(-1) },
                    new CustomerModel { Name = "Caner", LastName = "Arslan", Email = "caner.arslan@test.com", PhoneNumber = "5559990011", RegistrationDate = DateTime.Now.AddDays(-60) },
                    new CustomerModel { Name = "Deniz", LastName = "Kılıç", Email = "deniz.kilic@test.com", PhoneNumber = "5551012030", RegistrationDate = DateTime.Now.AddDays(-12) },
                    new CustomerModel { Name = "Emre", LastName = "Polat", Email = "emre.polat@test.com", PhoneNumber = "5552023040", RegistrationDate = DateTime.Now.AddDays(-8) },
                    new CustomerModel { Name = "Ceren", LastName = "Koç", Email = "ceren.koc@test.com", PhoneNumber = "5553034050", RegistrationDate = DateTime.Now.AddDays(-25) },
                    new CustomerModel { Name = "Hakan", LastName = "Aydın", Email = "hakan.aydin@test.com", PhoneNumber = "5554045060", RegistrationDate = DateTime.Now.AddDays(-35) },
                    new CustomerModel { Name = "Gizem", LastName = "Bulut", Email = "gizem.bulut@test.com", PhoneNumber = "5555056070", RegistrationDate = DateTime.Now.AddDays(-18) },
                    new CustomerModel { Name = "Ozan", LastName = "Turan", Email = "ozan.turan@test.com", PhoneNumber = "5556067080", RegistrationDate = DateTime.Now.AddDays(-3) }
                };

                foreach (var cus in customers)
                {
                    context.Customers.Add(cus);
                }
            }

            context.SaveChanges();
        }
    }
}
