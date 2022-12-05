using BankManager.DataAccess;
using BankManager.Entities;
using BankManager.Entities.Enums;
using BankManager.Entities.SearchCriteriaModels;
using BankManager.Services.Interfaces;
using BankManager.Services.Interfaces.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankManager.Entities.Extensions;

namespace BankManager.Services
{
    public class AccountTransactionService : IAccountTransactionService
    {
        public IBankManagerContext Context { get; }
        public INotificationService NotificationService { get; }
        public IApprovementService ApprovementService { get; }

        public AccountTransactionService(
            IBankManagerContext bankManagerContext,
            INotificationService notificationService,
            IApprovementService approvementService)
        {
            Context = bankManagerContext;
            NotificationService = notificationService;
            ApprovementService = approvementService;
        }


        public AccountTransactionEntity GetById(int id)
        {
            var result = Context.AccountTransactions
                .Include(x => x.Creator)
                .Include(x => x.BankAccount)
                .ThenInclude(x => x.Owner)
                .Include(x => x.ToAccount)
                .Include(x => x.AccountTransactionApprovements)
                .ThenInclude(x => x.Approvement)
                .ThenInclude(x => x.Approver)
                .FirstOrDefault(x => x.Id == id);

            return result;
        }
        public AccountTransactionEntity GetByAccountId(int accountId)
        {
            var result = Context.AccountTransactions.FirstOrDefault(x => x.AccountId == accountId);
            return result;
        }
        public AccountTransactionEntity GetByAccountOwnerId(int creatorId)
        {
            var result = Context.AccountTransactions.FirstOrDefault();//.FirstOrDefault(x => x.CreatorId == creatorId);
            return result;
        }
        public AccountTransactionEntity Create(AccountTransactionEntity entity)
        {
            entity.CreationDate = DateTime.Now;
            Context.AccountTransactions.Add(entity);

            var approvement = CreateApprovmentForTransaction(entity);

            Context.SaveChanges();


            var savedEntity = Context.AccountTransactions.FirstOrDefault(x => x.Id == entity.Id);
            savedEntity.PendingApprovmentId = approvement.Id;

            return savedEntity;
        }

        public void ApproveAccountTransaction(int approvementId, int approvedById)
        {
            var approvement = ApprovementService.GetByApprovementId(approvementId);

            if (approvement?.ApproverId == approvedById)
            {
                ApprovementService.Approve(approvementId);

                var accountTransactionApprovment = approvement.AccountTransactionApprovements.FirstOrDefault(y => y.ApprovementId == approvementId);

                if (accountTransactionApprovment != null)
                {
                    var accountTransaction = GetById(accountTransactionApprovment.TransactionId);

                    HandleAdditionalAccountOperations(accountTransaction);
                }
            }
        }

        public void RejectAccountTransaction(int approvementId, int approvedById)
        {
            var approvement = ApprovementService.GetByApprovementId(approvementId);

            if (approvement?.ApproverId == approvedById)
            {
                ApprovementService.Reject(approvementId);

                var accountTransactionApprovment = approvement.AccountTransactionApprovements.FirstOrDefault(y => y.ApprovementId == approvementId);

                if (accountTransactionApprovment != null)
                {
                    var accountTransaction = GetById(accountTransactionApprovment.TransactionId);

                    accountTransaction.Status = TransactionStatus.Rejected;

                    Context.SaveChanges();
                }
            }
        }

        private ApprovementEntity CreateApprovmentForTransaction(AccountTransactionEntity accountTransaction)
        {
            var transactionApprovementType = GetApprovmentType(ApprovementTypeCode.Transaction);

            if (transactionApprovementType == null)
            {
                throw new ArgumentException("Missing approvment Type for transaction");
            }

            var approvement = CreateApprovmentForTransaction(accountTransaction, transactionApprovementType);
            Context.Approvements.Add(approvement);
            Context.SaveChanges();

            var accountTransactionApprovment = new AccountTransactionApprovementEntity { TransactionId = accountTransaction.Id, ApprovementId = approvement.Id };
            Context.AccountTransactionApprovements.Add(accountTransactionApprovment);
            Context.SaveChanges();

            NotificationService.Create(new NotificationEntity
            {
                UserToNotifyId = approvement.CreatorId,
                Description = "Przelew przychodzący"
            });

            return approvement;
        }

        private static ApprovementEntity CreateApprovmentForTransaction(AccountTransactionEntity accountTransaction, ApprovementTypeEntity transactionApprovementType)
        {
            return new ApprovementEntity
            {
                Status = ApprovementStatus.Pending,
                CreatorId = accountTransaction.CreatorId,
                ApproverId = accountTransaction.CreatorId,
                CreationDate = DateTime.Now,
                ApprovementTypeId = transactionApprovementType.Id,
            };
        }

        private ApprovementTypeEntity GetApprovmentType(ApprovementTypeCode approvementTypeCode)
        {
            return Context.ApprovementTypes.FirstOrDefault(x => x.Code == approvementTypeCode);
        }

        private void HandleAdditionalAccountOperations(AccountTransactionEntity entity)
        {
            var transactionType = Context.TransactionTypes.FirstOrDefault(x => x.Id == entity.TransactionTypeId);

            var allApprovmentsAccepted = entity.AccountTransactionApprovements
                .Select(x => x.Approvement)
                .All(y => y.Status == ApprovementStatus.Accepted);

            if (transactionType?.Code == TransactionTypeCode.CashTransfer && allApprovmentsAccepted)
            {
                entity.Status = TransactionStatus.Accepted;

                HandleCashTransferAdditionalFlow(entity);

                NotificationService.AddRange(entity.ComposeNotifications());

                Context.SaveChanges();
            }
        }

        private void HandleCashTransferAdditionalFlow(AccountTransactionEntity entity)
        {
            AccountTransactionEntity transactionTo = CreateTransactionTo(entity);
            Context.AccountTransactions.Add(transactionTo);
            Context.SaveChanges();
        }

        private AccountTransactionEntity CreateTransactionTo(AccountTransactionEntity entity)
        {
            return new AccountTransactionEntity
            {
                AccountId = entity.ToAccountId.Value,
                FromAccountId = entity.AccountId,
                Amount = entity.Amount,
                ToAccountId = null,
                CreatorId = entity.CreatorId,
                TransactionTypeId = entity.TransactionTypeId,
                CreationDate = DateTime.Now
            };
        }

        public List<AccountTransactionEntity> GetFiltered(AccountTransactionSearchCriteria searchCriteria)
        {
            var result = Context.AccountTransactions.AsQueryable();

            if (searchCriteria == null)
            {
                throw new ArgumentNullException("searchCriteria");
            }

            if (searchCriteria.DateFrom.HasValue)
            {
                result = result.Where(x => x.CreationDate >= searchCriteria.DateFrom.Value);
            }

            if (searchCriteria.DateTo.HasValue)
            {
                result = result.Where(x => x.CreationDate <= searchCriteria.DateTo.Value);
            }

            if (searchCriteria.TransactionTypeId.HasValue)
            {
                result = result.Where(x => x.TransactionTypeId == searchCriteria.TransactionTypeId);
            }

            if (searchCriteria.AmountFrom.HasValue)
            {
                result = result.Where(x => x.Amount >= searchCriteria.AmountFrom.Value);
            }

            if (searchCriteria.AmountTo.HasValue)
            {
                result = result.Where(x => x.Amount <= searchCriteria.AmountTo.Value);
            }

            if (searchCriteria.ToAccountOwnerIds != null && searchCriteria.ToAccountOwnerIds.Count > 0)
            {

            }

            return result.ToList();
        }



    }
}
