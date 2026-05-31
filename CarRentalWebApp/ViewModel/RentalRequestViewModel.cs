using System.ComponentModel.DataAnnotations;

namespace CarRentalWebApp.ViewModel
{
    public class RentalRequestViewModel
    {
        public int CarId { get; set; }
        public string? CarInfo { get; set; }
        [Required(ErrorMessage = "Müşteri adı boş bırakılamaz.")]
        [StringLength(20, ErrorMessage = "Müşteri adı en fazla 20 karakter olabilir.")]
        [Display(Name = "Müşteri Adı")]
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "Müşteri Soyismi boş bırakılamaz.")]
        [StringLength(20, ErrorMessage = "Müşteri Soyismi en fazla 20 karakter olabilir.")]
        [Display(Name = "Müşteri Soyadı")]
        public string CustomerSurname { get; set; }
        [Required(ErrorMessage = "Telefon numarası boş bırakılamaz.")]
        [StringLength(15, ErrorMessage = "Telefon numarası en fazla 15 karakter olabilir.")]
        [Display(Name = "Telefon Numarası")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "E-posta adresi boş bırakılamaz.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi girin.")]
        [Display(Name = "E-posta")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Başlangıç tarihi boş bırakılamaz.")]
        [Display(Name = "Başlangıç Tarihi")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "Bitiş tarihi boş bırakılamaz.")]
        [Display(Name = "Bitiş Tarihi")]
        public DateTime EndDate { get; set; }
    }
}
