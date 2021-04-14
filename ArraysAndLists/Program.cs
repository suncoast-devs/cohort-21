using System;

namespace ArraysAndLists
{
    class Program
    {
        static void Main(string[] args)
        {
            //              type
            //               |   array
            //               |    |                list of values
            //               v    v                      V
            var names = new string[] { "Mark", "Paula", "Sandy", "Bill" };
            //                           0        1        2        3

            //              We count from 0
            var firstName = names[0];
            var secondName = names[1];
            var thirdName = names[2];
            var fourthName = names[3];

            Console.WriteLine(firstName);
            Console.WriteLine(secondName);
            Console.WriteLine(thirdName);
            Console.WriteLine(fourthName);

            // Just like strings have a length, so do arrays!
            var nameCount = names.Length;
            Console.WriteLine($"Our array has {nameCount} elements");
        }
    }
}
