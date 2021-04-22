using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;

namespace EmployeeDatabase
{
    class EmployeeDatabase
    {
        // Keep a *private* copy of the employee list.
        //
        // We make this private since we don't want code from
        // outside this class to have access to it. All access
        // to this information comes through the methods of the
        // class.
        private List<Employee> employees = new List<Employee>();

        // Given an argument of an employee, add that employee
        // to the list of employees we are managing.
        public void AddEmployee(Employee newEmployee)
        {
            employees.Add(newEmployee);
        }

        public Employee FindEmployee(string name)
        {
            // Make a new variable to store the found employee, initializing
            // to null which will indicate no match found
            Employee foundEmployee = employees.FirstOrDefault(employee => employee.Name == name);

            return foundEmployee;
        }

        // Get a list of all the employees
        public List<Employee> GetAllEmployees()
        {
            return employees;
        }

        // Remove an employee
        public void RemoveEmployee(Employee employeeToRemove)
        {
            employees.Remove(employeeToRemove);
        }

        public void LoadEmployeesFromCSV()
        {
            // Load the list of employees
        }

        public void SaveEmployeesToCSV()
        {
            // Save the list of employees
            var fileWriter = new StreamWriter("employees.csv");
            var csvWriter = new CsvWriter(fileWriter, CultureInfo.InvariantCulture);
            csvWriter.WriteRecords(employees);
            fileWriter.Close();
        }
    }
}
