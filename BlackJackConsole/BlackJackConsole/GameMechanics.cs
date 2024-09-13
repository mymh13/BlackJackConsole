using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackConsole
{
    internal class GameMechanics
    {
        private static readonly Random randomCard = new Random();
        // we set this as a static readonly field so we don't have to create a new instance of Random every time we want to deal a card
        
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

                playerScore = DealCard(playerScore, "Player");
                playerScore = DealCard(playerScore, "Player");

                dealerScore = DealCard(dealerScore, "Dealer");
                dealerScore = DealCard(dealerScore, "Dealer");

                Console.WriteLine($"\nYour score: {playerScore}");
                Console.WriteLine($"Dealer's visible card': {dealerScore}");

                playerScore = PlayerTurn(playerScore);

                // dealer only play if player didn't bust
                if (playerScore <= 21)
                {
                    dealerScore = DealerTurn(dealerScore);
                }

                Console.WriteLine($"\nYour final score: {playerScore}");
                Console.WriteLine($"Dealer's final score: {dealerScore}");

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

        private static int DealCard(int currentScore, string participant)
        {
            int cardValue = randomCard.Next(1, 12);
            currentScore += cardValue;
            Console.WriteLine($"{participant} was dealt a {cardValue}. Their new total is {currentScore}.");
            return currentScore;
        }

        private static int PlayerTurn(int playerScore)
        {
            while (true)
            {
                Console.WriteLine("\nWould you like to hit or stand? (H/S)");
                string playerChoice = (Console.ReadLine() ?? "s").ToLower(System.Globalization.CultureInfo.CurrentCulture);

                if (playerChoice == "h")
                {
                    playerScore = DealCard(playerScore, "Player");
                    if (playerScore > 21)
                    {
                        Console.WriteLine("\nYou busted!");
                        break;
                    }
                }
                else if (playerChoice == "s")
                {
                    Console.WriteLine("\nYou chose to stand.");
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter either H (hit) or S (stand).");
                }
            }
            return playerScore;
        }

        private static int DealerTurn(int dealerScore)
        {
            while (dealerScore < 17)
            {
                dealerScore = DealCard(dealerScore, "Dealer");
                if (dealerScore > 21)
                {
                    Console.WriteLine("\nDealer busted!");
                    break;
                }
            }
            if (dealerScore <= 21)
            {
                Console.WriteLine("\nDealer stands.");
            }
            return dealerScore;
        }
    }
}
