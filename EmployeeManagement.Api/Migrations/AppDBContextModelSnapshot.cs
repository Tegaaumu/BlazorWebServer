﻿// <auto-generated />
using System;
using EmployeeManagement.Api.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EmployeeManagement.Api.Migrations
{
    [DbContext(typeof(AppDBContext))]
    partial class AppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EmployeeManagementModels.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartmentId"));

                    b.Property<string>("DepartmentName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DepartmentId");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            DepartmentId = 1,
                            DepartmentName = "IT"
                        },
                        new
                        {
                            DepartmentId = 2,
                            DepartmentName = "HR"
                        },
                        new
                        {
                            DepartmentId = 3,
                            DepartmentName = "Payroll"
                        },
                        new
                        {
                            DepartmentId = 4,
                            DepartmentName = "Admin"
                        });
                });

            modelBuilder.Entity("EmployeeManagementModels.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoPath")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmployeeId = 1,
                            DateOfBirth = new DateTime(2000, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DepartmentId = 1012,
                            Email = "samgallary@gmail.com",
                            FirstName = "sam",
                            Gender = 0,
                            LastName = "Gallary",
                            PhotoPath = "Images/OIP (1).jpg"
                        },
                        new
                        {
                            EmployeeId = 2,
                            DateOfBirth = new DateTime(2100, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DepartmentId = 3443,
                            Email = "johnben@gmail.com",
                            FirstName = "John",
                            Gender = 0,
                            LastName = "Ben",
                            PhotoPath = "Images/OIP (4).jpg"
                        },
                        new
                        {
                            EmployeeId = 3,
                            DateOfBirth = new DateTime(1987, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DepartmentId = 4556,
                            Email = "marysmith@gmail.com",
                            FirstName = "Mary",
                            Gender = 1,
                            LastName = "Smith",
                            PhotoPath = "Images/OIP.jpg"
                        },
                        new
                        {
                            EmployeeId = 4,
                            DateOfBirth = new DateTime(2000, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DepartmentId = 6554,
                            Email = "luckyjames@gmail.com",
                            FirstName = "Lucky",
                            Gender = 2,
                            LastName = "James",
                            PhotoPath = "Images/istockphoto-144966477-612x612.jpg"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
