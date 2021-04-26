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

        // Make a method to compute the balance
        //
        //
        //       Name        ComputeBalance
        //       Input       list of transactions -- choice of which account we are interested in
        //       Work        (those lines of LINQ code down below)
        //       Output      int balance

        static public int ComputeBalance(List<Transaction> transactionsForBalancing, string accountTypeToBalance)
        {
            // Work
            // Filter Out Account Type
            var balanceFilteredTransactions = transactionsForBalancing.Where(transaction => transaction.Account == accountTypeToBalance);

            var balance = balanceFilteredTransactions.Where(transaction => transaction.Type == "Deposit").Sum(transaction => transaction.Amount) -
                          balanceFilteredTransactions.Where(transaction => transaction.Type == "Withdraw").Sum(transaction => transaction.Amount);

            return balance;
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
                        // Ask the user if they would like to choose Savings or Checking?
                        var withdrawChoice = PromptForString("Do you want withdraw from Savings or Checking? ");

                        var withdrawMaximum = ComputeBalance(transactions, withdrawChoice);

                        // Ask how much they want to withdraw from savings?
                        var withdrawAmount = PromptForInteger($"How much do you want to withdraw from {withdrawChoice} -- up to {withdrawMaximum}? ");

                        // 	If (difference < Asking Amount)
                        // if (withdrawMaximum < withdrawAmount)
                        if (withdrawAmount > withdrawMaximum)
                        {
                            // 		Say "No funds"
                            Console.WriteLine("No funds!");
                        }
                        // 	If (difference > Asking Amount)
                        else
                        {
                            // 		Add a new instance of Transaction:
                            var transaction = new Transaction()
                            {
                                // 		Account
                                Account = withdrawChoice,
                                // 		Amount
                                Amount = withdrawAmount,
                                // 		Type
                                Type = "Withdraw",
                                // 		TimeStamp
                                TimeStamp = DateTime.Now,
                            };

                            // 		Add Transaction
                            transactions.Add(transaction);
                        }
                        // 	Write all the transactions to the file (the four lines of code for the fileWriter)
                        break;

                    case "TRANSFER":
                        break;

                    case "BALANCE":
                        // Ask the user if they would like to choose Savings or Checking?
                        var balanceChoice = PromptForString("Do you want balance for Savings or Checking? ");

                        // // Filter Out Account Type
                        // var balanceFilteredTransactions = transactions.Where(transaction => transaction.Account == balanceChoice);

                        // var balance = balanceFilteredTransactions.Where(transaction => transaction.Type == "Deposit").Sum(transaction => transaction.Amount) -
                        //               balanceFilteredTransactions.Where(transaction => transaction.Type == "Withdraw").Sum(transaction => transaction.Amount);

                        var balance = ComputeBalance(transactions, balanceChoice);

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
