using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace VetClinicSystem.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Required(ErrorMessage = "Ad Soyad zorunludur.")]
        [Display(Name = "Ad Soyad")]
        public string FullName { get; set; } = string.Empty;
        public ICollection<Pet> Pets { get; set; } = new List<Pet>();
    }
}
