using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManager.Entities
{
    public class BankAccountEntity : EntityDeletable
    {
        public string OwnerFormattedData => $"Owner formatted data for account {Number}";



        public int BankId { get; set; }
        public int OwnerId { get; set; }
        public int CreatorId { get; set; }
        public int CurrencyId { get; set; }

        public string Number { get; set; }
        public decimal Balance { get; set; }
        public decimal Interest { get; set; }


        public virtual BankEntity Bank { get; set; }
        public virtual UserEntity Owner { get; set; }
        public virtual UserEntity Creator { get; set; }
        public virtual CurrencyEntity Currency { get; set; }


        public virtual ICollection<AccountTransactionEntity> AccountTransactions { get; set; }

        public override string GetCreationProcessDescription()
        {
            var result = base.GetCreationProcessDescription();

            if (Bank != null)
            {
                result += $" Bank account {Number} created in bank: {Bank.Name} ";
            }

            //if (Owner != null)
            //{
            //    result += $" Account owner : {Owner.GetCreationProcessDescription()} ";
            //}

            result += $" Account balance: {Balance}";

            return result;
        }
        public override string GetDeletionProcessDescription()
        {
            return base.GetDeletionProcessDescription();
        }
    }
}
