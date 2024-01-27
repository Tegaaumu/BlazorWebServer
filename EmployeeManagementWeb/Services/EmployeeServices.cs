using EmployeeManagementModels;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagementWeb.Services
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly HttpClient httpClient;

        public EmployeeServices(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Employee> GetEmployee(int id)
        {
            try
            {
                return await httpClient.GetFromJsonAsync<Employee>($"api/employees/{id}");
            }
            catch (HttpRequestException ex)
            {
                // Handle exception (log, display an error message, etc.)
                Console.WriteLine($"Error: {ex.Message}");
                throw; // Rethrow the exception or handle it as needed
            }
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await httpClient.GetFromJsonAsync<Employee[]>("api/employees");
        }
    }
}

