using healthcare_system.Data.Mock;
using healthcare_system.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;



namespace healthcare_system.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        protected readonly IConfiguration Configuration;

        public ApplicationDbContext(IConfiguration configuration, DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("Cloud"));
            //options.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));
           // options.UseSnakeCaseNamingConvention();
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

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

            


            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>()
                .HasOne(a => a.Doctor)
                .WithOne(d => d.ApplicationUser)
                .HasForeignKey<Doctor>(d => d.ApplicationUserId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<ApplicationUser>()
                .HasOne(a => a.Patient)
                .WithOne(p => p.ApplicationUser)
                .HasForeignKey<Patient>(p => p.ApplicationUserId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<TermReservation>()
                .HasOne(t => t.Patient)
                .WithMany()
                .HasForeignKey(t => t.PatientId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<TermReservation>()
                .HasOne(t => t.Doctor)
                .WithMany()
                .HasForeignKey(t => t.DoctorId)
                .OnDelete(DeleteBehavior.NoAction);
                

            modelBuilder.Entity<Consultation>()
                .HasOne(c => c.Prescription)
                .WithOne(p => p.Consultation)
                .HasForeignKey<Prescription>(p => p.ConsultationId);

            /*modelBuilder.Entity<Patient>()
                .HasIndex(p => p.Email)
                .IsUnique(); */


        }
    }

    
}
