using BankManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManager.Services.Interfaces
{
    public interface IApprovementService
    {
        IEnumerable<ApprovementEntity> GetAllPendingApprovementsByApproverId(int approverId);
        ApprovementEntity GetByApprovementId(int approvementId);
        void Approve(int approvalId);
        void Reject(int approvalId);
    }
}
