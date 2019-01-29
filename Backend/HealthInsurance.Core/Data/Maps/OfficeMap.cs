using HealthInsurance.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthInsurance.Core.Data.Maps
{
    public static class OfficeMap
    {
        public static void Map(EntityTypeBuilder<Office> builder)
        {
            // Table
            builder
                .ToTable("Offices");

            // Key
            builder
                .HasKey(office => office.Id);

            // Properties
            builder
                .Property(office => office.Name)
                .HasMaxLength(50)
                .IsRequired();


            builder
                .Property(office => office.Description)
                .HasMaxLength(1500)
                .IsRequired();

            // Indexes
            builder
                .HasIndex(office => office.Name)
                .IsUnique();

            // One-To-Many Relationship between Address and Offices
            builder
                .HasOne(office => office.Address)
                .WithMany()
                .HasForeignKey(office => office.AddressId)
                .OnDelete(DeleteBehavior.SetNull);

            // One-To-Many Relationship between Owner and Offices
            builder
                .HasOne(office => office.Owner)
                .WithMany(user => user.Offices)
                .HasForeignKey(office => office.OwnerId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
