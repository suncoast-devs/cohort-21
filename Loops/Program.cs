using System;
using System.Collections.Generic;

namespace Loops
{
    class Program
    {
        static void Main(string[] args)
        {
            var counter = 0;

            while (counter < 10)
            {
                Console.WriteLine($"Doing something {counter}");

                counter++;
            }

            // Start the counter at 0
            //      |
            //      |        Keep going as long as counter is less than 10
            //      |               |
            //      |               |        Increment counter after each loop is done
            //      |               |             |
            //      |               |             |
            //      V               V             V
            for (var forCounter = 0; forCounter < 10; forCounter++)
            {
                Console.WriteLine($"Doing something with a for loop. {forCounter}");
            }


            var names = new List<string>() { "Mark", "Paula", "Sandy", "Bill" };

            for (var index = 0; index < names.Count; index++)
            {
                var name = names[index];

                Console.WriteLine($"When the index is {index} the name is {name}");
            }

            // Goes through the entire collection (list or array) from first to last
            foreach (var name in names)
            {
                Console.WriteLine($"Hello {name}");
            }
        }
    }
}
