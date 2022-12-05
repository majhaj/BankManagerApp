using BankManager.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManager.Entities
{
    public class AccountTransactionEntity : Entity
    {
        public int AccountId { get; set; }
        public int TransactionTypeId { get; set; }
        public decimal Amount { get; set; }
        public int CreatorId { get; set; }
        public int? FromAccountId { get; set; }
        public int? ToAccountId { get; set; }
        public TransactionStatus Status { get; set; }
        public string Description { get; set; }



        public int? PendingApprovmentId { get; set; }

        public virtual BankAccountEntity BankAccount { get; set; }
        public virtual BankAccountEntity ToAccount { get; set; }
        public virtual UserEntity Creator { get; set; }
        public virtual TransactionTypeEntity TransactionType { get; set; }


        public virtual IEnumerable<AccountTransactionApprovementEntity> AccountTransactionApprovements { get; set; }

    }
}
