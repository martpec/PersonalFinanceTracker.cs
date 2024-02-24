using System.Text.Json;
using Newtonsoft;
using Newtonsoft.Json;
public class FinanceTracker : IFinance, IFinanceStorage
{
    private List<Transaction> transactionsList = new List<Transaction>();
    decimal balance = 0;
    decimal income = 0;
    decimal expenses = 0;
    public void AddTransaction()
    {
        Transaction transaction;
        DateTime date = DateTime.Now;

        Console.Write("Add description of a transaction: ");
        string? Description = Console.ReadLine();

        Console.Write("Add amount of a transaction: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal amount))
        {
            Console.WriteLine("Invalid amount");
        }

        Console.Write("Add category of a transaction Income/Groceries/Utilities/Fun: ");
        string? category = Console.ReadLine();
        if (!Enum.TryParse(category, true, out Category cat))
        {
            Console.WriteLine("Invalid category");
        }
        if (string.IsNullOrWhiteSpace(Description))
        {
            throw new ArgumentException("Description cannot be empty");
        }
        transaction = new Transaction(date, Description, amount, cat);
        transactionsList.Add(transaction);
        Console.WriteLine("Transaction added");
        Console.WriteLine();

    }
    public void ShowTransactions()
    {
        Console.WriteLine("Display:  ");
        Console.WriteLine("1. All transactions ");
        Console.WriteLine("2. Transactions by category ");
        Console.WriteLine("3. Transactions by amount ");

        Console.Write("Choose an option: ");
        string? option = Console.ReadLine();
        switch (option)
        {
            case "1":
                foreach (var t in transactionsList)
                {
                    Console.WriteLine("Description: " + t.Description);
                    Console.WriteLine("Amount: " + t.Amount);
                    Console.WriteLine("Category: " + t.Category);
                    Console.WriteLine("Date: " + t.Date);
                    Console.WriteLine("ID: " + t.ID);
                    Console.WriteLine("-----------------");
                    Console.ReadLine();
                }
                break;
            case "2":
                Console.WriteLine("Choose a category: ");
                string? category = Console.ReadLine();
                if (!Enum.TryParse(category, true, out Category cat))
                {
                    Console.WriteLine("Invalid category");
                }
                foreach (var t in transactionsList.Where(t => t.Category == cat))
                {
                    Console.WriteLine("Description: " + t.Description);
                    Console.WriteLine("Amount: " + t.Amount);
                    Console.WriteLine("Category: " + t.Category);
                    Console.WriteLine("Date: " + t.Date);
                    Console.WriteLine("ID: " + t.ID);
                    Console.WriteLine("-----------------");

                }

                break;
            case "3":
                Console.WriteLine("Choose an amount: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal amount))
                {
                    Console.WriteLine("Invalid amount");
                }
                foreach (var t in transactionsList.Where(t => t.Amount >= amount))
                {
                    Console.WriteLine("Description: " + t.Description);
                    Console.WriteLine("Amount: " + t.Amount);
                    Console.WriteLine("Category: " + t.Category);
                    Console.WriteLine("Date: " + t.Date);
                    Console.WriteLine("ID: " + t.ID);
                    Console.WriteLine("-----------------");
                }
                break;
            default:
                Console.WriteLine("Invalid option");
                break;
        }

    }
    public void GetFinancialSummary()
    {
        Console.WriteLine("Balance: " + GetBalance());
        Console.WriteLine("Total income: " + GetTotalIncome());
        Console.WriteLine("Total expenses: " + GetTotalExpenses());
        Console.WriteLine("-----------------");
    }
    public decimal GetBalance()
    {
        foreach (var t in transactionsList)
        {
            if (t.Category == Category.Income)
            {
                balance += t.Amount;
            }
            else
            {
                balance -= t.Amount;
            }
        }
        return balance;
    }

    public decimal GetTotalIncome()
    {
        foreach (var t in transactionsList)
        {
            if (t.Category == Category.Income)
            {
                income += t.Amount;
            }
        }
        return income;
    }

    public decimal GetTotalExpenses()
    {
        foreach (var t in transactionsList)
        {
            if (t.Category != Category.Income)
            {
                expenses += t.Amount;
            }
        }
        return expenses;
    }
    public void SaveTransactions(string filePath)
    {
        string json = JsonConvert.SerializeObject(transactionsList);
        File.WriteAllText(filePath, json);
    }
    public void LoadTransactions(string filePath)
    {
       
    }
}