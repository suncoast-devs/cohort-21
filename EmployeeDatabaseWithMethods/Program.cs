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

            var answerAsInteger = int.Parse(answer);

            return answerAsInteger;
        }

        static void Main(string[] args)
        {
            DisplayGreeting();

            var name = PromptForString("What is your name? ");

            var department = PromptForInteger("What is your department number? ");

            var salary = PromptForInteger("What is your yearly salary (in dollars)? ");

            var salaryPerMonth = salary / 12;
            Console.WriteLine($"Hello, {name} you make {salaryPerMonth} a month.");
        }
    }

}
