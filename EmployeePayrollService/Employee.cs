using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePayrollService
{
    public class Employee
    {
        public int employeeID { get; set; }
        public string employeeName { get; set; }
        public string gender { get; set; }
        public string address { get; set; }
        public DateTime startDate { get; set; }
        public int departmentID { get; set; }
        public string departmentName { get; set; }
        public double BasicPay { get; set; }

        public Employee()
        {

        }
    }
}
