using System.ComponentModel.DataAnnotations;

namespace VetClinicSystem.Models
{
    public class Veterinarian
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Veteriner adı zorunludur.")]
        [Display(Name = "Ad Soyad")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Uzmanlık alanı zorunludur.")]
        [Display(Name = "Uzmanlık Alanı")]
        public string Specialty { get; set; } = string.Empty;

        [Display(Name = "Çalışma Başlangıç Saati")]
        public TimeSpan WorkStartTime { get; set; } = new TimeSpan(9, 0, 0);

        [Display(Name = "Çalışma Bitiş Saati")]
        public TimeSpan WorkEndTime { get; set; } = new TimeSpan(18, 0, 0);

        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
