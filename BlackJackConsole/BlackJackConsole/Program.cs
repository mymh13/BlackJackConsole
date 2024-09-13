
using System.ComponentModel.Design;

namespace BlackJackConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Black Jack game!");
            StartGame();
        }

        private static void StartGame()
        {
            Console.WriteLine("Here you will try to beat the house to 21. Do you know the rules of the game? Y/N");
            string? rules = Console.ReadLine();
            if (rules != "y" || "n")
            {
                Console.WriteLine("Please enter either Y or N to progress.");
                StartGame();
            }
        }
    }
}
