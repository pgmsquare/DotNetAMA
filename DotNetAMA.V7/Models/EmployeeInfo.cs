using DotNetAMA.V7.Data;
using DotNetAMA.V7.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetAMA.V7.Models
{
    public class EmployeeInfo
    {
        public List<Employee> Employees = new List<Employee>();
        public PagingInfo PagingInfo { get; set; }
    }
}
