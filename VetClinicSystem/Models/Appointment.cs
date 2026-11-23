using System.ComponentModel.DataAnnotations;

namespace VetClinicSystem.Models
{
    public enum AppointmentStatus
    {
        Beklemede,
        Onaylandi,
        Tamamlandi,
        IptalEdildi
    }
    public class Appointment
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Randevu Başlangıç")]
        public DateTime StartTime { get; set; }

        [Required]
        [Display(Name = "Randevu Bitiş")]
        public DateTime EndTime { get; set; }

        [Display(Name = "Durum")]
        public AppointmentStatus Status { get; set; } = AppointmentStatus.Beklemede;

        [Display(Name = "Notlar")]
        public string? Notes { get; set; }

        [Required]
        public int PetId { get; set; }
        public Pet? Pet { get; set; }

        [Required]
        public int VeterinarianId {  get; set; }
        public Veterinarian? Veterinarian { get; set; }

        [Required]
        public int ServiceId { get; set; }
        public Service? Service { get; set; }
    }
}
