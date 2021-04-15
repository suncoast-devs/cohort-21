﻿using System;

namespace EmployeeDatabaseWithMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Welcome to Our Employee Database");
            Console.WriteLine("--------------------------------");
            Console.WriteLine();
            Console.WriteLine();

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
