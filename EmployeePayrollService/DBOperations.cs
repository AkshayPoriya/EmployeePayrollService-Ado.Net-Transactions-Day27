﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DBOperations.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Akshay Poriya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace EmployeePayrollService
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Text;

    public class DBOperations
    {
        /// <summary>
        /// UC11
        /// Adds the employee.
        /// </summary>
        /// <param name="employee">The employee.</param>
        /// <exception cref="Exception"></exception>
        public static void AddEmployee(Employee employee)
        {
            SqlConnection sqlConnection = DBConnection.GetConnection();
            try
            {
                using (sqlConnection)
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand("dbo.spAddNewEmployee", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@employee_id", employee.employeeID);
                    sqlCommand.Parameters.AddWithValue("@employee_name", employee.employeeName);
                    sqlCommand.Parameters.AddWithValue("@gender", employee.gender);
                    sqlCommand.Parameters.AddWithValue("@address", employee.address);
                    sqlCommand.Parameters.AddWithValue("@start_date", employee.startDate);
                    sqlCommand.Parameters.AddWithValue("@department_id", employee.departmentID);
                    sqlCommand.Parameters.AddWithValue("@department_name", employee.departmentName);
                    sqlCommand.Parameters.AddWithValue("@basic_pay", employee.BasicPay);
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
        }

        public static double GetSalary(string name)
        {
            SqlConnection sqlConnection = DBConnection.GetConnection();
            try
            {
                using (sqlConnection)
                {
                    sqlConnection.Open();
                    string query = @"select p.basic_pay from dbo.payroll p 
                                    where p.emp_id = (select e.id from employee e where name=@name)";
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@name", name);
                    double basicPay = (double)sqlCommand.ExecuteScalar();
                    return basicPay;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
        }

        /// <summary>
        /// UC12
        /// Removes the employee.
        /// </summary>
        /// <param name="empId">The emp identifier.</param>
        /// <param name="deptID">The dept identifier.</param>
        /// <exception cref="Exception"></exception>
        public static void RemoveEmployee(int empId, int deptID)
        {
            SqlConnection sqlConnection = DBConnection.GetConnection();
            try
            {
                using (sqlConnection)
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand("dbo.spRemoveEmployee", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@employee_id", empId);
                    sqlCommand.Parameters.AddWithValue("@dept_id", deptID);
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
        }

        public static string GetActiveStatus(int emp_id)
        {
            SqlConnection sqlConnection = DBConnection.GetConnection();
            try
            {
                using (sqlConnection)
                {
                    sqlConnection.Open();
                    string query = @"select p.is_active from dbo.payroll p 
                                    where p.emp_id = @emp_id";
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@emp_id", emp_id);
                    string isActive = (string)sqlCommand.ExecuteScalar();
                    return isActive;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
        }
    }
}
