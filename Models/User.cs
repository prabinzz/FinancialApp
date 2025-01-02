using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialApp.Models
{
    public class User
    {
        public string Id { get; set; } // Primary Key
        public string Username { get; set; }
        public string Password { get; set; } // Hashed
        public string PreferredCurrency { get; set; }

        // Navigation Property
        public ICollection<Transaction> Transactions { get; set; }
    }
}
