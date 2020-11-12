using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePayrollService.DataSchema
{
    class EmployeeDepartment
    {
        public int EmployeeID { get; set; }
        public List<int> DepartmentId { get; set; }
    }
}
