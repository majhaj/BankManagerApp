using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManager.Entities
{
    public class AccountTransactionApprovementEntity
    {
        public int TransactionId { get; set; }
        public AccountTransactionEntity AccountTransaction { get; set; }

        public int ApprovementId { get; set; }
        public ApprovementEntity Approvement { get; set;}
    }
}
