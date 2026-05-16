using System.ComponentModel.DataAnnotations;

namespace CarRentalWebApp.Models
{
    public class Rental
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
        public Customer Customer { get; set; }
        public Car Car { get; set; }
    }
}
