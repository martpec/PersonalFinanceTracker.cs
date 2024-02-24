namespace PersonalFinanceTracker
{
    public interface IFinanceStorage
    {
        void SaveTransactions(string filePath);
        void LoadTransactions(string filePath);
    }
}