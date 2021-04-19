using System;
using System.Collections.Generic;

namespace Blackjack
{
    // - Hand
    class Hand
    {
        //   - Properties: A list of individual Cards
        public List<Card> IndividualCards { get; set; } = new List<Card>();


        //   - Behaviors:
        //     - TotalValue representing the sum of the individual Cards in the list.
        //     - Add a card to the hand

        //
        //   Name      Add
        //   Input     new card
        //   Work      -- can't auto generate this!
        //   Output    void (nothing)
        public void Receive(Card newCard)
        {
            // Add this card to the hand
            IndividualCards.Add(newCard);
        }

        //     - TotalValue representing the sum of the individual Cards in the list.
        //
        //  Name        - TotalValue
        //  Input       - None 
        //  Work        - Somehow total up the value of the cards
        //  Output      - The total value (int) of the cards
        public int TotalValue()
        {
            // PEDAC

            // Problem:
            //
            //   We have a list of cards that know their own value and we want
            //   a total value computed by adding the value of the first card
            //   to the second to the third card and so on for all the cards in
            //   the list.
            //
            // Example:
            //    3 of Clubs, 5 of Diamonds, Ace of Hearts -- 3 + 5 + 11 = 19
            //    2 of Clubs, 2 of Hearts, 2 of Diamonds -- 2 + 2 + 2 = 6
            //    empty? no cards -- 0
            //    Queen of Hearts -- 10
            //
            // Data
            //
            //    List
            //    integer total
            //    foreach loop? -- to go the cards?
            //
            // Algorithm
            //   start our total at zero
            var total = 0;
            //   for each card in the list do the following
            foreach (var card in IndividualCards)
            {
                //     add the current card value to the current total making that the new total
                // total = card.Value() + total;
                // total = total + card.Value();
                total += card.Value();
            }

            //   when done, the current total is the answer
            return total;
        }

    }

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


            // PEDAC
            //
            // Problem - If we know the RANK of a card, how do we get the card's
            //           value in our blackjack game rules. We are given some rules
            //           about how cards are valued. 2-10 are worth their face value
            //           J, Q, K, are all worth 10 and ACE is worth 11.
            //
            // Example -
            //

            //
            // Data
            //
            //    Input      -- string "Rank"
            //    Output     -- integer number of points/value
            //
            // Algorithm
            //    An if/else chain of all the faces equal to each possibility
            //    If the face/rank matches, that is the number of points (see table)


            switch (Rank)
            {
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                case "10":
                    return int.Parse(Rank);
                case "Jack":
                case "Queen":
                case "King":
                    return 10;
                case "Ace":
                    return 11;
                default:
                    // Huh? What card was that?
                    return 0;
            }

        }

        //  Description behavior
        //
        //  Name   - Description
        //  Input  - Nope
        //  Work   - Generate a new string that describes this card
        //  Output - String

        public string Description()
        {
            var newDescriptionString = $"The {Rank} of {Suit} - worth {Value()} points.";

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
            var playerHand = new Hand();

            // 4.  Create a dealer hand
            var dealerHand = new Hand();

            // 5.  Ask the deck for a card 
            var newCard = deck[0];
            deck.Remove(newCard);

            // 5b and place it in the player hand
            playerHand.Receive(newCard);

            // 6.  Ask the deck for a card 
            newCard = deck[0];
            deck.Remove(newCard);

            // 6b. and place it in the player hand
            playerHand.Receive(newCard);


            // 7.  Ask the deck for a card and place it in the dealer hand
            newCard = deck[0];
            deck.Remove(newCard);

            dealerHand.Receive(newCard);

            // 8.  Ask the deck for a card and place it in the dealer hand
            newCard = deck[0];
            deck.Remove(newCard);

            dealerHand.Receive(newCard);


            // 10. If they have BUSTED, then goto step 15
            var keepAsking = true;
            while (keepAsking == true && playerHand.TotalValue() <= 21)
            {
                // 9.  Show the player the cards in their hand and the TotalValue of their Hand
                Console.WriteLine("Your cards are:");
                foreach (var card in playerHand.IndividualCards)
                {
                    Console.WriteLine(card.Description());
                }
                Console.Write("Your total hand value is: ");
                Console.WriteLine(playerHand.TotalValue());

                // 11. Ask the player if they want to HIT or STAND
                Console.Write("Do you want to [H]it or [S]tand? ");
                var choice = Console.ReadLine().ToLower();

                // 12. If HIT
                if (choice == "h")
                {
                    //     - Ask the deck for a card and place it in the player hand, repeat step 10
                    var hitCard = deck[0];
                    deck.Remove(hitCard);

                    playerHand.Receive(hitCard);
                }
                else
                {
                    // 13. If STAND continue on
                    keepAsking = false;
                }
            }
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
