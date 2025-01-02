using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialApp.Models
{
    public class Tag
    {
        public string Id { get; set; } // Primary Key
        public string Name { get; set; }

        // Navigation Property
        public ICollection<TransactionTag> TransactionTags { get; set; }
    }
}
