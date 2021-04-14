using System;

namespace ControlFlow
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("What is your name? [type quit to stop]? ");
            var name = Console.ReadLine();

            while (name != "quit")
            {
                Console.WriteLine($"Nice to see you {name}");

                Console.Write("What is your name? [type quit to stop]? ");
                name = Console.ReadLine();
            }

            Console.WriteLine("-----------------");

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

            Console.WriteLine("This is the next line of code");

            if (userName == "Paul" || userName == "Peter")
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

            switch (userName)
            {
                case "Paul":
                case "Peter":
                    Console.WriteLine("Here");
                    break;
                case "Dorothy":
                    Console.WriteLine("Also Here");
                    break;
                case "Sam":
                    Console.WriteLine("Here Again");
                    break;
                case "Gavin":
                    Console.WriteLine("Hi there Gavin!");
                    Console.WriteLine("More lines of code");
                    break;
                default:
                    Console.WriteLine("Didn't find anything");
                    break;
            }

        }
    }
}
