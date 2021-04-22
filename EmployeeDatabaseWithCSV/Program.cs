using System;
using System.Linq;

namespace EmployeeDatabase
{
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
            var database = new EmployeeDatabase();
            database.LoadEmployeesFromCSV();

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
                        database.SaveEmployeesToCSV();

                        // They said quit, so set our keepGoing to false
                        keepGoing = false;
                        break;

                    case "U":
                        var nameToUpdate = PromptForString("What name are you looking for: ");

                        // Make a new variable to store the found employee, initializing
                        // to null which will indicate no match found
                        Employee foundEmployeeToUpdate = database.FindEmployee(nameToUpdate);

                        if (foundEmployeeToUpdate == null)
                        {
                            Console.WriteLine("Nobody by that name to update!");
                        }
                        else
                        {
                            var newSalary = PromptForInteger($"What is {foundEmployeeToUpdate}'s new salary? ");

                            foundEmployeeToUpdate.Salary = newSalary;
                        }

                        database.SaveEmployeesToCSV();
                        break;

                    case "D":
                        var nameToDelete = PromptForString("What name are you looking for: ");

                        // Make a new variable to store the found employee, initializing
                        // to null which will indicate no match found
                        Employee foundEmployeeToDelete = database.FindEmployee(nameToDelete);

                        if (foundEmployeeToDelete == null)
                        {
                            Console.WriteLine("Nobody by that name to delete!");
                        }
                        else
                        {
                            database.RemoveEmployee(foundEmployeeToDelete);
                            Console.WriteLine($"Goodbye {nameToDelete}");
                        }

                        database.SaveEmployeesToCSV();
                        break;

                    case "F":
                        // Ask for the name of an employee
                        var nameToFind = PromptForString("What name are you looking for: ");

                        // Make a new variable to store the found employee, initializing
                        // to null which will indicate no match found
                        Employee foundEmployeeToFind = database.FindEmployee(nameToFind);

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
                        var allTheEmployeeFromTheDatabase = database.GetAllEmployees();
                        foreach (var employeeToShow in allTheEmployeeFromTheDatabase)
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

                        database.AddEmployee(employee);

                        database.SaveEmployeesToCSV();
                        break;
                }
            }
        }
    }
}
