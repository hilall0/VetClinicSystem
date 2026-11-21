using System.ComponentModel.DataAnnotations;

namespace VetClinicSystem.Models
{
    public class Service
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Hizmet adı zorunludur.")]
        [Display(Name = "Hizmet Adı")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Süre bilgisi zorunludur.")]
        [Range(5, 480, ErrorMessage = "Süre 5 ile 480 dakika arasında olmalıdır.")]
        [Display(Name = "Süre (Dakika)")]
        public int DurationMinutes { get; set; }

        [Required(ErrorMessage = "Ücret bilgisi zorunludur.")]
        [Range(0, 100000, ErrorMessage = "Geçerli bir ücret giriniz.")]
        [Display(Name = "Ücret (₺)")]
        public decimal Price { get; set; }
    }
}