using Dapper;
using DotNetAMA.Data;
using DotNetAMA.Models;
using DotNetAMA.Utils;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetAMA.Svcs
{
    public class EmployeeDapperService : IEmployee
    {
        private readonly SqlConnection _connection;

        public EmployeeDapperService(IConfiguration configuration)
        {
            _connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }

        public async Task<EmployeeInfo> GetEmployeeInfoAsync(int pageNo,
                                                    int itemsPerPage,
                                                    int numberLinksPerPage,
                                                    string searchName)
        {
            string sql = @"
SELECT EmployeeId, SortNo, FirstName, LastName, PositionName,
       OfficeLocation, Age, StartDate, Salary, ModifiedDate
FROM dbo.Employees";
            string totalSql = @"SELECT COUNT(*) FROM dbo.Employees";

            if (!string.IsNullOrWhiteSpace(searchName))
            {
                sql += $@"
WHERE FirstName LIKE '%{searchName}%'
   OR LastName LIKE '%{searchName}%' ";
            }

            sql += @" ORDER BY SortNo";

            IEnumerable<Employee> employees
                = await _connection.QueryAsync<Employee>(sql);
            int totalEmployeeCount = await _connection.QueryFirstAsync<int>(totalSql);

            var employeeInfo = new EmployeeInfo
            {
                Employees = employees
                             .Skip(itemsPerPage * (pageNo - 1))
                             .Take(itemsPerPage)
                             .ToList(),
                PagingInfo = new PagingInfo
                {
                    TotalEntries = totalEmployeeCount,
                    TotalItems = employees.ToList().Count,
                    NumberLinksPerPage = numberLinksPerPage,
                    CurrentPage = pageNo,
                    ItemsPerPage = itemsPerPage,
                    // 1페이지 : 1 => 7 * (1-1) + 1
                    // 2페이지 : 8 => 7 * (2-1) + 1
                    // 3페이지 : 15 => 14 + 1 = 7 * (3-1) + 1
                    FirstItem = itemsPerPage * (pageNo - 1) + 1,
                    LastItem = itemsPerPage * pageNo,
                    SearchName = searchName
                }
            };

            return employeeInfo;
        }

        public async Task<List<Employee>> GetEmployeesAsync()
        {
            string sql = @"
SELECT EmployeeId, SortNo, FirstName, LastName, PositionName,
       OfficeLocation, Age, StartDate, Salary, ModifiedDate
FROM dbo.Employees
ORDER BY SortNo";

            IEnumerable<Employee> employees = await _connection.QueryAsync<Employee>(sql);

            return employees.ToList();
        }
    }
}
