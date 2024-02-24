public class FinanceTracker : IFinance, IFinanceStorage
{
    private List<Transaction> transactionsList = new List<Transaction>();

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

        Console.Write("Add category of a transaction Income/Groceries/Utilities/Fun:");
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
        Console.WriteLine("Display  ");
        Console.WriteLine("1. All transactions: ");
        Console.WriteLine("2. Transactions by category: ");
        Console.WriteLine("3. Transactions by amount: ");
        Console.WriteLine("4. Transactions by date: ");

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
    public decimal GetBalance()
    {
        Console.WriteLine("Balance: ");
        return GetTotalIncome() - GetTotalExpenses();
    }

    public decimal GetTotalIncome()
    {
        return transactionsList.Where(t => t.Amount > 0).Sum(t => t.Amount);
    }

    public decimal GetTotalExpenses()
    {
        
        return transactionsList.Where(t => t.Amount < 0).Sum(t => Math.Abs(t.Amount));
    }
    public void SaveFinances()
    {
        
    }
    public void LoadFinances()
    {

    }
}