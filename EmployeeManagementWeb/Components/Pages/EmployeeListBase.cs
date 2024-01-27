using EmployeeManagementModels;
using EmployeeManagementWeb.Services;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagementWeb.Components.Pages
{
    public class EmployeeListBase: ComponentBase
    {
        [Inject]
        public IEmployeeServices EmployeeServices { get; set; }
        //public IEnumerable<Employee> Employees { get; set; } = Enumerable.Empty<Employee>();
        public IEnumerable<Employee>? Employees { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Employees = (await EmployeeServices.GetEmployees()).ToList();   
            //await Task.Run(LoadEmployee);
        }

        //private void LoadEmployee()
        //{
        //    System.Threading.Thread.Sleep(3000);
        //    Employee e1 = new Employee { 
        //        EmployeeId = 1,
        //        FirstName="sam",
        //        LastName="Gallary",
        //        Email="samgallary@gmail.com",
        //        DateOfBirth = new DateTime(2000,1, 31),
        //        Gender= Gender.Male,
        //        DepartmentId=1012,
        //        PhotoPath = "Images/OIP (1).jpg"
        //    };
        //    Employee e2 = new Employee
        //    {
        //        EmployeeId = 2,
        //        FirstName = "John",
        //        LastName = "Ben",
        //        Email = "johnben@gmail.com",
        //        DateOfBirth = new DateTime(2100, 1, 31),
        //        Gender = Gender.Male,
        //        DepartmentId = 3443,
        //        PhotoPath = "Images/OIP (4).jpg"
        //    };
        //    Employee e3 = new Employee
        //    {
        //        EmployeeId = 3,
        //        FirstName = "Mary",
        //        LastName = "Smith",
        //        Email = "marysmith@gmail.com",
        //        DateOfBirth = new DateTime(1987, 1, 31),
        //        Gender = Gender.Female,
        //        DepartmentId = 4556,
        //        PhotoPath = "Images/OIP.jpg"
        //    };
        //    Employee e4 = new Employee
        //    {
        //        EmployeeId = 3,
        //        FirstName = "Lucky",
        //        LastName = "James",
        //        Email = "luckyjames@gmail.com",
        //        DateOfBirth = new DateTime(2000, 11, 3),
        //        Gender = Gender.Other,
        //        DepartmentId = 6554,
        //        PhotoPath = "Images/istockphoto-144966477-612x612.jpg"
        //    };
        //    Employees = new List<Employee>() { e1, e2, e3, e4};
        //}
    }
}
