using System;

namespace BlackJackConsole
{
    internal class Dealer
    {
        internal int Score { get; set; } // Made set accessible for GameMechanics

        internal void PlayTurn(int playerScore)
        {
            while (Score < 17 || (Score < playerScore && Score <= 21))
            {
                Score = GameMechanics.DealCard("Dealer", Score);
                if (GameMechanics.IsBusted(this))
                {
                    Console.WriteLine("\nDealer busted!");
                    break;
                }
            }
            if (Score <= 21)
            {
                Console.WriteLine("\nDealer stands.");
            }
        }
    }
}