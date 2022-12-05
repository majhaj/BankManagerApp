using BankManager.DataAccess.Configuration;
using BankManager.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManager.DataAccess
{
    public class BankManagerContext : DbContext, IBankManagerContext
    {
        public DbSet<BankEntity> Banks { get; set; }
        public DbSet<BankAccountEntity> BankAccounts { get; set; }
        public DbSet<AccountTransactionEntity> AccountTransactions { get; set; }
        public DbSet<TransactionTypeEntity> TransactionTypes { get; set; }
        public DbSet<NotificationEntity> Notifications { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<ApprovementTypeEntity> ApprovementTypes { get; set;}
        public DbSet<ApprovementEntity> Approvements { get; set; }
        public DbSet<AccountTransactionApprovementEntity> AccountTransactionApprovements { get; set; }


        public BankManagerContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BankAccountConfiguration());
            modelBuilder.ApplyConfiguration(new BankConfiguration());
            modelBuilder.ApplyConfiguration(new AccountTransactionConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionTypeConfiguration());
            modelBuilder.ApplyConfiguration(new NotificationConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ApprovementTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ApprovementConfiguration());
            modelBuilder.ApplyConfiguration(new AccountTransactionApprovementConfiguration());
        }
    }
}
