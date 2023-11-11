using healthcare_system.Models;
using Microsoft.EntityFrameworkCore;

namespace healthcare_system.Data.Mock
{
    public class DbSeeder
    {

        private readonly ApplicationDbContext _context;

        public DbSeeder(ApplicationDbContext context)
        {
            _context = context;
        }

        public void SeedData(ModelBuilder modelBuilder)
        {

            try
            {

            modelBuilder.Entity<Patient>().HasData(
                new Patient
                {
                    FirstName = "Jan",
                    LastName = "Sterle",
                    Birth = DateTime.Now,
                    Sex = "M",
                    Age = 20,
                    EmailAddress = "jan.sterle123@gmail.com",
                    PhoneNumber = "012345333"
                },
                new Patient
                {
                    FirstName = "Jan",
                    LastName = "Sterle",
                    Birth = DateTime.Now,
                    Sex = "M",
                    Age = 20,
                    EmailAddress = "jan.sterle123@gmail.com",
                    PhoneNumber = "012345333"
                }
            );
  
                _context.SaveChanges();
            }
            catch ( Exception ex )
            {
                Console.WriteLine($"Error during seed data: {ex.Message}");
            }
        }
    }
}
