using System.ComponentModel.DataAnnotations;

namespace CarRentalWebApp.Models
{
    public class RentalRequestViewModel
    {
        public int CarId { get; set; }
        public string CarInfo { get; set; }
        [Required(ErrorMessage = "Müşteri adı boş bırakılamaz.")]
        [StringLength(20, ErrorMessage = "Müşteri adı en fazla 20 karakter olabilir.")]
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "Telefon numarası boş bırakılamaz.")]
        [StringLength(15, ErrorMessage = "Telefon numarası en fazla 15 karakter olabilir.")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "E-posta adresi boş bırakılamaz.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi girin.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Başlangıç tarihi boş bırakılamaz.")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "Bitiş tarihi boş bırakılamaz.")]
        public DateTime EndDate { get; set; }
    }
}
