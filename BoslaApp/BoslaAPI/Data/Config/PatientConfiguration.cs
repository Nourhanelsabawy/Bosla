using BoslaAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoslaAPI.Data.Config
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.ToTable("Patients");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                   .ValueGeneratedOnAdd();
            builder.Property(x => x.Name)
                   .HasColumnType("NVARCHAR")
                   .HasMaxLength(150)
                   .IsRequired();
            builder.Property(x => x.Age)
                   .HasColumnType("INT")
                   .IsRequired();
            builder.Property(x => x.Gender)
                   .HasColumnType("VARCHAR")
                   .HasMaxLength(50)
                   .IsRequired();
            builder.Property(x => x.Address)
                   .HasColumnType("NVARCHAR")
                   .HasMaxLength(255)
                   .IsRequired();
            builder.Property(x => x.Phone)
                   .HasColumnType("VARCHAR")
                   .HasMaxLength(50)
                   .IsRequired();
            builder.Property(x => x.ProfileImage)
                   .HasColumnType("VARCHAR")
                   .HasMaxLength(255)
                   .IsRequired(false);
            builder.Property(x => x.RelativeName)
                   .HasColumnType("NVARCHAR")
                   .HasMaxLength(150)
                   .IsRequired();
            builder.Property(x => x.RelativePhone)
                   .HasColumnType("VARCHAR")
                   .HasMaxLength(50)
                   .IsRequired();
            builder.Property(x => x.BloodType)
                   .HasColumnType("VARCHAR")
                   .HasMaxLength(50)
                   .IsRequired();
            builder.Property(x => x.Disease)
                   .HasColumnType("VARCHAR")
                   .HasMaxLength(50)
                   .IsRequired();
            builder.Property(x => x.AllergicFoods)
                   .HasColumnType("NVARCHAR")
                   .HasMaxLength(255)
                   .IsRequired();

            // Relationship 1(Doctor) => N(Patients)
            builder.HasOne(x => x.Doctor)
                   .WithMany(x => x.Patients)
                   .HasForeignKey(x => x.DrId)
                   .IsRequired();

            // Relationship 1(Patient) => N(MedicalHistories)
            builder.HasMany(x => x.MedicalHistories)
                   .WithOne(x => x.Patient)
                   .HasForeignKey(x => x.PatId)
                   .IsRequired();

            builder.HasData(LoadData());
        }

        public List<Patient> LoadData()
        {
            return new List<Patient>
            {
                new Patient
                {
                    Id = 1,
                    Name = "John Doe",
                    Age = 30,
                    Gender = "Male",
                    Address = "123 Main Street",
                    Phone = "555-1234",
                    ProfileImage = "profile1.jpg",
                    RelativeName = "Jane Doe",
                    RelativePhone = "555-5678",
                    DrId = 1,
                    BloodType = "O+",
                    Disease = "Diabetes",
                    AllergicFoods = "Peanuts, Shellfish"
                },
                new Patient
                {
                    Id = 2,
                    Name = "Jane Smith",
                    Age = 45,
                    Gender = "Female",
                    Address = "456 Oak Avenue",
                    Phone = "555-9876",
                    ProfileImage = "profile2.jpg",
                    RelativeName = "John Smith",
                    RelativePhone = "555-4321",
                    DrId = 2,
                    BloodType = "A-",
                    Disease = "Heart Disease",
                    AllergicFoods = "Dairy, Gluten"
                },
                new Patient
                {
                    Id = 3,
                    Name = "Alice Johnson",
                    Age = 28,
                    Gender = "Female",
                    Address = "789 Pine Lane",
                    Phone = "555-1111",
                    ProfileImage = "profile3.jpg",
                    RelativeName = "Bob Johnson",
                    RelativePhone = "555-2222",
                    DrId = 3,
                    BloodType = "AB+",
                    Disease = "Alzheimer",
                    AllergicFoods = "Tree Nuts, Soy"
                },
                new Patient
                {
                    Id = 4,
                    Name = "Mason Turner",
                    Age = 35,
                    Gender = "Male",
                    Address = "987 Cedar Street",
                    Phone = "555-3333",
                    ProfileImage = "profile4.jpg",
                    RelativeName = "Lisa Turner",
                    RelativePhone = "555-4444",
                    DrId = 4,
                    BloodType = "B-",
                    Disease = "Autism",
                    AllergicFoods = "Eggs, Fish"
                },
                new Patient
                {
                    Id = 5,
                    Name = "Sophia White",
                    Age = 22,
                    Gender = "Female",
                    Address = "654 Birch Avenue",
                    Phone = "555-5555",
                    ProfileImage = "profile5.jpg",
                    RelativeName = "David White",
                    RelativePhone = "555-6666",
                    DrId = 1,
                    BloodType = "O-",
                    Disease = "Diabetes",
                    AllergicFoods = "Milk, Wheat"
                },
                new Patient
                {
                    Id = 6,
                    Name = "Elijah Brown",
                    Age = 40,
                    Gender = "Male",
                    Address = "321 Elm Road",
                    Phone = "555-7777",
                    ProfileImage = "profile6.jpg",
                    RelativeName = "Sarah Brown",
                    RelativePhone = "555-8888",
                    DrId = 2,
                    BloodType = "A+",
                    Disease = "Heart Disease",
                    AllergicFoods = "Shellfish, Peanuts"
                }
            };
        }
    }
}
