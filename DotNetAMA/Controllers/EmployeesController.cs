using DotNetAMA.Data;
using DotNetAMA.Models;
using DotNetAMA.Svcs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetAMA.Controllers
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
