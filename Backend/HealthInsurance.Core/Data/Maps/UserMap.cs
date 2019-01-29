using HealthInsurance.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthInsurance.Core.Data.Maps
{
    public static class UserMap
    {
        public static void Map(EntityTypeBuilder<User> builder)
        {
            // Table
            builder
                .ToTable("Users");

            // Key
            builder.
                HasKey(user => user.Id);

            // Properties
            builder
                .Property(user => user.UserType)
                .HasDefaultValue(UserType.None)
                .IsRequired();

            builder
                .Property(user => user.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(user => user.LastName)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(user => user.BirthDate)
                .IsRequired();

            builder
                .Property(user => user.PhoneNumber)
                .HasMaxLength(20)
                .IsRequired();

            builder
                .Property(user => user.Email)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(user => user.UserName)
                .HasMaxLength(30)
                .IsRequired();

            builder
                .Property(user => user.Password)
                .HasMaxLength(30)
                .IsRequired();

            // Indexes
            builder
                .HasIndex(user => user.PhoneNumber)
                .IsUnique();

            builder
                .HasIndex(user => user.Email)
                .IsUnique();

            builder
                .HasIndex(user => user.UserName)
                .IsUnique();

            // One-To-Many Relationship between Address and Users
            builder
                .HasOne(user => user.Address)
                .WithMany()
                .HasForeignKey(user => user.AddressId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
