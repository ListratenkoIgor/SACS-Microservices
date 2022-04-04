using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Interfaces.Models;

namespace DataService.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<EducationForm> EducationForms { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Speciality> Specialities { get; set; }
        public DbSet<StudentsGroup> StudentsGroups { get; set; }
        public DbSet<Student> Students { get; set; }
        //public DbSet<Account> Accounts { get; set; }
        //public DbSet<RelatedAccount> RelatedAccount { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //builder.Entity<Department>()   .HasNoKey().ToTable("Departments");
            //builder.Entity<EducationForm>().HasNoKey().ToTable("EducationForms");
            //builder.Entity<Employee>()     .HasNoKey().ToTable("Employees");
            //builder.Entity<Faculty>()      .HasNoKey().ToTable("Faculties");
            //builder.Entity<Speciality>()   .HasNoKey().ToTable("Specialities");
            //builder.Entity<StudentsGroup>().HasNoKey().ToTable("StudentsGroups");
            //builder.Entity<Student>()      .HasNoKey().ToTable("Students");
        }
    }
}
