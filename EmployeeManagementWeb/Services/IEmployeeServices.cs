using EmployeeManagementModels;

namespace EmployeeManagementWeb.Services
{
    public interface IEmployeeServices
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployee(int id);
    }
}
