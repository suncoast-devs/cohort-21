using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            var scores = new List<int> { 42, 100, 98, 15 };


            // **** LONG TEDIOUS WAY ****
            // // Here is our handy multiply by two
            // Func<int, int> MultiplyBy2 = value => value * 2;
            // // Make a new list to store the results
            // var newScores = new List<int>();
            // // Go through each score in the scores list
            // foreach (var score in scores)
            // {
            //     // Use the `MultiplyBy2` expression to take score and double it
            //     var doubled = MultiplyBy2(score);

            //     // Add it to our new list
            //     newScores.Add(doubled);
            // }

            var newScores = scores.Select(score => score * 2);

            foreach (var score in newScores)
            {
                Console.WriteLine($"The doubled score is {score}");
            }
        }
    }
}
