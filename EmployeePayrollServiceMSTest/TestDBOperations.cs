using EmployeePayrollService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EmployeePayrollServiceMSTest
{
    [TestClass]
    public class TestDBOperations
    {
        /// <summary>
        /// UC11
        /// Tests the add employee.
        /// </summary>
        [TestMethod]
        public void TestAddEmployee()
        {
            //Arrange
            Employee employee = new Employee();
            employee.employeeID = 7;
            employee.employeeName = "Kathy";
            employee.gender = "F";
            employee.address = "NYC";
            employee.startDate = Convert.ToDateTime("2018-10-21");
            employee.departmentID = 7;
            employee.departmentName = "Acting";
            employee.BasicPay = 55000;
            //Act
            DBOperations.AddEmployee(employee);
            double actual = DBOperations.GetSalary("Kathy");
            double expected = 55000;
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
