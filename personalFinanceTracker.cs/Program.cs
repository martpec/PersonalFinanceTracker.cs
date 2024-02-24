using System;

namespace PersonalFinanceTracker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FinanceTracker finance = new FinanceTracker();
            finance.AddTransaction();
            finance.ShowTransactions();
            Console.WriteLine(finance.GetBalance());
            Console.WriteLine(finance.GetTotalIncome());
            Console.WriteLine(finance.GetTotalExpenses());
        }
    }
}