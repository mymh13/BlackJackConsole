namespace BlackJackConsole
{
    class MenuMechanics
    {
        internal static void InitialMenu()
        {
            Console.WriteLine("Here you will try to beat the house to 21. Do you know the rules of the game? Y/N");

            while (true)
            {
                string ruleCheck = (Console.ReadLine() ?? "n").ToLower(System.Globalization.CultureInfo.CurrentCulture);
                if (ruleCheck == "y")
                {
                    Console.WriteLine("Great! Let's get started.");
                    break;
                }
                else if (ruleCheck == "n")
                {
                    Console.WriteLine("\nNo problem! Here are the rules of the game:");
                    Console.WriteLine("The goal of blackjack is to beat the dealer's hand without going over 21.\n");
                    Console.WriteLine("Face cards are worth 10. Aces are worth 1 or 11, whichever makes a better hand.");
                    Console.WriteLine("Each player starts with two cards, one of the dealer's cards is hidden until the end.\n");
                    Console.WriteLine("To 'Hit' is to ask for another card. To 'Stand' is to hold your total and end your turn.");
                    Console.WriteLine("If you go over 21 you bust, and the dealer wins regardless of the dealer's hand.");
                    Console.WriteLine("If you are dealt 21 from the start (Ace & 10), you got a blackjack.");
                    Console.WriteLine("Dealer will hit until his/her cards total 17 or higher.");
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
