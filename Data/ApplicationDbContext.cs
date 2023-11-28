using healthcare_system.Data.Mock;
using healthcare_system.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;



namespace healthcare_system.Data
{
    public class ApplicationDbContext : IdentityDbContext<Doctor>
    {
        protected readonly IConfiguration Configuration;

        public ApplicationDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));
            options.UseSnakeCaseNamingConvention();
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<TermReservation> TermReservations { get; set; }
        public DbSet<Consultation> Consultations { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Medicine> Medicines { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //zdi se mi da tega nerabva nism pa zihr zto bom pustu zaenkt notr zakomentiran
            //modelBuilder.Entity<Department>()
            //    .HasOne(d => d.Hospital)
            //    .WithMany(h => h.Departments)
            //    .HasForeignKey(d => d.HospitalId);

            //modelBuilder.Entity<Doctor>()
            //    .HasOne(dr => dr.Department)
            //    .WithMany(d => d.Doctors)
            //    .HasForeignKey(dr => dr.DepartmentId);

            modelBuilder.HasDefaultSchema("public");
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Consultation>()
                .HasOne(c => c.Prescription)
                .WithOne(p => p.Consultation)
                .HasForeignKey<Prescription>(p => p.ConsultationId);


        }
    }

    
}
