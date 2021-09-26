using DotNetAMA.Data;
using DotNetAMA.Models;
using DotNetAMA.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetAMA.Svcs
{
    public interface IEmployee
    {
        Task<List<Employee>> GetEmployeesAsync();
        Task<EmployeeInfo> GetEmployeeInfoAsync(int pageNo,
                                                int itemsPerPage,
                                                int numberLinksPerPage,
                                                string searchName);
    }
}
