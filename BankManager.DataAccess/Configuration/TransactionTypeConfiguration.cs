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
    public class TransactionTypeConfiguration : IEntityTypeConfiguration<TransactionTypeEntity>
    {
        public void Configure(EntityTypeBuilder<TransactionTypeEntity> builder)
        {
            builder.ToTable("TransactionType");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("Id").IsRequired();
            builder.Property(x => x.Name).HasColumnName("Name").IsRequired();
            builder.Property(x => x.CreationDate).HasColumnName("CreationDate").IsRequired();
            builder.Property(x => x.CreatorId).HasColumnName("CreatorId").IsRequired();
            builder.Property(x => x.Code).HasColumnName("Code").IsRequired();
            builder.Property(x => x.LastModificationDate).HasColumnName("LastModificationDate").IsRequired(false);

            builder.HasOne(x => x.Creator)
                .WithMany(y => y.CreatedTransactionTypes)
                .HasForeignKey(x => x.CreatorId);

        }
    }
}
