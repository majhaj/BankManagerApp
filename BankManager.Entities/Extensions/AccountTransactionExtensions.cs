using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManager.Entities.Extensions
{
    public static class AccountTransactionExtensions
    {
        public static List<NotificationEntity> ComposeNotifications(this AccountTransactionEntity accountTransactionEntity)
        {
            var notifications = new List<NotificationEntity>();

            if (accountTransactionEntity.TransactionType.Code == Enums.TransactionTypeCode.CashTransfer)
            {
                CashTransferNotification(accountTransactionEntity, notifications);
            }

            if (accountTransactionEntity.TransactionType.Code == Enums.TransactionTypeCode.CashWithdrawalATM)
            {
                var notificationCashWithdrawalATM = new NotificationEntity
                {
                    CreatorId = accountTransactionEntity.CreatorId,
                    Description = "Wypłata gotówki z konta w bankomacie",
                    UserToNotifyId = accountTransactionEntity.BankAccount.OwnerId,
                };

                notifications.Add(notificationCashWithdrawalATM);
            }

            if (accountTransactionEntity.TransactionType.Code == Enums.TransactionTypeCode.CashWithdrawalBranch)
            {
                var notificationCashWithdrawalBranch = new NotificationEntity
                {
                    CreatorId = accountTransactionEntity.CreatorId,
                    Description = "Wypłata gotówki z konta w oddziale banku",
                    UserToNotifyId = accountTransactionEntity.BankAccount.OwnerId,
                };

                notifications.Add(notificationCashWithdrawalBranch);
            }

            return notifications;
        }


        private static void CashTransferNotification(AccountTransactionEntity accountTransactionEntity, List<NotificationEntity> notifications)
        {
            var notificationFromAccount = new NotificationEntity
            {
                CreatorId = accountTransactionEntity.CreatorId,
                Description = $"Saldo pomniejszone o {accountTransactionEntity.Amount}",
                UserToNotifyId = accountTransactionEntity.BankAccount.OwnerId,
            };

            notifications.Add(notificationFromAccount);

            var notificationToAccount = new NotificationEntity
            {
                CreatorId = accountTransactionEntity.CreatorId,
                Description = $"Saldo powiększone o {accountTransactionEntity.Amount}",
                UserToNotifyId = accountTransactionEntity.ToAccount.OwnerId,
            };

            notifications.Add(notificationToAccount);
        }
    }
}
