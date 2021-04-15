using System;
using System.Collections.Generic;

namespace AllCardsOnDeck
{
    class Program
    {
        static void Main(string[] args)
        {
            var deck = new List<string>();

            var suits = new List<string>() { "Clubs", "Diamonds", "Hearts", "Spades" };
            var ranks = new List<string>() { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };

            // Go through each suit, Clubs, Diamonds, Hearts, and Spaces, one at a time
            //     For each suit do the following
            //        Go through all the ranks, Ace, 2, 3, 4, etc.
            //           For each combination of suit and rank, make a new string
            //           add that string to our deck of cards list
        }
    }
}
