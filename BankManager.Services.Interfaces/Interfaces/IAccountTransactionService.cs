using BankManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManager.Services.Interfaces.Interfaces
{
    public interface IAccountTransactionService
    {
        AccountTransactionEntity GetById(int Id);
        AccountTransactionEntity GetByAccountId(int AccountId);
        AccountTransactionEntity GetByAccountOwnerId(int CreatorId);
        AccountTransactionEntity Create(AccountTransactionEntity entity);
        public void ApproveAccountTransaction(int approvementId, int approvedById);
        void RejectAccountTransaction(int approvementId, int approvedById);

    }
}
