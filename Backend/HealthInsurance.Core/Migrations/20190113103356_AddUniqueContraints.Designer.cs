﻿// <auto-generated />
using System;
using HealthInsurance.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HealthInsurance.Core.Migrations
{
    [DbContext(typeof(HealthInsuranceContext))]
    [Migration("20190113103356_AddUniqueContraints")]
    partial class AddUniqueContraints
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0-preview.18572.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HealthInsurance.Core.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("PostalCode")
                        .HasMaxLength(20);

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(70);

                    b.Property<string>("StreetNumber")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("HealthInsurance.Core.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<int?>("MedicineSpecialityId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<int>("OfficeId");

                    b.HasKey("Id");

                    b.HasIndex("MedicineSpecialityId");

                    b.HasIndex("OfficeId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("HealthInsurance.Core.Models.DoctorDepartment", b =>
                {
                    b.Property<int>("DoctorId");

                    b.Property<int>("DepartmentId");

                    b.HasKey("DoctorId", "DepartmentId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("DoctorDepartments");
                });

            modelBuilder.Entity("HealthInsurance.Core.Models.Experience", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Company")
                        .HasMaxLength(50);

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("Faculty")
                        .HasMaxLength(50);

                    b.Property<string>("Position")
                        .HasMaxLength(50);

                    b.Property<string>("School")
                        .HasMaxLength(50);

                    b.Property<DateTime>("StartDate");

                    b.Property<string>("University")
                        .HasMaxLength(50);

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Experiences");
                });

            modelBuilder.Entity("HealthInsurance.Core.Models.MedicineSpeciality", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("MedicineSpeciality");
                });

            modelBuilder.Entity("HealthInsurance.Core.Models.Office", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AddressId");

                    b.Property<string>("Description")
                        .HasMaxLength(500);

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<int?>("OwnerId");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.HasIndex("OwnerId");

                    b.ToTable("Offices");
                });

            modelBuilder.Entity("HealthInsurance.Core.Models.OfficeReview", b =>
                {
                    b.Property<int?>("AuthorId");

                    b.Property<int>("RecipientId");

                    b.Property<int>("Description")
                        .HasMaxLength(500);

                    b.Property<int>("Mark");

                    b.HasKey("AuthorId", "RecipientId");

                    b.HasIndex("RecipientId");

                    b.ToTable("OfficeReviews");
                });

            modelBuilder.Entity("HealthInsurance.Core.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AddressId");

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<int>("UserType")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("PhoneNumber")
                        .IsUnique();

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("HealthInsurance.Core.Models.UserReview", b =>
                {
                    b.Property<int?>("AuthorId");

                    b.Property<int>("RecipientId");

                    b.Property<int>("Description")
                        .HasMaxLength(500);

                    b.Property<int>("Mark");

                    b.HasKey("AuthorId", "RecipientId");

                    b.HasIndex("RecipientId");

                    b.ToTable("UserReviews");
                });

            modelBuilder.Entity("HealthInsurance.Core.Models.Department", b =>
                {
                    b.HasOne("HealthInsurance.Core.Models.MedicineSpeciality", "MedicineSpeciality")
                        .WithMany("Departments")
                        .HasForeignKey("MedicineSpecialityId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("HealthInsurance.Core.Models.Office", "Office")
                        .WithMany("Departments")
                        .HasForeignKey("OfficeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HealthInsurance.Core.Models.DoctorDepartment", b =>
                {
                    b.HasOne("HealthInsurance.Core.Models.Department", "Department")
                        .WithMany("DoctorDepartments")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HealthInsurance.Core.Models.User", "Doctor")
                        .WithMany("DoctorDepartments")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HealthInsurance.Core.Models.Experience", b =>
                {
                    b.HasOne("HealthInsurance.Core.Models.User", "User")
                        .WithMany("Experiences")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HealthInsurance.Core.Models.Office", b =>
                {
                    b.HasOne("HealthInsurance.Core.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("HealthInsurance.Core.Models.User", "Owner")
                        .WithMany("Offices")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("HealthInsurance.Core.Models.OfficeReview", b =>
                {
                    b.HasOne("HealthInsurance.Core.Models.User", "Author")
                        .WithMany("CreatedOfficeReviews")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("HealthInsurance.Core.Models.Office", "Recipient")
                        .WithMany("RecievedReviews")
                        .HasForeignKey("RecipientId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("HealthInsurance.Core.Models.User", b =>
                {
                    b.HasOne("HealthInsurance.Core.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("HealthInsurance.Core.Models.UserReview", b =>
                {
                    b.HasOne("HealthInsurance.Core.Models.User", "Author")
                        .WithMany("CreatedUserReviews")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("HealthInsurance.Core.Models.User", "Recipient")
                        .WithMany("RecievedReviews")
                        .HasForeignKey("RecipientId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
