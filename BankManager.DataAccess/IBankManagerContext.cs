using BankManager.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankManager.DataAccess
{
    public interface IBankManagerContext
    {
        DbSet<BankEntity> Banks { get; set; }
        DbSet<BankAccountEntity> BankAccounts { get; set; }
        DbSet<AccountTransactionEntity> AccountTransactions { get; set; }
        DbSet<TransactionTypeEntity> TransactionTypes { get; set; }
        DbSet<NotificationEntity> Notifications { get; set; }
        DbSet<UserEntity> Users { get; set; }
        DbSet<ApprovementTypeEntity> ApprovementTypes { get; set; }
        DbSet<ApprovementEntity> Approvements { get; set;}
        DbSet<AccountTransactionApprovementEntity> AccountTransactionApprovements { get; set; }

        int SaveChanges();
    }
}