using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VetClinicSystem.Models;

namespace VetClinicSystem.Data
{
    public static class DbInitializer
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            await context.Database.MigrateAsync();

            string[] roleNames = { "Admin", "Veteriner", "Uye" };
            foreach (var roleName in roleNames)
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            var adminEmail = "admin@vetclinic.com";
            var adminUser = await userManager.FindByEmailAsync(adminEmail);
            if (adminUser == null)
            {
                adminUser = new ApplicationUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    FullName = "Klinik Yöneticisi (Admin)",
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(adminUser, "Admin123!");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }

            if (!await context.Services.AnyAsync())
            {
                context.Services.AddRange(
                    new Service { Name = "Genel Muayene", DurationMinutes = 30, Price = 750 },
                    new Service { Name = "Karma Aşı Uygulaması", DurationMinutes = 20, Price = 950 },
                    new Service { Name = "Kuduz Aşısı", DurationMinutes = 15, Price = 650 },
                    new Service { Name = "İç-Dış Parazit Uygulaması", DurationMinutes = 20, Price = 550 },
                    new Service { Name = "Diş Taşı Temizliği", DurationMinutes = 60, Price = 2500 }
                );
            }

            if (!await context.Veterinarians.AnyAsync())
            {
                context.Veterinarians.AddRange(
                    new Veterinarian
                    {
                        FullName = "Vet. Hek. Ahmet Yılmaz",
                        Specialty = "Dahiliye ve Genel Cerrahi",
                        WorkStartTime = new TimeSpan(9, 0, 0),
                        WorkEndTime = new TimeSpan(18, 0, 0)
                    },
                    new Veterinarian
                    {
                        FullName = "Vet. Hek. Zeynep Kaya",
                        Specialty = "Aşı, Parazit ve Koruyucu Hekimlik",
                        WorkStartTime = new TimeSpan(10, 0, 0),
                        WorkEndTime = new TimeSpan(19, 0, 0)
                    }
                );
            }

            await context.SaveChangesAsync();
        }
    }
}