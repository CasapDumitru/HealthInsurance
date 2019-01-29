using HealthInsurance.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthInsurance.Core.Data.Maps
{
    public static class DoctorDepartmentMap
    {
        public static void Map(EntityTypeBuilder<DoctorDepartment> builder)
        {
            // Table
            builder
                .ToTable("DoctorDepartments");

            // Key
            builder
                .HasKey(doctorDepartment =>  new { doctorDepartment.DoctorId, doctorDepartment.DepartmentId });

            // Many-To-Many Relationship between Doctor and Department
            builder
                .HasOne(doctorDepartment => doctorDepartment.Doctor)
                .WithMany(doctor => doctor.DoctorDepartments)
                .HasForeignKey(doctorDepartment => doctorDepartment.DoctorId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(doctorDepartment => doctorDepartment.Department)
                .WithMany(department => department.DoctorDepartments)
                .HasForeignKey(doctorDepartment => doctorDepartment.DepartmentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
