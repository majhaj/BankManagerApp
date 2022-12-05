using BankManager.DataAccess;
using BankManager.Entities;
using BankManager.Entities.Enums;
using BankManager.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManager.Services
{
    public class ApprovementService : IApprovementService
    {
        public IBankManagerContext Context { get; }

        public ApprovementService(IBankManagerContext bankManagerContext)
        {
            Context = bankManagerContext;
        }

        public IEnumerable<ApprovementEntity> GetAllPendingApprovementsByApproverId(int approverId)
        {
            var result = Context.Approvements.Where(x => x.ApproverId == approverId && x.Status == ApprovementStatus.Pending && x.ActionDate == null);

            return result;
        }

        public ApprovementEntity GetByApprovementId(int approvementId)
        {
            var result = Context.Approvements
                    .Include(x => x.AccountTransactionApprovements)
                    .FirstOrDefault(x => x.Id == approvementId);
            return result;
        }

        public void Approve(int approvalId)
        {
            TakeAction(approvalId, ApprovementStatus.Accepted);
        }

        public void Reject(int approvalId)
        {
            TakeAction(approvalId, ApprovementStatus.Rejected);
        }

        private void TakeAction(int approvalId, ApprovementStatus status)
        {
            var toApprove = Context.Approvements.FirstOrDefault(x => x.Id == approvalId);
            toApprove.ActionDate = DateTime.Now;
            toApprove.Status = status;

            Context.SaveChanges();
        }
    }
}
