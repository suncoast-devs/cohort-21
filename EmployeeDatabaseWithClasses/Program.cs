using System;

namespace EmployeeDatabaseWithMethods
{
    // // This is where new classes go! 
    // //
    // // class keyword
    // // |
    // // |    Name of class (PascalCase)
    // // |    |
    // // v    v
    // class Employee
    // {
    //     // public means "this can be seen outside of the class
    //     // |
    //     // |   Type
    //     // |   |
    //     // |   |      Name of property
    //     // |   |      |
    //     // |   |      |
    //     // |   |      |
    //     // v   v      v
    //     public string Name;
    //     public int Department;
    //     public int Salary;
    //     public int MonthlySalary;

    //     // This is a *special* method known as a "constructor"
    //     // The constructor is called when we write a line like: `var bob = new Employee(`
    //     // The arguments to the method should line up to those below
    //     //
    //     //              This will become the employee's name
    //     //              |               This will become the employee's department
    //     //              |               |                  This will become the employee's salary
    //     //              |               |                  |              This will become the employee's monthly salary
    //     //              |               |                  |              |
    //     //              v               v                  v              v
    //     public Employee(string newName, int newDepartment, int newSalary, int newMonthlySalary)
    //     {
    //         // In the constructor we should setup the values for any of the properties.
    //         // Here we will *copy* the values given by the arguments to the corresponding property.

    //         Name = newName;
    //         Department = newDepartment;
    //         Salary = newSalary;
    //         MonthlySalary = newSalary;
    //     }
    // }


    //
    // class keyword
    // |
    // |    Name of class (PascalCase)
    // |    |
    // v    v
    class Employee
    {
        // public means "this can be seen outside of the class
        // |
        // |   Type
        // |   |
        // |   |      Name of property
        // |   |      |
        // |   |      |      We can get the data and set the data
        // |   |      |      |
        // v   v      v      v
        public string Name { get; set; }
        public int Department { get; set; }
        public int Salary { get; set; }
        public int MonthlySalary { get; set; }
    }


    class Program
    {
        // This is where our new method goes!

        // static method (ignore this for the moment)
        //  |
        //  |  The return (output) type. Here there is none
        //  |  since the method isn't giving anything back
        //  |  to the code that called it.
        //  |   |
        //  |   |               The inputs, known as arguments. None in this case.
        //  |   |                   |
        //  |   |                   |
        //  v   v                   v
        static void DisplayGreeting()
        {
            //
            //    Body of the method
            //      |
            //      |
            //      v
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Welcome to Our Employee Database");
            Console.WriteLine("--------------------------------");
            Console.WriteLine();
            Console.WriteLine();
        }

        // static method (ignore this for the moment)
        //  |
        //  |  The return (output) type. This says that
        //  |  we expect this method to return a single
        //  |  string to the code that called it
        //  |   |
        //  |   |               The inputs, known as arguments.
        //  |   |               In this case a single string
        //  |   |               in a variable known as `prompt`
        //  |   |                      |
        //  |   |                      |
        //  v   v                      v
        static string PromptForString(string prompt)
        {
            // Print the requested prompt (in the "prompt" variable)
            Console.Write(prompt);

            // Get answer (string) from the user
            var answer = Console.ReadLine();

            // RETURN THE ANSWER
            return answer;
        }

        static int PromptForInteger(string prompt)
        {
            var answer = PromptForString(prompt);

            int answerAsInteger;

            var isThisGoodInput = int.TryParse(answer, out answerAsInteger);
            if (isThisGoodInput)
            {
                return answerAsInteger;
            }
            else
            {
                Console.WriteLine("That isn't good input. I'm using 0 as your answer.");
                return 0;
            }
        }

        static void Main(string[] args)
        {
            // DisplayGreeting();

            // var name = PromptForString("What is your name? ");

            // var department = PromptForInteger("What is your department number? ");

            // var salary = PromptForInteger("What is your yearly salary (in dollars)? ");

            // var salaryPerMonth = salary / 12;
            // Console.WriteLine($"Hello, {name} you make {salaryPerMonth} a month.");


            var graceHopper = new Employee()
            {
                Department = 100,
                Salary = 240000,
                MonthlySalary = 20000,
                Name = "Grace Hopper",
            };

            var elonMusk = new Employee()
            {
                Salary = 120000,
                Name = "Elon Musk",
                Department = 42,
                MonthlySalary = 10000,
            };

            Console.WriteLine(graceHopper.Department);
            Console.WriteLine(elonMusk.Department);
        }
    }

}
