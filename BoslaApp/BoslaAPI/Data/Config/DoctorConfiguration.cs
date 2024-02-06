using BoslaAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoslaAPI.Data.Config
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.ToTable("Doctors");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                   .ValueGeneratedOnAdd();
            builder.Property(x => x.Name)
                   .HasColumnType("NVARCHAR")
                   .HasMaxLength(150)
                   .IsRequired();
            builder.Property(x => x.Phone)
                   .HasColumnType("VARCHAR")
                   .HasMaxLength(50)
                   .IsRequired();
            builder.Property(x => x.Specialization)
                   .HasColumnType("VARCHAR")
                   .HasMaxLength(150)
                   .IsRequired();

            builder.HasData(LoadData());
        }
        
        public List<Doctor> LoadData()
        {
            return new List<Doctor>
            {
                new Doctor { Id = 1, Name = "Dr. John Doe", Phone = "123-456-7890", Specialization = "diabetes" },
                new Doctor { Id = 2, Name = "Dr. Jane Smith", Phone = "987-654-3210", Specialization = "heart diseases" },
                new Doctor { Id = 3, Name = "Dr. Alice Johnson", Phone = "555-123-4567", Specialization = "alzheimer" },
                new Doctor { Id = 4, Name = "Dr. Rebert Soll", Phone = "555-852-4567", Specialization = "autism" }
            };
        }
    }
}
