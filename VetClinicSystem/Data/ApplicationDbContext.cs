using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VetClinicSystem.Models;

namespace VetClinicSystem.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Service> Services { get; set; }
        public DbSet<Veterinarian> Veterinarians { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<VaccineRecord> VaccineRecords { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
    }
}
