using EmployeesManager.Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeesManager.DAL
{
    public class EmployeesManagerDbContext : DbContext
    {
        public EmployeesManagerDbContext(DbContextOptions<EmployeesManagerDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasOne(a => a.Address).WithOne(e => e.Employee).HasForeignKey<Address>(e => e.EmployeeId);

            modelBuilder.Entity<Employee>().HasOne(c => c.Contact).WithOne(e => e.Employee).HasForeignKey<Contact>(e => e.EmployeeId);
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}