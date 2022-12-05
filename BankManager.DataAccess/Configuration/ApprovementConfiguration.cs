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
    public class ApprovementConfiguration : IEntityTypeConfiguration<ApprovementEntity>
    {
        public void Configure(EntityTypeBuilder<ApprovementEntity> builder)
        {
            builder.ToTable("Approvement");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("Id").IsRequired();
            builder.Property(x => x.ApprovementTypeId).HasColumnName("ApprovementTypeId").IsRequired();
            builder.Property(x => x.ApproverId).HasColumnName("ApproverId").IsRequired();
            builder.Property(x => x.ActionDate).HasColumnName("ActionDate").IsRequired(false);
            builder.Property(x => x.Status).HasColumnName("Status").IsRequired();
            builder.Property(x => x.ActionType).HasColumnName("ActionType").IsRequired(false);

            builder.Property(x => x.CreationDate).HasColumnName("CreationDate").IsRequired();
            builder.Property(x => x.LastModificationDate).HasColumnName("LastModificationDate").IsRequired(false);
            builder.Property(x => x.CreatorId).HasColumnName("CreatorId").IsRequired();

            builder.HasOne(a => a.ApprovementType)
               .WithMany(b => b.Approvements)
               .HasForeignKey(b => b.ApprovementTypeId);

            builder.HasOne(a => a.Approver)
               .WithMany(b => b.Approvements)
               .HasForeignKey(b => b.ApproverId);

            builder.HasOne(x => x.Creator)
                .WithMany(y => y.CreatedApprovements)
                .HasForeignKey(x => x.CreatorId);
        }
    }
}
