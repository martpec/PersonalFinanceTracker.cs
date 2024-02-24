public interface IFinance
    {
        void AddTransaction();
        decimal GetBalance();
        decimal GetTotalIncome();
        decimal GetTotalExpenses();
    }