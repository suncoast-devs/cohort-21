using System;
using System.Collections.Generic;

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

            Console.WriteLine("-----------------");

            //
            //              Making a new List
            //              |
            //              |    ... of strings
            //              |    |
            //              |    |          Start of initial list of strings
            //              |    |          |
            //              |    |          |       Values
            //              |    |          |       |
            //              |    |          |       |                 End of list
            //              |    |          |       |                           |
            //              |    |          |       |                           |
            //              v    |          v       v                           v
            var namesList = new List<string>() { "Mark", "Paula", "Sandy", "Bill" };

            var firstNameFromList = namesList[0];
            var secondNameFromList = namesList[1];

            Console.WriteLine(firstNameFromList);

            // Get the number of names in the list
            var nameCountFromList = namesList.Count;

            Console.WriteLine($"There are {nameCountFromList} elements in our List");

            // Add a new element to the list
            namesList.Add("George");

            var newNameCountFromListAfterGeorge = namesList.Count;

            Console.WriteLine($"There are now {newNameCountFromListAfterGeorge} elements in our List");

        }
    }
}
