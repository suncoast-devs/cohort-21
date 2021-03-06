using System;

namespace Variables
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to C#");
            // Output a blank line
            Console.WriteLine("");
            // This too outputs a blank line
            Console.WriteLine();
            Console.WriteLine("This is on another line");

            Console.Write("What is your name? ");


            // This "HARD CODES" the value for name
            // var name = "Samantha";

            // Instead, lets read the value for the name variable from the console!
            var name = Console.ReadLine();

            // The variable greeting will be the contents of the HARD CODED string
            // immediately followed by whatever is in the variable named "name"
            var greeting = $"It is a pleasure to meet you, {name}. Please enjoy our program";
            Console.WriteLine(greeting);

            Console.WriteLine($"It is a pleasure to meet you, {name}. Please enjoy our program");

            Console.Write("What is your score? ");
            var scoreAsString = Console.ReadLine();
            var score = double.Parse(scoreAsString);

            var doubleThatScore = score * 2;

            Console.WriteLine($"Your score doubled is {doubleThatScore}. Congrats!");

            // var score = 42;

            var school = "SDG";

            var numberOfStudents = 11;

            var price = 5000000000;

            var letter = 'x';

            var letterButDigit = '1';

            var cohort21Started = true;

            var lectureEnded = false;

            var sentence = "The quick brown fox jumped over the lazy dog";
            var howLong = sentence.Length;

            // Increment the score so that we have the latest
            score = score + 1;

            // Hitting the goal doubles our points
            score = score * 2;

            // Fouling causes our score to be cut in fourths
            // more comments here
            // Continue more comments here
            // Even more comments
            score = score / 4;

            score = score - 10;

            score = (score + 1) * 2;

            score = 2 * (score + 1);

        }
    }
}
