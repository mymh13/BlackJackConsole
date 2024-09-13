using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackConsole
{
    internal class GameMechanics
    {
        internal static void StartGame()
        {
            int playerScore = 0;
            int dealerScore = 0;
            int playerWins = 0;
            int dealerWins = 0;
            int ties = 0;
            bool playAgain = true;

            while (playAgain)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the table! Let's play some Blackjack!\n");

                playerScore = 0;
                dealerScore = 0;

                playerScore = DealCard(playerScore);
                playerScore = DealCard(playerScore);

                dealerScore = DealCard(dealerScore);
                dealerScore = DealCard(dealerScore);

                Console.WriteLine($"\nYour score: {playerScore}");
                Console.WriteLine($"Dealer score: {dealerScore}");

                playerScore = PlayerTurn(playerScore);
                dealerScore = DealerTurn(dealerScore);

                Console.WriteLine($"\nYour score: {playerScore}");
                Console.WriteLine($"Dealer score: {dealerScore}");

                if (playerScore > 21)
                {
                    Console.WriteLine("\nYou busted! Dealer wins!");
                    dealerWins++;
                }
                else if (dealerScore > 21)
                {
                    Console.WriteLine("\nDealer busted! You win!");
                    playerWins++;
                }
                else if (playerScore > dealerScore)
                {
                    Console.WriteLine("\nYou win!");
                    playerWins++;
                }
                else if (dealerScore > playerScore)
                {
                    Console.WriteLine("\nDealer wins!");
                    dealerWins++;
                }
                else
                {
                    Console.WriteLine("\nIt's a tie!");
                    ties++;
                }

                Console.WriteLine($"\nPlayer wins: {playerWins}");
                Console.WriteLine($"Dealer wins: {dealerWins}");
                Console.WriteLine($"Ties: {ties}");

                Console.WriteLine("\nWould you like to play again? Y/N");
                string playAgainCheck = (Console.ReadLine() ?? "n").ToLower(System.Globalization.CultureInfo.CurrentCulture);
                if (playAgainCheck != "y")
                {
                    playAgain = false;
                    MenuMechanics.EndGame();
                }
            }

        }
        private static int DealCard(int playerScore)
        {
            Random randomCard = new Random();
            int cardValue = randomCard.Next(1, 12);
            playerScore += cardValue;
            Console.WriteLine($"You were dealt a {cardValue}. Your new total is {playerScore}.");
            return playerScore;
        }

        private static int PlayerTurn(int playerScore)
        {
            // here we want to ask the player if they want to hit or stand
        }
        private static int DealerTurn(int dealerScore)
        {
            // here we want to have the dealer hit until they have 17 or higher
        }
    }
}
