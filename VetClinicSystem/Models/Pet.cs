using System.ComponentModel.DataAnnotations;
namespace VetClinicSystem.Models
{
    public class Pet
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Hayvan adı zorunludur.")]
        [Display(Name = "Adı")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Tür zorunludur.")]
        [Display(Name = "Tür (Kedi, Köpek vb.)")]
        public string Species { get; set; } = string.Empty;

        [Display(Name = "Irk")]
        public string? Breed { get; set;  }

        [Display(Name = "Doğum Tarihi")]
        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }

        [Required]
        public string OwnerId { get; set; } = string.Empty;
        public ApplicationUser? Owner { get; set; }

        public ICollection<VaccineRecord> VaccineRecords { get; set; }
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
