﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetAMA.V7.Models
{
    public class EmployeeAjaxInfo
    {
        public long RecordsTotal { get; set; }
        public object[] Data { get; set; }
    }
}
