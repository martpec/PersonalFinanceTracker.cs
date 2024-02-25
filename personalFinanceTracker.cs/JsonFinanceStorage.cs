using System.Text.Json;
using System.IO;

namespace PersonalFinanceTracker
{
    public class JsonFinanceStorage : IFinanceStorage
    {
        private readonly string filePath = "JsonFinanceStorage.json";

        public void SaveTransactions(FinanceTracker tracker)
        {
            string jsonString = JsonSerializer.Serialize(tracker.GetTransactionsList());
            File.WriteAllText(filePath, jsonString);
        }
        public void LoadTransactions(FinanceTracker tracker)
        {
            string content = File.ReadAllText(filePath);
            if (string.IsNullOrWhiteSpace(content))
            {
                return;
            }
            tracker.SetTransactions(JsonSerializer.Deserialize<List<Transaction>>(content));
        }
    }
}