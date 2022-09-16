﻿// <auto-generated />
using System;
using EmployeesManager.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EmployeesManager.DAL.Migrations
{
    [DbContext(typeof(EmployeesManagerDbContext))]
    [Migration("20220914150236_DepartmentUpdate")]
    partial class DepartmentUpdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EducationEmployee", b =>
                {
                    b.Property<int>("EducationsEducationId")
                        .HasColumnType("int");

                    b.Property<int>("EmployeesEmployeeId")
                        .HasColumnType("int");

                    b.HasKey("EducationsEducationId", "EmployeesEmployeeId");

                    b.HasIndex("EmployeesEmployeeId");

                    b.ToTable("EmployeeEducation", (string)null);
                });

            modelBuilder.Entity("EmployeesManager.Model.Clinic", b =>
                {
                    b.Property<int>("ClinicId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClinicId"), 1L, 1);

                    b.Property<string>("HeadClinic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Location")
                        .HasColumnType("int");

                    b.Property<string>("NameLong")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameShort")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClinicId");

                    b.ToTable("Clinics");
                });

            modelBuilder.Entity("EmployeesManager.Model.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartmentId"), 1L, 1);

                    b.Property<string>("ActivityCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExpenseCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HeadDepartmentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("InstituteId")
                        .HasColumnType("int");

                    b.Property<string>("NameLong")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameShort")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DepartmentId");

                    b.HasIndex("InstituteId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("EmployeesManager.Model.Education", b =>
                {
                    b.Property<int>("EducationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EducationId"), 1L, 1);

                    b.Property<DateTime>("BeginDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EducationCategory")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EducationCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("EducationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EducationType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EducationTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Mandatory")
                        .HasColumnType("bit");

                    b.Property<string>("ParticipationType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParticipationTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Remark")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EducationId");

                    b.HasIndex("EducationCategoryId");

                    b.HasIndex("EducationTypeId");

                    b.HasIndex("ParticipationTypeId");

                    b.ToTable("Educations");
                });

            modelBuilder.Entity("EmployeesManager.Model.EducationCategory", b =>
                {
                    b.Property<int>("EducationCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EducationCategoryId"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EducationCategoryId");

                    b.ToTable("EducationCategories");
                });

            modelBuilder.Entity("EmployeesManager.Model.EducationType", b =>
                {
                    b.Property<int>("EducationTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EducationTypeId"), 1L, 1);

                    b.Property<string>("EducationTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EducationTypeId");

                    b.ToTable("EducationTypes");
                });

            modelBuilder.Entity("EmployeesManager.Model.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"), 1L, 1);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("BusinessEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BusinessMobilePhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BusinessTelephone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MBO")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OIB")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PostalCode")
                        .HasColumnType("int");

                    b.Property<string>("PrivateEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrivateMobilePhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("EmployeesManager.Model.Healthcare", b =>
                {
                    b.Property<int>("HealthcareId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HealthcareId"), 1L, 1);

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("HealthcareName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Remark")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ValidUntil")
                        .HasColumnType("datetime2");

                    b.HasKey("HealthcareId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Healthcares");
                });

            modelBuilder.Entity("EmployeesManager.Model.Institute", b =>
                {
                    b.Property<int>("InstituteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InstituteId"), 1L, 1);

                    b.Property<int?>("ClinicId")
                        .HasColumnType("int");

                    b.Property<string>("ExpenseCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HeadInstitute")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameLong")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameShort")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InstituteId");

                    b.HasIndex("ClinicId");

                    b.ToTable("Institutes");
                });

            modelBuilder.Entity("EmployeesManager.Model.ParticipationType", b =>
                {
                    b.Property<int>("ParticipationTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ParticipationTypeId"), 1L, 1);

                    b.Property<string>("ParticipationTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ParticipationTypeId");

                    b.ToTable("ParticipationTypes");
                });

            modelBuilder.Entity("EmployeesManager.Model.Workplace", b =>
                {
                    b.Property<int>("WorkplaceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WorkplaceId"), 1L, 1);

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("ExpenseCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameLong")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameShort")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WorkplaceId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Workplaces");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("EducationEmployee", b =>
                {
                    b.HasOne("EmployeesManager.Model.Education", null)
                        .WithMany()
                        .HasForeignKey("EducationsEducationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmployeesManager.Model.Employee", null)
                        .WithMany()
                        .HasForeignKey("EmployeesEmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EmployeesManager.Model.Department", b =>
                {
                    b.HasOne("EmployeesManager.Model.Institute", "Institute")
                        .WithMany("Departments")
                        .HasForeignKey("InstituteId");

                    b.Navigation("Institute");
                });

            modelBuilder.Entity("EmployeesManager.Model.Education", b =>
                {
                    b.HasOne("EmployeesManager.Model.EducationCategory", null)
                        .WithMany("Education")
                        .HasForeignKey("EducationCategoryId");

                    b.HasOne("EmployeesManager.Model.EducationType", null)
                        .WithMany("Education")
                        .HasForeignKey("EducationTypeId");

                    b.HasOne("EmployeesManager.Model.ParticipationType", null)
                        .WithMany("Education")
                        .HasForeignKey("ParticipationTypeId");
                });

            modelBuilder.Entity("EmployeesManager.Model.Healthcare", b =>
                {
                    b.HasOne("EmployeesManager.Model.Employee", "Employee")
                        .WithMany("Healthcares")
                        .HasForeignKey("EmployeeId");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("EmployeesManager.Model.Institute", b =>
                {
                    b.HasOne("EmployeesManager.Model.Clinic", "Clinic")
                        .WithMany("Institutes")
                        .HasForeignKey("ClinicId");

                    b.Navigation("Clinic");
                });

            modelBuilder.Entity("EmployeesManager.Model.Workplace", b =>
                {
                    b.HasOne("EmployeesManager.Model.Department", "Department")
                        .WithMany("Workplaces")
                        .HasForeignKey("DepartmentId");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EmployeesManager.Model.Clinic", b =>
                {
                    b.Navigation("Institutes");
                });

            modelBuilder.Entity("EmployeesManager.Model.Department", b =>
                {
                    b.Navigation("Workplaces");
                });

            modelBuilder.Entity("EmployeesManager.Model.EducationCategory", b =>
                {
                    b.Navigation("Education");
                });

            modelBuilder.Entity("EmployeesManager.Model.EducationType", b =>
                {
                    b.Navigation("Education");
                });

            modelBuilder.Entity("EmployeesManager.Model.Employee", b =>
                {
                    b.Navigation("Healthcares");
                });

            modelBuilder.Entity("EmployeesManager.Model.Institute", b =>
                {
                    b.Navigation("Departments");
                });

            modelBuilder.Entity("EmployeesManager.Model.ParticipationType", b =>
                {
                    b.Navigation("Education");
                });
#pragma warning restore 612, 618
        }
    }
}
