using System;

namespace BlackJackConsole
{
    internal class GameMechanics
    {
        internal static Random random = new Random(); // static random so it is only created once :D

        internal static void StartGame()
        {
            Player player = new Player();
            Dealer dealer = new Dealer();
            bool playAgain = true;

            while (playAgain)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the table! Let's play some Blackjack!\n");

                ResetScore(player);
                ResetScore(dealer);

                DealInitialCards(player, "Player");
                DealInitialCards(dealer, "Dealer");

                if (!IsBusted(player))
                {
                    player.PlayTurn();
                }

                if (!IsBusted(player))  // Dealer only plays if player hasn't busted
                {
                    dealer.PlayTurn();
                }

                DetermineWinner(player, dealer);

                Console.WriteLine("\nWould you like to play again? Y/N");
                string playAgainCheck = (Console.ReadLine() ?? "n").ToLower();
                if (playAgainCheck != "y")
                {
                    playAgain = false;
                    MenuMechanics.EndGame();
                }
            }
        }

        private static void DetermineWinner(Player player, Dealer dealer)
        {
            if (IsBusted(player))
            {
                Console.WriteLine("\nYou busted! Dealer wins!");
            }
            else if (IsBusted(dealer))
            {
                Console.WriteLine("\nDealer busted! You win!");
            }
            else if (player.Score > dealer.Score)
            {
                Console.WriteLine("\nYou win!");
            }
            else if (dealer.Score > player.Score)
            {
                Console.WriteLine("\nDealer wins!");
            }
            else
            {
                Console.WriteLine("\nIt's a tie!");
            }

            Console.WriteLine($"\nYour score: {player.Score}");
            Console.WriteLine($"Dealer score: {dealer.Score}");
        }

        internal static int DealCard(string participant, int currentScore)
        {
            int cardValue = random.Next(1, 12);
            currentScore += cardValue;
            Console.WriteLine($"{participant} was dealt a {cardValue}. Their new total is {currentScore}.");
            return currentScore;
        }

        internal static void DealInitialCards(dynamic participant, string name)
        {
            participant.Score = DealCard(name, participant.Score);
            participant.Score = DealCard(name, participant.Score);
        }

        internal static bool IsBusted(dynamic participant)
        {
            return participant.Score > 21;
        }

        internal static void ResetScore(dynamic participant)
        {
            participant.Score = 0;
        }
    }
}