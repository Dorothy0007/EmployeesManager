using EmployeesManager.Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeesManager.DAL
{
    public class EmployeesManagerDbContext : DbContext
    {
        public EmployeesManagerDbContext(DbContextOptions<EmployeesManagerDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Employee> Addresses { get; set; }
        public DbSet<Employee> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Address>().HasKey(a => a.EmployeeId);

            //modelBuilder.Entity<Contact>().HasKey(c => c.EmployeeId);

            //modelBuilder.Entity<Employee>().HasOne<Address>(emp => emp.Address)
            //    .WithOne(a => a.Employee);

            //modelBuilder.Entity<Employee>().HasOne<Contact>(emp => emp.Contact)
            //    .WithOne(c => c.Employee);
        }
    }
}