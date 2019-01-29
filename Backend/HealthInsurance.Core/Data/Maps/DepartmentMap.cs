using HealthInsurance.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthInsurance.Core.Data.Maps
{
    public static class DepartmentMap
    {
        public static void Map(EntityTypeBuilder<Department> builder)
        {
            // Table
            builder
                .ToTable("Departments");

            // Key
            builder
                .HasKey(department => department.Id);

            // Properties
            builder
                .Property(department => department.Name)
                .HasMaxLength(40)
                .IsRequired();

            builder
                .Property(department => department.Description)
                .HasMaxLength(1000)
                .IsRequired();

            // One-To-Many Relationship between Office and Departments
            builder
                .HasOne(department => department.Office)
                .WithMany(office => office.Departments)
                .HasForeignKey(department => department.OfficeId)
                .OnDelete(DeleteBehavior.Cascade);

            // One-To-Many Relationship between MedicineSpeciality and Departments
            builder
                .HasOne(department => department.MedicineSpeciality)
                .WithMany(medicineSpeciality => medicineSpeciality.Departments)
                .HasForeignKey(department => department.MedicineSpecialityId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
