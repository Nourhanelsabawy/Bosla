using BoslaAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoslaAPI.Data.Config
{
    public class MedicalHistoryConfiguration : IEntityTypeConfiguration<MedicalHistory>
    {
        public void Configure(EntityTypeBuilder<MedicalHistory> builder)
        {
            builder.ToTable("MedicalHistories");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                   .ValueGeneratedOnAdd();
            builder.Property(x => x.Diagnose)
                   .HasColumnType("VARCHAR")
                   .HasMaxLength(255)
                   .IsRequired();
            builder.Property(x => x.Prescription)
                   .HasColumnType("VARCHAR")
                   .HasMaxLength(255)
                   .IsRequired();
            builder.Property(x => x.CreatedAt)
                   .HasColumnType("DATETIME")
                   .IsRequired();
            //builder.HasData(LoadData());
        }
    }
}
