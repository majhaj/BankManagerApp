using BankManager.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManager.Entities
{
    public class ApprovementEntity : Entity
    {
        public int ApprovementTypeId { get; set; }
        public int ApproverId { get; set; }
        public DateTime? ActionDate { get; set; }
        public ApprovementStatus Status { get; set; }
        public int? ActionType { get; set; }
        public int CreatorId { get; set; }


        public virtual UserEntity Creator { get; set; }
        public virtual UserEntity Approver { get; set; }
        public virtual ApprovementTypeEntity ApprovementType { get; set; }

        //public virtual IEnumerable<AccountTransactionEntity> AccountTransactions { get; set; }
        public virtual IEnumerable<AccountTransactionApprovementEntity> AccountTransactionApprovements { get; set; }
    }
}
