using Microsoft.EntityFrameworkCore;
using P01_HospitalDatabase.Data.Models;

namespace P01_HospitalDatabase.Data
{
    public class HospitalContext : DbContext
    {
        public HospitalContext(DbContextOptions options) : base(options)
        {
        }

        public HospitalContext():base()
        {
            
        }


        public DbSet<Patient> Patients { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Diagnose> Diagnoses { get; set; }
        public DbSet<Visitation> Visitations { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigPatient(modelBuilder);
            ConfigPatientMedicament(modelBuilder);
            ConfigMedicament(modelBuilder);
            ConfigDiagnose(modelBuilder);
            ConfigVisitation(modelBuilder);
            ConfigDoctor(modelBuilder);
        }

        private static void ConfigDoctor(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>()
                            .HasKey(x => x.DoctorId);
            modelBuilder.Entity<Doctor>()
                .Property(x => x.Name)
                .HasMaxLength(50)
                .IsUnicode()
                .IsRequired();
            modelBuilder.Entity<Doctor>()
                .Property(x => x.Specialty)
                .HasMaxLength(100)
                .IsUnicode()
                .IsRequired();
        }

        private static void ConfigVisitation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Visitation>()
                            .HasKey(x => x.VisitationId);


            modelBuilder.Entity<Visitation>()
                .Property(x => x.Date)
                .IsRequired();

            modelBuilder.Entity<Visitation>()
                .Property(x => x.Comments)
                .HasMaxLength(250)
                .IsUnicode()
                .IsRequired();

            modelBuilder.Entity<Visitation>()
                .HasOne(x => x.Patient)
                .WithMany(x => x.Visitations)
                .HasForeignKey(x => x.PatientId);
            modelBuilder.Entity<Visitation>()
                .HasOne(x => x.Doctor)
                .WithMany(x => x.Visitations)
                .HasForeignKey(x => x.DoctorId);
        }

        private static void ConfigDiagnose(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Diagnose>()
                .HasKey(x => x.DiagnoseId);

            modelBuilder.Entity<Diagnose>()
                .Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired()
                .IsUnicode();


            modelBuilder.Entity<Diagnose>()
                .Property(x => x.Comments)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(250);

            modelBuilder.Entity<Diagnose>()
                .HasOne(x => x.Patient)
                .WithMany(x => x.Diagnoses)
                .HasForeignKey(x => x.PatientId);
        }

        private static void ConfigMedicament(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Medicament>()
                .HasKey(x => x.MedicamentId);

            modelBuilder.Entity<Medicament>()
                            .Property(x => x.Name)
                            .HasMaxLength(50)
                            .IsUnicode()
                            .IsRequired();
        }

        private static void ConfigPatientMedicament(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PatientMedicament>()
                .HasKey(x => new { x.PatientId, x.MedicamentId });

            modelBuilder.Entity<PatientMedicament>()
                .HasOne(x => x.Patient)
                .WithMany(x => x.Prescriptions);

            modelBuilder.Entity<PatientMedicament>()
                .HasOne(x => x.Medicament)
                .WithMany(x => x.Prescriptions);
        }

        private static void ConfigPatient(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>()
                .HasKey(x => x.PatientId);

            modelBuilder.Entity<Patient>()
                .Property(x => x.FirstName)
                .HasMaxLength(50)
                .IsUnicode()
                .IsRequired();

            modelBuilder.Entity<Patient>()
                .Property(x => x.LastName)
                .HasMaxLength(50)
                .IsUnicode()
                .IsRequired();

            modelBuilder.Entity<Patient>()
                .Property(x => x.Address)
                .HasMaxLength(250)
                .IsRequired()
                .IsUnicode();

            modelBuilder.Entity<Patient>()
                .Property(x => x.Email)
                .HasMaxLength(80);


            modelBuilder.Entity<Patient>()
                .HasMany(x => x.Diagnoses)
                .WithOne(x => x.Patient)
                .HasForeignKey(x => x.DiagnoseId);

            modelBuilder.Entity<Patient>()
                .HasMany(x => x.Visitations)
                .WithOne(x => x.Patient)
                .HasForeignKey(x => x.VisitationId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer("Server=DESKTOP-CUCRL15\\SQLEXPRESS;Database=Hospital;Integrated Security=true");
            }
        }
    }
}