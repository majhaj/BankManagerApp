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
    public class BankAccountConfiguration : IEntityTypeConfiguration<BankAccountEntity>
    {
        public void Configure(EntityTypeBuilder<BankAccountEntity> builder)
        {
            builder.ToTable("BankAccount");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("Id").IsRequired();
            builder.Property(x => x.BankId).HasColumnName("BankId").IsRequired();
            builder.Property(x => x.CreatorId).HasColumnName("CreatorId").IsRequired();
            builder.Property(x => x.Number).HasColumnName("Number").IsRequired();
            builder.Property(x => x.Balance).HasColumnName("Balance").IsRequired();
            builder.Property(x => x.Interest).HasColumnName("Interest").IsRequired();
            builder.Property(x => x.OwnerId).HasColumnName("OwnerId").IsRequired();
            builder.Property(x => x.CurrencyId).HasColumnName("CurrencyId").IsRequired();


            builder.Property(x => x.CreationDate).HasColumnName("CreationDate").IsRequired();
            builder.Property(x => x.DeletionDate).HasColumnName("DeletionDate").IsRequired(false);
            builder.Property(x => x.LastModificationDate).HasColumnName("LastModificationDate").IsRequired(false);

            builder.HasOne(a => a.Bank)
                .WithMany(b => b.BankAccounts)
                .HasForeignKey(b => b.BankId).IsRequired(true);

            builder.HasOne(a => a.Owner)
               .WithMany(b => b.BankAccounts)
               .HasForeignKey(b => b.OwnerId).IsRequired(true);

            builder.HasOne(a => a.Creator)
              .WithMany(b => b.CreatedBankAccounts)
              .HasForeignKey(b => b.CreatorId).IsRequired(true);

            builder.HasOne(a => a.Currency)
                .WithMany(b => b.BankAccounts)
                .HasForeignKey(b => b.CurrencyId);

            builder.Ignore(x => x.OwnerFormattedData);
        }
    }
}
