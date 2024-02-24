using System;
using Newtonsoft;

namespace PersonalFinanceTracker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FinanceTracker finance = new FinanceTracker();
            while (true)
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
                        break;
                    case "5":
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }

        }
    }
}