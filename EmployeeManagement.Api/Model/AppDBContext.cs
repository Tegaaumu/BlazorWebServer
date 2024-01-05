using EmployeeManagementModels;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Api.Model
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees {get; set;}
        public DbSet<Department> Departments { get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configure DbContext options here
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.EnableSensitiveDataLogging(); // Enable sensitive data logging
            }
        }

        //Seed data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 1, DepartmentName = "IT" }
                );
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 2, DepartmentName = "HR" }
                );
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 3, DepartmentName = "Payroll" }
                );
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 4, DepartmentName = "Admin" }
                );

            //Seed employee table
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    EmployeeId = 1,
                    FirstName = "sam",
                    LastName = "Gallary",
                    Email = "samgallary@gmail.com",
                    DateOfBirth = new DateTime(2000, 1, 31),
                    Gender = Gender.Male,
                    DepartmentId = 1012,
                    PhotoPath = "Images/OIP (1).jpg"
                }
                );
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    EmployeeId = 2,
                    FirstName = "John",
                    LastName = "Ben",
                    Email = "johnben@gmail.com",
                    DateOfBirth = new DateTime(2100, 1, 31),
                    Gender = Gender.Male,
                    DepartmentId = 3443,
                    PhotoPath = "Images/OIP (4).jpg"
                }
                );
            modelBuilder.Entity<Employee>().HasData(
               new Employee
               {
                   EmployeeId = 3,
                   FirstName = "Mary",
                   LastName = "Smith",
                   Email = "marysmith@gmail.com",
                   DateOfBirth = new DateTime(1987, 1, 31),
                   Gender = Gender.Female,
                   DepartmentId = 4556,
                   PhotoPath = "Images/OIP.jpg"
               }
                );
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    EmployeeId = 4,
                    FirstName = "Lucky",
                    LastName = "James",
                    Email = "luckyjames@gmail.com",
                    DateOfBirth = new DateTime(2000, 11, 3),
                    Gender = Gender.Other,
                    DepartmentId = 6554,
                    PhotoPath = "Images/istockphoto-144966477-612x612.jpg"
                }
                );


        }

    }
}
