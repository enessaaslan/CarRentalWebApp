using System.ComponentModel.DataAnnotations;

namespace CarRentalWebApp.Models
{
    public class CarModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Marka boş bırakılamaz.")]
        [StringLength(50, ErrorMessage = "Marka en fazla 50 karakter olabilir.")]
        [Display(Name = "Marka")]
        public string Brand { get; set; }
        [Required(ErrorMessage = "Model boş bırakılamaz.")]
        [StringLength(50, ErrorMessage = "Model en fazla 50 karakter olabilir.")]
        [Display(Name = "Model")]
        public string Model { get; set; }
        [Required(ErrorMessage = "Yıl boş bırakılamaz.")]
        [Display(Name = "Yıl")]
        public int Year { get; set; }
        [Required(ErrorMessage = "Plaka zorunludur.")]
        [StringLength(10, ErrorMessage = "Plaka en fazla 10 karakter olabilir.")]
        [Display(Name = "Plaka")]
        public string PlateNumber { get; set; }
        [Required(ErrorMessage = "Günlük fiyat boş bırakılamaz.")]
        [Range(0, double.MaxValue, ErrorMessage = "Günlük fiyat geçerli bir değer (0 ve üzeri) olmalıdır.")]
        [Display(Name = "Günlük Fiyat")]
        public decimal DailyPrice { get; set; }
        public bool IsAvailable { get; set; } = true;

        // Navigation prop.

        public ICollection<RentalModel> Rentals { get; set; } = new List<RentalModel>();
    }
}
