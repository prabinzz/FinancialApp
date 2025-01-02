using Microsoft.Data.Sqlite;
using System.IO;

namespace FinancialApp.Data
{
    public static class DatabaseInitializer
    {
        private const string DbFileName = "ExpenseTracker.db";

        public static string GetDatabasePath()
        {
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            return Path.Combine(folderPath, DbFileName);
        }

        public static void InitializeDatabase()
        {
            string dbPath = GetDatabasePath();

            if (!File.Exists(dbPath))
            {
                using (var connection = new SqliteConnection($"Data Source={dbPath}"))
                {
                    connection.Open();

                    // Create tables
                    string createUsersTable = @"
                    CREATE TABLE IF NOT EXISTS Users (
                        Id TEXT PRIMARY KEY,
                        Username TEXT NOT NULL,
                        Password TEXT NOT NULL,
                        PreferredCurrency TEXT NOT NULL
                    );";

                    string createTagsTable = @"
                    CREATE TABLE IF NOT EXISTS Tags (
                        Id TEXT PRIMARY KEY,
                        Name TEXT NOT NULL
                    );";

                    string createTransactionsTable = @"
                    CREATE TABLE IF NOT EXISTS Transactions (
                        Id TEXT PRIMARY KEY,
                        UserId TEXT NOT NULL,
                        Amount REAL NOT NULL,
                        Type TEXT NOT NULL,
                        Date TEXT NOT NULL,
                        Notes TEXT,
                        FOREIGN KEY(UserId) REFERENCES Users(Id)
                    );";

                    string createTransactionTagsTable = @"
                    CREATE TABLE IF NOT EXISTS TransactionTags (
                        Id TEXT PRIMARY KEY,
                        TransactionId TEXT NOT NULL,
                        TagId TEXT NOT NULL,
                        FOREIGN KEY(TransactionId) REFERENCES Transactions(Id),
                        FOREIGN KEY(TagId) REFERENCES Tags(Id)
                    );";

                    string createDebtsTable = @"
                    CREATE TABLE IF NOT EXISTS Debts (
                        Id TEXT PRIMARY KEY,
                        TransactionId TEXT NOT NULL,
                        Source TEXT NOT NULL,
                        DueDate TEXT NOT NULL,
                        Status TEXT NOT NULL,
                        FOREIGN KEY(TransactionId) REFERENCES Transactions(Id)
                    );";

                    var command = connection.CreateCommand();
                    command.CommandText = $"{createUsersTable} {createTagsTable} {createTransactionsTable} {createTransactionTagsTable} {createDebtsTable}";
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
