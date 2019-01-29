using HealthInsurance.Core.AppConfig;
using HealthInsurance.Core.Data.Maps;
using HealthInsurance.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace HealthInsurance.Core.Data
{
    public class HealthInsuranceContext : DbContext
    {
        public HealthInsuranceContext(DbContextOptions<HealthInsuranceContext> options) : base(options)
        {
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<DoctorDepartment> DoctorDepartments { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<MedicineSpeciality> MedicineSpecialities { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<OfficeReview> OfficeReviews { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserReview> UserReviews { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var appConfig = new AppConfiguration();
            var connectionString = appConfig.ConnectionString;
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            AddressMap.Map(modelBuilder.Entity<Address>());
            DepartmentMap.Map(modelBuilder.Entity<Department>());
            DoctorDepartmentMap.Map(modelBuilder.Entity<DoctorDepartment>());
            ExperienceMap.Map(modelBuilder.Entity<Experience>());
            MedicineSpecialityMap.Map(modelBuilder.Entity<MedicineSpeciality>());
            OfficeMap.Map(modelBuilder.Entity<Office>());
            OfficeReviewMap.Map(modelBuilder.Entity<OfficeReview>());
            UserMap.Map(modelBuilder.Entity<User>());
            UserReviewMap.Map(modelBuilder.Entity<UserReview>());
        }
    }
}
