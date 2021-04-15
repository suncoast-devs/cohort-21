using System;

namespace EmployeeDatabaseWithMethods
{
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

        static void Main(string[] args)
        {
            DisplayGreeting();

            Console.Write("What is your name? ");
            var name = Console.ReadLine();

            Console.Write("What is your department number? ");
            var department = int.Parse(Console.ReadLine());

            Console.Write("What is your yearly salary (in dollars)? ");
            var salary = int.Parse(Console.ReadLine());

            var salaryPerMonth = salary / 12;
            Console.WriteLine($"Hello, {name} you make {salaryPerMonth} a month.");
        }
    }

}
