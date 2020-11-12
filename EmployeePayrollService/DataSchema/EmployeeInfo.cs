﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePayrollService.DataSchema
{
    class EmployeeInfo
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public DateTime StartDate { get; set; }
    }
}
