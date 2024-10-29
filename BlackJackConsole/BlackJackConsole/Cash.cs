using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackConsole
{
    internal class Cash
    {
        private static readonly string cashFilePath = "C:\\DevProj\\BlackJackConsole\\cash_balance.txt";
        private int balance;

        public Cash()
        {
            balance = LoadBalance();
        }

        // Load the balance from the file
        private int LoadBalance()
        {
            if (File.Exists(cashFilePath))
            {
                string balanceText = File.ReadAllText(cashFilePath);
                if (int.TryParse(balanceText, out int savedBalance))
                {
                    return savedBalance;
                }
            }
            return 100; // Default balance if no file exists or data is missing or invalid
        }

        // Save the balance to the file
        public void SaveBalance()
        {
            File.WriteAllText(cashFilePath, balance.ToString());
        }

        // Adjust balance
        internal void UpdateBalance(int amount)
        {
            balance += amount;
            Console.WriteLine($"Your new balance is: ${balance}");
            SaveBalance();
        }

        // Display current balance
        internal void DisplayBalance()
        {
            Console.WriteLine($"Current balance: {balance}");
        }

        internal int GetBalance()
        {
            return balance;
        }
    }
}
