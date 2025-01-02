using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialApp.Models
{
    public class Debt
    {
        public string Id { get; set; }
        public string TransactionId { get; set; } 
        public string Source { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; } 

        
        public Transaction Transaction { get; set; }
    }
}
