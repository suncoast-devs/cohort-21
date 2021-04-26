using System;
using System.Collections.Generic;
using System.Linq;

namespace FirstBankOfSuncoast
{
    class Transaction
    {
        // - Properties:  
        // -- Amount (int): (how much is in the transaction)
        public int Amount { get; set; }

        // -- Type (string): Deposit, Withdraw 
        public string Type { get; set; }

        // -- TimeStamp (DateTime) 
        public DateTime TimeStamp { get; set; }

        // -- Account (string): Checking, Savings
        public string Account { get; set; }
    }

    class Program
    {
        static string PromptForString(string prompt)
        {
            Console.Write(prompt);

            var userInput = Console.ReadLine();

            return userInput;
        }

        static int PromptForInteger(string prompt)
        {
            Console.Write(prompt);

            var userInput = Console.ReadLine();

            var userInputAsNumber = int.Parse(userInput);

            return userInputAsNumber;
        }

        static void Main(string[] args)
        {
            // var scores = new List<int> { 98, 100, 42, 16 };
            var transactions = new List<Transaction>()
            {
                // | Type     | Account  | Amount |
                // | -------- | -------- | ------ |
                // | Deposit  | Savings  | 20     |
                new Transaction { Type = "Deposit", Amount = 20, Account = "Savings" },
                // | Deposit  | Savings  | 2000   |
                new Transaction { Type = "Deposit", Amount = 2000, Account = "Savings" },
                // | Deposit  | Checking | 3000   |
                new Transaction { Type = "Deposit", Amount = 3000, Account = "Checking" },
                // | Withdraw | Checking | 42     
                new Transaction { Type = "Withdraw", Amount = 42, Account = "Checking" },
            };

            var userHasChosenToQuit = false;
            while (userHasChosenToQuit == false)
            {
                Console.WriteLine("Menu Options:");
                Console.WriteLine();
                Console.WriteLine("Deposit");
                Console.WriteLine("Withdraw");
                Console.WriteLine("Transfer");
                Console.WriteLine("Balance");
                Console.WriteLine("History");
                Console.WriteLine("Quit");

                var choice = PromptForString("Choice: ").ToUpper().Trim();
                switch (choice)
                {
                    case "DEPOSIT":
                        break;

                    case "WITHDRAW":
                        break;

                    case "TRANSFER":
                        break;

                    case "BALANCE":
                        // Ask the user if they would like to choose Savings or Checking?
                        var balanceChoice = PromptForString("Do you want balance for Savings or Checking? ");

                        // Filter Out Account Type
                        var balanceFilteredTransactions = transactions.Where(transaction => transaction.Account == balanceChoice);

                        var balance = balanceFilteredTransactions.Where(transaction => transaction.Type == "Deposit").Sum(transaction => transaction.Amount) -
                                      balanceFilteredTransactions.Where(transaction => transaction.Type == "Withdraw").Sum(transaction => transaction.Amount);

                        Console.WriteLine($"Your {balanceChoice} balance is {balance}");

                        // 	Filter Out the Withdraw and Sum the Total of the Withdraw
                        // 	difference= Deposit Amount - Withdraw Amount
                        // Print out the difference

                        break;

                    case "HISTORY":
                        // Ask the user if they would like to choose Savings or Checking?
                        var historyChoice = PromptForString("Do you want history for Savings or Checking? ");

                        // Filter Out the Account 
                        var filteredTransactions = transactions.Where(transaction => transaction.Account == historyChoice);

                        // Foreach(var save in savings)
                        foreach (var transaction in filteredTransactions)
                        {
                            // Print out the transaction
                            Console.WriteLine($"{transaction.Amount} - {transaction.Type}");
                        }

                        break;

                    case "QUIT":
                        userHasChosenToQuit = true;
                        break;
                }
            }
        }
    }
}
