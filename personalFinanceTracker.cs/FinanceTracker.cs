public class FinanceTracker : IFinance
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
            
        }
        public void ShowTransactions()
        {
            Console.WriteLine("Transactions Dostal som sa tu:");
            foreach (var t in transactionsList)
            {
                Console.WriteLine("Description: " + t.Description);
                Console.WriteLine("Amount: " + t.Amount);
                Console.WriteLine("Category: " + t.Category);
                Console.WriteLine("Date: " + t.Date);
            }
        }
        public decimal GetBalance()
        {
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
    }