using System.ComponentModel.DataAnnotations;

namespace CarRentalWebApp.Models
{
    public class RentalModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Müşteri ID")]
        public int CustomerId { get; set; }
        [Required]
        [Display(Name = "Araba ID")]
        public int CarId { get; set; }
        [Required(ErrorMessage = "Başlangıç tarihi zorunludur.")]
        [Display(Name = "Başlangıç Tarihi")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "Bitiş tarihi zorunludur.")]
        [Display(Name = "Bitiş Tarihi")]
        public DateTime EndDate { get; set; }
        public bool IsCompleted { get; set; } = false;
        public bool IsApproved { get; set; } = false;

        // Navigation prop.
        public CustomerModel Customer { get; set; }
        public CarModel Car { get; set; }
    }
}
