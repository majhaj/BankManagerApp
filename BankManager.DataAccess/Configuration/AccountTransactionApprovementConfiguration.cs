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
    public class AccountTransactionApprovementConfiguration : IEntityTypeConfiguration<AccountTransactionApprovementEntity>
    {
        public void Configure(EntityTypeBuilder<AccountTransactionApprovementEntity> builder)
        {
            builder.ToTable("AccountTransactionApprovement");
            builder.HasKey(x => new {x.TransactionId, x.ApprovementId});

            builder.Property(x => x.TransactionId).HasColumnName("TransactionId").IsRequired();
            builder.Property(x => x.ApprovementId).HasColumnName("ApprovementId").IsRequired();

            builder.HasOne(x => x.AccountTransaction)
                .WithMany(y => y.AccountTransactionApprovements)
                .HasForeignKey(x => x.TransactionId);

            builder.HasOne(x => x.Approvement)
                .WithMany(y => y.AccountTransactionApprovements)
                .HasForeignKey(x => x.ApprovementId);

        }
    }
}
