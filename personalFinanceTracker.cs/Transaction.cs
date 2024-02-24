public enum Category
{
    Income,
    Groceries,
    Utilities,
    Fun
}
public class Transaction
{
    public Guid ID { get; set; } = Guid.NewGuid();
    public DateTime Date { get; set; }
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public Category Category { get; set; }

    public Transaction(DateTime date, string desc, decimal amount, Category cat)
    {
        Date = date;
        Description = desc;
        Amount = amount;
        Category = cat;
    }
}