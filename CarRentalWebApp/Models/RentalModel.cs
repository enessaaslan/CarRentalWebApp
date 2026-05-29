using System.ComponentModel.DataAnnotations;

namespace CarRentalWebApp.Models
{
    public class RentalModel
    {
        public int Id { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public int CarId { get; set; }
        [Required(ErrorMessage = "Başlangıç tarihi zorunludur.")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "Bitiş tarihi zorunludur.")]
        public DateTime EndDate { get; set; }
        public bool IsCompleted { get; set; } = false;

        // Navigation prop.
        public CustomerModel Customer { get; set; }
        public CarModel Car { get; set; }
    }
}
