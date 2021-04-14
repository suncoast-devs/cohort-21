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
        }
    }
}
