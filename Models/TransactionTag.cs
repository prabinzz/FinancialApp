using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialApp.Models
{
    public class TransactionTag
    {
        public string Id { get; set; } // Primary Key
        public string TransactionId { get; set; } // Foreign Key
        public string TagId { get; set; } // Foreign Key

        // Navigation Properties
        public Transaction Transaction { get; set; }
        public Tag Tag { get; set; }
    }
}
