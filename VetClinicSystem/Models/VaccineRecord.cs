using System.ComponentModel.DataAnnotations;

namespace VetClinicSystem.Models
{
    public class VaccineRecord
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Aşı adı zorunludur.")]
        [Display(Name = "Aşı Adı")]
        public string VaccineName { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Uygulama Tarihi")]
        [DataType(DataType.Date)]
        public DateTime AdministeredDate { get; set; } = DateTime.UtcNow;

        [Display(Name = "Sonraki Hatırlatma Tarihi")]
        [DataType(DataType.Date)]
        public DateTime? NextDueDate {  get; set; }

        [Required]
        public int PetId { get; set; }

        public Pet? Pet { get; set; }
    }
}
