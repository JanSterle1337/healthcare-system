using healthcare_system.Models;
using Microsoft.EntityFrameworkCore;

namespace healthcare_system.Data
{
    public class ApplicationDbContext: DbContext
    {
        protected readonly IConfiguration Configuration;

        public ApplicationDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));
        }

        public DbSet<Patient> Patients { get; set; }
    }
}
