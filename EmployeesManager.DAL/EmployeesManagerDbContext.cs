﻿using EmployeesManager.Model;
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

            //modelBuilder.Entity<Employee>().HasOne(c => c.Contact).WithOne(e => e.Employee).HasForeignKey<Contact>(e => e.EmployeeId);

            //modelBuilder.Entity<Healthcare>().HasOne(h => h.Employee).WithMany(e => e.Healthcares);
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Healthcare> Healthcares { get; set; }
    }
}