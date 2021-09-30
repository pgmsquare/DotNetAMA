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
            if (!ModelState.IsValid)
            {
                if (pagingInfo.CurrentPage < 1)
                {
                    ModelState.AddModelError("Info", "현재 페이지 정보를 올바르게 입력하세요.");
                }

                if (pagingInfo.ItemsPerPage < 1)
                {
                    ModelState.AddModelError("Info", "페이지 데이터 개수 정보를 올바르게 입력하세요.");
                }

                ModelState.AddModelError("Info", "페이징 정보를 올바르게 입력하세요.");

                var employeeInfo =
                await _employee.GetEmployeeInfoAsync(pagingInfo.CurrentPage,
                                                     pagingInfo.ItemsPerPage,
                                                     int.Parse(_configuration["Paging:NumberLinksPerPage"]),
                                                     pagingInfo.SearchName);

                return View("List", employeeInfo);
            }

            return RedirectToAction("List", "HR",
                                    new { PageNo = pagingInfo.CurrentPage,
                                          PageSize = pagingInfo.ItemsPerPage,
                                          SearchName = pagingInfo.SearchName });
        }
    }
}
