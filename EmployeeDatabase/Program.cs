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
                Console.Write("What do you want to do? (A)dd an employee or (S)how all the employees or (F)ind an employee or (D)elete an employee or (Q)uit: "); var choice = Console.ReadLine().ToUpper();

                if (choice == "Q")
                {
                    // They said quit, so set our keepGoing to false
                    keepGoing = false;
                }
                else if (choice == "D")
                {
                    var name = PromptForString("What name are you looking for: ");

                    // Make a new variable to store the found employee, initializing
                    // to null which will indicate no match found
                    Employee foundEmployee = employees.FirstOrDefault(employee => employee.Name == name);

                    if (foundEmployee == null)
                    {
                        Console.WriteLine("Nobody by that name to delete!");
                    }
                    else
                    {
                        employees.Remove(foundEmployee);
                        Console.WriteLine($"Goodbye {name}");
                    }
                }
                else if (choice == "F")
                {
                    // Ask for the name of an employee
                    var name = PromptForString("What name are you looking for: ");

                    // Make a new variable to store the found employee, initializing
                    // to null which will indicate no match found
                    Employee foundEmployee = employees.FirstOrDefault(employee => employee.Name == name);

                    // If the foundEmployee is still null, nothing was found
                    if (foundEmployee == null)
                    {
                        Console.WriteLine("No match found");
                    }
                    else
                    {
                        // Otherwise print details of the found employee
                        Console.WriteLine($"{foundEmployee.Name} is in department {foundEmployee.Department} and makes ${foundEmployee.Salary}");
                    }
                }
                else if (choice == "S")
                {
                    // show all the employees

                    // Loop through each employee
                    foreach (var employee in employees)
                    {
                        // And print details
                        Console.WriteLine($"{employee.Name} is in department {employee.Department} and makes ${employee.Salary}");
                    }

                    // Console.WriteLine("Press any key to continue");
                    // Console.ReadKey();
                }
                else
                {
                    var employee = new Employee();

                    employee.Name = PromptForString("What is your name? ");
                    employee.Department = PromptForInteger("What is your department number? ");
                    employee.Salary = PromptForInteger("What is your yearly salary (in dollars)? ");

                    employees.Add(employee);
                }
            }
        }
    }
}
