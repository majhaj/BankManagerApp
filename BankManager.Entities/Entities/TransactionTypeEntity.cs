using BankManager.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManager.Entities
{
    public class TransactionTypeEntity : Entity
    {
        public string Name { get; set; }
        public TransactionTypeCode Code { get; set; }
        public int CreatorId { get; set; }

        public virtual ICollection<AccountTransactionEntity> AccountTransactions { get; set; }
        public virtual UserEntity Creator { get; set; }

        public override string GetCreationProcessDescription()
        {
            var result = $"Created Tranaction type name {Name} ";

            return result;
        }
    }
}
