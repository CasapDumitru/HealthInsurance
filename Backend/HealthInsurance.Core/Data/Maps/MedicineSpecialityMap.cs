using HealthInsurance.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthInsurance.Core.Data.Maps
{
    public static class MedicineSpecialityMap
    {
        public static void Map(EntityTypeBuilder<MedicineSpeciality> builder)
        {
            // Table
            builder
                .ToTable("MedicineSpeciality");

            // Key
            builder
                .HasKey(speciality => speciality.Id);

            // Properties
            builder
                .Property(speciality => speciality.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(speciality => speciality.Description)
                .HasMaxLength(1000)
                .IsRequired();

            // Indexes
            builder
                .HasIndex(speciality => speciality.Name)
                .IsUnique();
        }
    }
}
