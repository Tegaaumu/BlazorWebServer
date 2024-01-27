using EmployeeManagementModels;

namespace EmployeeManagement.Api.Model
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetDepartments();
        Department GetDepartment(int departmentId);


    }
}
