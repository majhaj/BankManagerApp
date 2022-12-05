using BankManager.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManager.DataAccess.Configuration
{
    public class AccountTransactionConfiguration : IEntityTypeConfiguration<AccountTransactionEntity>
    {
        public void Configure(EntityTypeBuilder<AccountTransactionEntity> builder)
        {
            builder.ToTable("AccountTransaction");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("Id").IsRequired();
            builder.Property(x => x.AccountId).HasColumnName("AccountId").IsRequired();
            builder.Property(x => x.TransactionTypeId).HasColumnName("TransactionTypeId").IsRequired();
            builder.Property(x => x.Amount).HasColumnName("Amount").IsRequired();
            builder.Property(x => x.CreationDate).HasColumnName("CreationDate").IsRequired();
            builder.Property(x => x.CreatorId).HasColumnName("CreatorId").IsRequired();
            builder.Property(x => x.FromAccountId).HasColumnName("FromAccountId").IsRequired(false);
            builder.Property(x => x.ToAccountId).HasColumnName("ToAccountId").IsRequired(false);
            builder.Property(x => x.LastModificationDate).HasColumnName("LastModificationDate").IsRequired(false);
            builder.Property(x => x.Status).HasColumnName("TransactionStatus");
            builder.Property(x => x.Description).HasColumnName("Description");

            builder.HasOne(x => x.BankAccount)
                .WithMany(y => y.AccountTransactions)
                .HasForeignKey(x => x.AccountId);

            builder.HasOne(x => x.TransactionType)
               .WithMany(y => y.AccountTransactions)
               .HasForeignKey(x => x.TransactionTypeId);

            builder.HasOne(x => x.Creator)
                .WithMany(y => y.CreatedAccountTransactions)
                .HasForeignKey(x => x.CreatorId);

            builder.Ignore(x => x.PendingApprovmentId);
        }
    }
}
