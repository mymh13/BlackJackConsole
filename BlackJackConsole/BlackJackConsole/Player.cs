using System;

namespace BlackJackConsole
{
    internal class Player
    {
        internal int Score { get; set; } // Made set accessible for GameMechanics

        public void PlayTurn()
        {
            while (true)
            {
                Console.WriteLine("\nWould you like to hit or stand? (H/S)");
                string playerChoice = (Console.ReadLine() ?? "s").ToLower();

                if (playerChoice == "h")
                {
                    Score = GameMechanics.DealCard("Player", Score);
                    if (GameMechanics.IsBusted(this))
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
        }
    }
}