using EmployeesManager.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EmployeesManager.DAL
{
    public class EmployeesManagerDbContext : IdentityDbContext<IdentityUser>
    {
        public EmployeesManagerDbContext(DbContextOptions<EmployeesManagerDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Employee>().HasMany(e => e.Educations).WithMany(e => e.Employees).UsingEntity(j => j.ToTable("EmployeeEducation"));
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Healthcare> Healthcares { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Clinic>? Clinics { get; set; }
        public DbSet<Institute>? Institutes { get; set; }
        public DbSet<Department>? Departments { get; set; }
        public DbSet<Workplace>? Workplaces { get; set; }
        public DbSet<EducationCategory> EducationCategories { get; set; }
        public DbSet<EducationType> EducationTypes { get; set; }
        public DbSet<ParticipationType> ParticipationTypes { get; set; }
    }
}