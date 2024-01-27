using EmployeeManagementModels;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Api.Model
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDBContext appDBContext;

        public DepartmentRepository(AppDBContext appDBContext) {
            this.appDBContext = appDBContext;
        }
        public Department GetDepartment(int departmentId)
        {
            return appDBContext.Departments.FirstOrDefault(e => e.DepartmentId == departmentId);
        }

        public IEnumerable<Department> GetDepartments()
        {
            return appDBContext.Departments;
        }
    }
}
