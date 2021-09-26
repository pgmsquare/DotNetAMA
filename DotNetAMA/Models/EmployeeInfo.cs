using DotNetAMA.Data;
using DotNetAMA.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetAMA.Models
{
    public class EmployeeInfo
    {
        public List<Employee> Employees = new List<Employee>();
        public PagingInfo PagingInfo { get; set; }
    }
}
