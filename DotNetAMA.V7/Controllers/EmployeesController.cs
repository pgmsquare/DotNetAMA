using DotNetAMA.V7.Data;
using DotNetAMA.V7.Models;
using DotNetAMA.V7.Svcs;
using Microsoft.AspNetCore.Mvc;

namespace DotNetAMA.V7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployee _employee;

        public EmployeesController(IEmployee employee)
        {
            _employee = employee;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK,
                              Type = typeof(EmployeeAjaxInfo))]
        public async Task<IActionResult> GetAsync()
        {
            List<Employee> employees = await _employee.GetEmployeesAsync();

            var employeeAjaxInfo = new EmployeeAjaxInfo
            {
                RecordsTotal = employees.Count(),
                Data = employees.ToArray()
            };

            return Ok(employeeAjaxInfo);
        }
    }
}
