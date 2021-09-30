using DotNetAMA.V7.Data;
using DotNetAMA.V7.Models;
using DotNetAMA.V7.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetAMA.V7.Svcs
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
