using BoslaAPI.Data.Config;
using BoslaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BoslaAPI.Data
{
    public class BoslaDbContext: DbContext
    {
        // DbSets
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Child> Children { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<MedicalHistory> MedicalHistories { get; set; }

        // Database Configuration
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var conStr = config.GetSection("ConnectionString").Value;

            optionsBuilder.UseSqlServer(conStr);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PatientConfiguration).Assembly);
        }
    }
}
