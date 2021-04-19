using System;
using System.Collections.Generic;

namespace Blackjack
{
    // - Card
    class Card
    {
        //   - Properties: The Rank of the card, the Suit of the card
        public string Rank { get; set; }
        public string Suit { get; set; }

        //   - Behaviors:
        //     - The Value of the card according to the table in the "P"roblem part
        //
        //     - Name  - Value
        //     - Input
        //     - Work  - Figuring out the value
        //     - Output - the value as an integer
        public int Value()
        {
            // What to do here? -- the work
            return 0;
        }

        //  Description behavior
        //
        //  Name   - Description
        //  Input  - Nope
        //  Work   - Generate a new string that describes this card
        //  Output - String

        public string Description()
        {
            var newDescriptionString = $"The {Rank} of {Suit}";

            return newDescriptionString;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 1.  Create a new deck
            //     PEDAC ^^^^ - Properties: A list of 52 cards
            //     Algorithm for making a list of 52 cards

            //         Make a blank list of cards
            var deck = new List<Card>();

            //         Suits is a list of "Club", "Diamond", "Heart", or "Spade"
            //         Faces is a list of 2, 3, 4, 5, 6, 7, 8, 9, 10, Jack, Queen, King, or Ace

            var suits = new List<string>() { "Clubs", "Diamonds", "Hearts", "Spades" };
            var ranks = new List<string>() { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };

            // Go through each suit, Clubs, Diamonds, Hearts, and Spaces, one at a time
            foreach (var suit in suits)
            {
                //     For each suit do the following
                //        Go through all the ranks, Ace, 2, 3, 4, etc.
                foreach (var rank in ranks)
                {
                    //  With the current suit and the current face, make a new card
                    var card = new Card { Suit = suit, Rank = rank };

                    // Add that card to the list of cards
                    deck.Add(card);
                }
            }

            // 2.  Ask the deck to make a new shuffled 52 cards
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

            // 3.  Create a player hand
            // 4.  Create a dealer hand
            // 5.  Ask the deck for a card and place it in the player hand
            // 6.  Ask the deck for a card and place it in the player hand
            // 7.  Ask the deck for a card and place it in the dealer hand
            // 8.  Ask the deck for a card and place it in the dealer hand
            // 9.  Show the player the cards in their hand and the TotalValue of their Hand
            // 10. If they have BUSTED, then goto step 15
            // 11. Ask the player if they want to HIT or STAND
            // 12. If HIT
            //     - Ask the deck for a card and place it in the player hand, repeat step 10
            // 13. If STAND continue on
            // 14. If the dealer has busted then goto step 17
            // 15. If the dealer has less than 17
            //     - Add a card to the dealer hand and go back to 14
            // 16. Show the dealer's hand TotalValue
            // 17. If the player busted show "DEALER WINS"
            // 18. If the dealer busted show "PLAYER WINS"
            // 19. If the dealer's hand is more than the player's hand then show "DEALER WINS", else show "PLAYER WINS"
            // 20. If the value of the hands are even, show "DEALER WINS"

        }
    }
}
