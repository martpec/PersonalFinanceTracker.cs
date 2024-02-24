using System;
using Newtonsoft;

namespace PersonalFinanceTracker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FinanceTracker finance = new FinanceTracker();
            bool running = true;
            while (running)
            {
                Console.WriteLine("1. Add transaction");
                Console.WriteLine("2. Show transactions");
                Console.WriteLine("3. Get Financial summary");
                Console.WriteLine("4. Save finances");
                Console.WriteLine("5. Load finances");
                Console.WriteLine("6. Exit");

                Console.Write("Choose an option: ");
                string? option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        finance.AddTransaction();
                        break;
                    case "2":
                        finance.ShowTransactions();
                        break;
                    case "3":
                        finance.GetFinancialSummary();
                        break;
                    case "4":
                        finance.SaveTransactions("JsonFinanceStorage.json");
                        break;
                    case "5":
                        finance.LoadTransactions("JsonFinanceStorage.json");
                        break;
                    case "6":
                        running = false;
                        return;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }

        }
    }
}