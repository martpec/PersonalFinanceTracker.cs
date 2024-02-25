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

    public Transaction(DateTime Date, string Description, decimal Amount, Category Category)
    {
        this.Date = Date;
        this.Description = Description;
        this.Amount = Amount;
        this.Category = Category;
    }
}