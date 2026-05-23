using System.ComponentModel.DataAnnotations;

namespace CarRentalWebApp.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ad boş bırakılamaz.")]
        [StringLength(20, ErrorMessage = "Ad en fazla 20 karakter olabilir.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Soyad boş bırakılamaz.")]
        [StringLength(20, ErrorMessage = "Soyad en fazla 20 karakter olabilir.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "E-posta boş bırakılamaz.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Telefon numarası boş bırakılamaz.")]
        [Phone(ErrorMessage = "Geçerli bir telefon numarası giriniz.")]
        public string PhoneNumber { get; set; }
        public DateTime RegistrationDate { get; set; }

        // Navigation prop.
        public ICollection<Rental> Rentals { get; set; } = new List<Rental>();
    }
}
