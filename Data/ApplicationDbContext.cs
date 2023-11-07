using healthcare_system.Models;
using Microsoft.EntityFrameworkCore;

namespace healthcare_system.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Patient> Patients { get; set; }
    }
}
