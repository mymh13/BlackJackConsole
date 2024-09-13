using System;

namespace BlackJackConsole
{
    internal class Dealer
    {
        internal int Score { get; set; } // Made set accessible for GameMechanics

        public void PlayTurn()
        {
            while (Score < 17)
            {
                Score = GameMechanics.DealCard("Dealer", Score);
                if (GameMechanics.IsBusted(this))
                {
                    Console.WriteLine("\nDealer busted!");
                    break;
                }
            }
            Console.WriteLine("\nDealer stands.");
        }
    }
}