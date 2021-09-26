using DotNetAMA.Models;
using DotNetAMA.Svcs;
using DotNetAMA.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetAMA.Controllers
{
    public class HRController : Controller
    {
        private readonly IEmployee _employee;
        private readonly IConfiguration _configuration;

        public HRController(IEmployee employee,
                            IConfiguration configuration)
        {
            _employee = employee;
            _configuration = configuration;
        }

        [HttpGet("/{controller}/Index")]
        public async Task<IActionResult> IndexAsync()
        {
            var employeeInfo = new EmployeeInfo
            {
                Employees = await _employee.GetEmployeesAsync()
            };
            return View(employeeInfo);
        }

        public IActionResult Ajax()
        {
            return View();
        }

        [HttpGet("/{controller}/List/{PageNo?}/{PageSize?}/{SearchName?}")]
        public async Task<IActionResult> ListAsync(int pageNo = 1,
                                                   int? pageSize = null,
                                                   string searchName = null)
        {
            int itemsPerPage = pageSize != null && pageSize > 0 ?
                               Convert.ToInt32(pageSize) :
                               int.Parse(_configuration["Paging:ItemsPerPage"]);
            int numberLinksPerPage = int.Parse(_configuration["Paging:NumberLinksPerPage"]); ;

            var employeeInfo = 
                await _employee.GetEmployeeInfoAsync(pageNo,
                                                     itemsPerPage,
                                                     numberLinksPerPage,
                                                     searchName);

            return View("List", employeeInfo);
        }

        [HttpPost("/{controller}/List/{PageNo?}/{PageSize?}/{SearchName?}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ListAsync(PagingInfo pagingInfo)
        {
            if (!ModelState.IsValid
                && !string.IsNullOrWhiteSpace(pagingInfo.SearchName))
            {
                ModelState.AddModelError(string.Empty, "검색명을 올바르게 입력하세요.");

                var employeeInfo =
                    await _employee.GetEmployeeInfoAsync(pagingInfo.CurrentPage,
                                                         pagingInfo.ItemsPerPage,
                                                         pagingInfo.NumberLinksPerPage,
                                                         pagingInfo.SearchName);

                return View("List", employeeInfo);
            }

            return RedirectToAction("List", new { pageNo = pagingInfo.CurrentPage,
                                                  pageSize = pagingInfo.ItemsPerPage,
                                                  searchName = pagingInfo.SearchName});
        }
    }
}
