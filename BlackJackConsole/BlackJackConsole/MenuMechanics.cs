using System;

namespace BlackJackConsole
{
    class MenuMechanics
    {
        internal static void InitialMenu()
        {
            Console.WriteLine("Here you will try to beat the house to 21. Do you know the rules of the game? Y/N");

            while (true)
            {
                string ruleCheck = (Console.ReadLine() ?? "n").ToLower();
                if (ruleCheck == "y")
                {
                    Console.WriteLine("Great! Let's get started.");
                    break;
                }
                else if (ruleCheck == "n")
                {
                    Console.WriteLine("\nNo problem! Here are the rules of the game:");
                    // Rule explanation...
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey();
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter either Y or N to progress.");
                }
            }

            GameMechanics.StartGame();
        }

        internal static void EndGame()
        {
            Console.WriteLine("\nThanks for playing! Goodbye!");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}