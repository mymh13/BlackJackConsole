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
            Console.WriteLine("Would you like to play a game of Black Jack? Y/N");

            while (true)
            {
                string? play = Console.ReadLine();
                if (play == "y")
                {
                    Console.WriteLine("Great! Let's get started.");
                    break;
                }
                else if (play == "n")
                {
                    Console.WriteLine("No problem! Maybe next time.");
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter either Y or N to progress.");
                }
            }
        }
    }
}
