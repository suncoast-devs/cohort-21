using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeDatabase
{
    class Employee
    {
        public string Name { get; set; }
        public int Department { get; set; }
        public int Salary { get; set; }

        public int MonthlySalary()
        {
            return Salary / 12;
        }
    }

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
    }

    class Program
    {
        static void DisplayGreeting()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("    Welcome to Our Employee Database    ");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine();
            Console.WriteLine();
        }

        static string PromptForString(string prompt)
        {
            Console.Write(prompt);
            var userInput = Console.ReadLine();
            return userInput;
        }

        static int PromptForInteger(string prompt)
        {
            Console.Write(prompt);
            int userInput;
            var isThisGoodInput = Int32.TryParse(Console.ReadLine(), out userInput);
            if (isThisGoodInput)
            {
                return userInput;
            }
            else
            {
                Console.WriteLine("Sorry, that isn't a valid input, I'm using 0 as your answer.");
                return 0;
            }
        }

        static void Main(string[] args)
        {
            var employees = new List<Employee>();

            DisplayGreeting();

            var keepGoing = true;

            while (keepGoing)
            {
                // Inert a blank line then prompt them and get their answer (force uppercase)
                // Console.Clear();
                Console.WriteLine();
                Console.Write("What do you want to do? (A)dd an employee or (S)how all the employees or (F)ind an employee or (D)elete an employee or (U)pdate an employee or (Q)uit: "); var choice = Console.ReadLine().ToUpper();

                switch (choice)
                {
                    case "Q":
                        // They said quit, so set our keepGoing to false
                        keepGoing = false;
                        break;

                    case "U":
                        var nameToUpdate = PromptForString("What name are you looking for: ");

                        // Make a new variable to store the found employee, initializing
                        // to null which will indicate no match found
                        Employee foundEmployeeToUpdate = employees.FirstOrDefault(employee => employee.Name == nameToUpdate);

                        if (foundEmployeeToUpdate == null)
                        {
                            Console.WriteLine("Nobody by that name to update!");
                        }
                        else
                        {
                            var newSalary = PromptForInteger($"What is {foundEmployeeToUpdate}'s new salary? ");

                            foundEmployeeToUpdate.Salary = newSalary;
                        }
                        break;

                    case "D":
                        var nameToDelete = PromptForString("What name are you looking for: ");

                        // Make a new variable to store the found employee, initializing
                        // to null which will indicate no match found
                        Employee foundEmployeeToDelete = employees.FirstOrDefault(employee => employee.Name == nameToDelete);

                        if (foundEmployeeToDelete == null)
                        {
                            Console.WriteLine("Nobody by that name to delete!");
                        }
                        else
                        {
                            employees.Remove(foundEmployeeToDelete);
                            Console.WriteLine($"Goodbye {nameToDelete}");
                        }
                        break;

                    case "F":
                        // Ask for the name of an employee
                        var nameToFind = PromptForString("What name are you looking for: ");

                        // Make a new variable to store the found employee, initializing
                        // to null which will indicate no match found
                        Employee foundEmployeeToFind = employees.FirstOrDefault(employee => employee.Name == nameToFind);

                        // If the foundEmployee is still null, nothing was found
                        if (foundEmployeeToFind == null)
                        {
                            Console.WriteLine("No match found");
                        }
                        else
                        {
                            // Otherwise print details of the found employee
                            Console.WriteLine($"{foundEmployeeToFind.Name} is in department {foundEmployeeToFind.Department} and makes ${foundEmployeeToFind.Salary}");
                        }
                        break;

                    case "S":
                        // show all the employees

                        // Loop through each employee
                        foreach (var employeeToShow in employees)
                        {
                            // And print details
                            Console.WriteLine($"{employeeToShow.Name} is in department {employeeToShow.Department} and makes ${employeeToShow.Salary}");
                        }

                        // Console.WriteLine("Press any key to continue");
                        // Console.ReadKey();
                        break;

                    case "A":
                        var employee = new Employee();

                        employee.Name = PromptForString("What is your name? ");
                        employee.Department = PromptForInteger("What is your department number? ");
                        employee.Salary = PromptForInteger("What is your yearly salary (in dollars)? ");

                        employees.Add(employee);
                        break;
                }
            }
        }
    }
}
