using System;

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
                Console.WriteLine("3. Get balance");
                Console.WriteLine("4. Get total income");
                Console.WriteLine("5. Get total expenses");
                Console.WriteLine("6. Save finances");
                Console.WriteLine("7. Load finances");
                Console.WriteLine("8. Exit");

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
                        Console.WriteLine(finance.GetBalance());
                        break;
                    case "4":
                        Console.WriteLine(finance.GetTotalIncome());
                        break;
                    case "5":
                        Console.WriteLine(finance.GetTotalExpenses());
                        break;
                    case "6":
                        finance.SaveFinances();
                        break;
                    case "7":
                        finance.LoadFinances();
                        break;
                    case "8":
                        running = false;
                        return;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }

            // finance.AddTransaction();
            // finance.ShowTransactions();
            // Console.WriteLine(finance.GetBalance());
            // Console.WriteLine(finance.GetTotalIncome());
            // Console.WriteLine(finance.GetTotalExpenses());
        }
    }
}