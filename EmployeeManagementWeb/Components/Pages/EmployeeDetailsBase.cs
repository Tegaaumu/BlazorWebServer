using EmployeeManagementModels;
using EmployeeManagementWeb.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using static Azure.Core.HttpHeader;

namespace EmployeeManagementWeb.Components.Pages
{
    public class EmployeeDetailsBase : ComponentBase
    {
        public Employee employee { get; set; } = new Employee();
        public string Cordinate { get; set; } = "Tega max";

        [Inject]
        public IEmployeeServices employeeServices { get; set; }

        [Parameter]
        public string id { get; set; }

        protected async override  Task OnInitializedAsync()
        {
            //If no value is been passed.
            id = id ?? "1";
            employee = await employeeServices.GetEmployee(int.Parse(id));
        }
        //public void Move_Mouse(MouseEventArgs e)
        //{
        //    Cordinate = $"X = {e.ClientX} and Y = {e.ClientY}";
        //}
    }
}
