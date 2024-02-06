using BoslaAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoslaAPI.Data.Config
{
    public class ChildConfiguration : IEntityTypeConfiguration<Child>
    {
        public void Configure(EntityTypeBuilder<Child> builder)
        {
            builder.ToTable("Children");
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

            builder.HasData(LoadData());
        }

        public List<Child> LoadData()
        {
            return new List<Child>
            {
                new Child
                {
                    Id = 1,
                    Name = "Emily Doe",
                    Age = 8,
                    Gender = "Female",
                    Address = "123 Playground Lane",
                    ProfileImage = "child_profile1.jpg",
                    RelativeName = "John Doe",
                    RelativePhone = "555-5678"
                },
                new Child
                {
                    Id = 2,
                    Name = "Jacob Smith",
                    Age = 5,
                    Gender = "Male",
                    Address = "456 Toy Street",
                    ProfileImage = "child_profile2.jpg",
                    RelativeName = "Jane Smith",
                    RelativePhone = "555-4321"
                },
                new Child
                {
                    Id = 3,
                    Name = "Olivia Johnson",
                    Age = 7,
                    Gender = "Female",
                    Address = "789 Fun Avenue",
                    ProfileImage = "child_profile3.jpg",
                    RelativeName = "Bob Johnson",
                    RelativePhone = "555-2222"
                },
                new Child
                {
                    Id = 4,
                    Name = "Liam Turner",
                    Age = 6,
                    Gender = "Male",
                    Address = "987 Playful Road",
                    ProfileImage = "child_profile4.jpg",
                    RelativeName = "Lisa Turner",
                    RelativePhone = "555-4444"
                }
            };
        } 
    }
}
