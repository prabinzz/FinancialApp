using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialApp.Data
{
    public class UserRepository
    {
        private readonly string _dbPath;

        public UserRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        public void AddUser(string id, string username, string password, string preferredCurrency)
        {
            using (var connection = new SqliteConnection($"Data Source={_dbPath}"))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"
                INSERT INTO Users (Id, Username, Password, PreferredCurrency)
                VALUES ($id, $username, $password, $preferredCurrency)";
                command.Parameters.AddWithValue("$id", id);
                command.Parameters.AddWithValue("$username", username);
                command.Parameters.AddWithValue("$password", password);
                command.Parameters.AddWithValue("$preferredCurrency", preferredCurrency);
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<dynamic> GetAllUsers()
        {
            using (var connection = new SqliteConnection($"Data Source={_dbPath}"))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Users";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return new
                        {
                            Id = reader.GetString(0),
                            Username = reader.GetString(1),
                            Password = reader.GetString(2),
                            PreferredCurrency = reader.GetString(3),
                        };
                    }
                }
            }
        }

        public dynamic GetUserById(string id)
        {
            using (var connection = new SqliteConnection($"Data Source={_dbPath}"))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Users WHERE Id = $id";
                command.Parameters.AddWithValue("$id", id);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new
                        {
                            Id = reader.GetString(0),
                            Username = reader.GetString(1),
                            Password = reader.GetString(2),
                            PreferredCurrency = reader.GetString(3),
                        };
                    }
                    else
                    {
                        return null; 
                    }
                }
            }
        }
        public bool HasUsers()
        {
            using (var connection = new SqliteConnection($"Data Source={_dbPath}"))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT COUNT(*) FROM Users";
                return Convert.ToInt32(command.ExecuteScalar()) > 0;
            }
        }

        public dynamic ValidateUser(string username, string password)
        {
            using (var connection = new SqliteConnection($"Data Source={_dbPath}"))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Users WHERE Username = $username AND Password = $password";
                command.Parameters.AddWithValue("$username", username);
                command.Parameters.AddWithValue("$password", password);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new
                        {
                            Id = reader.GetString(0),
                            Username = reader.GetString(1),
                            Password = reader.GetString(2),
                            PreferredCurrency = reader.GetString(3),
                        };
                    }
                }
            }
            return null;
        }
    }

}
