using EmployeeManagementModels;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Api.Model
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDBContext appDBContext;

        public EmployeeRepository(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }
        public async Task<Employee> AddEmployee(Employee employee)
        {
            var result = await appDBContext.Employees.AddAsync(employee);
            await appDBContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Employee> DeleteEmployee(int employeeId)
        {
            var result = appDBContext.Employees.FirstOrDefault(id => id.EmployeeId == employeeId);

            if (result != null)
            {
                appDBContext.Employees.Remove(result);
                await appDBContext.SaveChangesAsync();
                return result;
            }
            return null;

        }

        public async Task<Employee> GetEmployeeId(int employeeId)
        {
            return await appDBContext.Employees
                .SingleOrDefaultAsync(e => e.EmployeeId == employeeId);
            //return await appDBContext.Employees
            //    .Include(e => e.Department)
            //    .SingleOrDefaultAsync(e => e.EmployeeId == employeeId);
            //To include more item you can chain them by writing Include() method
            //.ThenInclude(e => e.DepartmentId)

        }

        public async Task<Employee> GetEmployeeIdEmail(string email)
        {
            return await appDBContext.Employees.FirstOrDefaultAsync(id => id.Email == email);
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await appDBContext.Employees.ToListAsync();
        }

        public async Task<IEnumerable<Employee>> Search(string name, Gender? gender)
        {
            IQueryable<Employee> query = appDBContext.Employees;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.FirstName.Contains(name) || e.LastName.Contains(name));
            }
            if (gender != null)
            {
                query = query.Where(e => e.Gender == gender);
            }

            return await query.ToListAsync();
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var result = await appDBContext.Employees.FirstOrDefaultAsync(id => id.EmployeeId == employee.EmployeeId);

            if (result != null)
            {
                result.FirstName = employee.FirstName;
                result.LastName = employee.LastName;
                result.PhotoPath = employee.PhotoPath;
                result.DateOfBirth = employee.DateOfBirth;
                result.Email = employee.Email;
                result.Gender = employee.Gender;
                result.DepartmentId = employee.DepartmentId;

                await appDBContext.SaveChangesAsync();

                return result;
            }
            return null;
        }
    }
}
