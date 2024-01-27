using EmployeeManagement.Api.Model;
using EmployeeManagementModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace EmployeeManagement.Api.Controllers
{
    [Route("api/[controller]")]
    //Check the use of this
    [ApiController]
    public class EmployeesController : Controller
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetEmployees()
        {
            try
            {
                return Ok(await employeeRepository.GetEmployees());
            } catch (Exception ex)
            {
                //return StatusCode(500, ex.Message);
                //Or
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message + " Error retrieving data from the database.");
            }
        }

        [HttpGet("{search}")]
        public async Task<ActionResult<IEnumerable<Employee>>> Search(string name, Gender? gender)
        {
            try
            {
                var result = await employeeRepository.Search(name, gender);
                if (result.Any())
                {
                    return Ok(result);
                }
                return NotFound();
            }
            catch (Exception )
            {
                //return StatusCode(500, ex.Message);
                //Or
                return StatusCode(StatusCodes.Status500InternalServerError, " Error item saw not found in the database.");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            try {
                var result = await employeeRepository.GetEmployeeId(id);
                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, " Error retrieving data from the database.");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
        {
            try
            {
                if (employee == null)
                {
                    return BadRequest();
                }
                var emailComfirmation = employeeRepository.GetEmployeeIdEmail(employee.Email);
                if (emailComfirmation == null)
                {
                    ModelState.AddModelError("email", "This email is already in use....");
                    return BadRequest();
                }
                var CreateEmployee = await employeeRepository.AddEmployee(employee);
                return CreatedAtAction(nameof(GetEmployee), new { id = CreateEmployee.EmployeeId }, CreateEmployee);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, " Error retrieving data from the database.");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Employee>> UpdateEmployee(int id, Employee employee)
        {
            try
            {
                if (id != employee.EmployeeId)
                {
                    return BadRequest();
                }

                var employeeDetails = await employeeRepository.GetEmployeeId(id);
                if (employeeDetails == null)
                {
                    return NotFound();
                }
                return await employeeRepository.UpdateEmployee(employee);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, " Error updating the database.");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            try
            {
                var result = await employeeRepository.GetEmployeeId(id);
                if (result == null)
                {
                    return NotFound($"Employee with id = {id} not found");
                    //ModelState.AddModelError(string.Empty, "This id cannot be found in the database");
                }
                return await employeeRepository.DeleteEmployee(id);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, " Error deleting data from the database.");
            }
        }
    }
}
