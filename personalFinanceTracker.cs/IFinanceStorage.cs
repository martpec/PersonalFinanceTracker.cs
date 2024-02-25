namespace PersonalFinanceTracker
{
    public interface IFinanceStorage
    {
        void SaveTransactions(FinanceTracker tracker);
        void LoadTransactions(FinanceTracker tracker);
    }
}