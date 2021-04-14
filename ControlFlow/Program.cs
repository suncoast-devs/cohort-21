using System;

namespace ControlFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("What is your name? ");
            var userName = Console.ReadLine();

            if (userName == "Alice")
            {
                Console.WriteLine("Wow, it is alice!");
            }
            else
            {
                Console.WriteLine($"It is nice to meet you, {userName}!");
            }


            if (userName == "Paul")
            {
                Console.WriteLine("Here");
            }
            else if (userName == "Dorothy")
            {
                Console.WriteLine("Also here");
            }
            else if (userName == "Sam")
            {
                Console.WriteLine("Here again");
            }
            else
            {
                Console.WriteLine("Didn't find anything");
            }

        }
    }
}
