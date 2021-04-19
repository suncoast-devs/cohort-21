using System;
using System.Collections.Generic;

namespace Blackjack
{
    // - Card
    class Card
    {
        //   - Properties: The Face of the card, the Suit of the card
        //   - Behaviors:
        //     - The Value of the card according to the table in the "P"roblem part
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
            //         ```
            //         Go through all of the suits one at a time and in order
            //         {
            //             Get the current suit
            //             Go through all of the faces one a time and in order
            //             {
            //                 Get the current face

            //                 With the current suit and the current face, make a new card
            //                 Add that card to the list of cards
            //             Go to the card and loop again
            //             }
            //         Go to the next suit and loop again
            //         }
            //         ```

            // 2.  Ask the deck to make a new shuffled 52 cards
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
