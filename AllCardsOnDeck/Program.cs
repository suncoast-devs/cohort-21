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
            foreach (var suit in suits)
            {
                //     For each suit do the following
                //        Go through all the ranks, Ace, 2, 3, 4, etc.
                foreach (var rank in ranks)
                {
                    //           For each combination of suit and rank, make a new string
                    var card = $"The {rank} of {suit}";
                    //           add that string to our deck of cards list
                    deck.Add(card);
                }
            }


            // numberOfCards = length of our deck
            var numberOfCards = deck.Count;

            // for rightIndex from numberOfCards - 1 down to 1 do:
            for (var rightIndex = numberOfCards - 1; rightIndex >= 1; rightIndex--)
            {
                //   leftIndex = random integer that is greater than or equal to 0 and LESS than rightIndex. See the section "How do we get a random integer")
                var randomNumberGenerator = new Random();
                var leftIndex = randomNumberGenerator.Next(rightIndex);

                //   Now swap the values at rightIndex and leftIndex by doing this:
                //     leftCard = the value from deck[leftIndex]
                var leftCard = deck[leftIndex];
                //     rightCard = the value from deck[rightIndex]
                var rightCard = deck[rightIndex];
                //     deck[rightIndex] = leftCard
                deck[rightIndex] = leftCard;
                //     deck[leftIndex] = rightCard
                deck[leftIndex] = rightCard;
            }

            var firstCard = deck[0];
            var secondCard = deck[1];

            Console.WriteLine(firstCard);
            Console.WriteLine(secondCard);
        }
    }
}
