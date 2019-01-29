using HealthInsurance.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthInsurance.Core.Data.Maps
{
    public static class ExperienceMap
    {
        public static void Map(EntityTypeBuilder<Experience> builder)
        {
            // Table
            builder
                .ToTable("Experiences");

            // Key
            builder
                .HasKey(experience => experience.Id);

            // Properties
            builder
                .Property(experience => experience.StartDate)
                .IsRequired();

            builder
                .Property(experience => experience.EndDate)
                .IsRequired();

            builder
                .Property(experience => experience.School)
                .HasMaxLength(50);

            builder
                .Property(experience => experience.University)
                .HasMaxLength(50);

            builder
                .Property(experience => experience.Faculty)
                .HasMaxLength(50);

            builder
                .Property(experience => experience.Company)
                .HasMaxLength(50);

            builder
                .Property(experience => experience.Position)
                .HasMaxLength(50);

            // One-To-Many Relationship between User and Experiences
            builder
                .HasOne(experience => experience.User)
                .WithMany(user => user.Experiences)
                .HasForeignKey(experience => experience.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
