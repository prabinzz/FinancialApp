using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialApp.Models
{
    public class Transaction
    {
        public string Id { get; set; } // Primary Key
        public string UserId { get; set; } // Foreign Key
        public decimal Amount { get; set; }
        public string Type { get; set; } // e.g., "credit", "debit", "debt"
        public DateTime Date { get; set; }
        public string Notes { get; set; }

        // Navigation Properties
        public User User { get; set; }
        public ICollection<TransactionTag> TransactionTags { get; set; }
        public Debt Debt { get; set; } // One-to-One relationship with Debt
    }
}
