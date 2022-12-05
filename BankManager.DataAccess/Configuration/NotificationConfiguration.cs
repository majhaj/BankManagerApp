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
    public class NotificationConfiguration : IEntityTypeConfiguration<NotificationEntity>
    {
        public void Configure(EntityTypeBuilder<NotificationEntity> builder)
        {
            builder.ToTable("Notifications");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("Id").IsRequired();
            builder.Property(x => x.NotifiedByApp).HasColumnName("NotifiedByApp").IsRequired();
            builder.Property(x => x.NotifiedByService).HasColumnName("NotifiedByService").IsRequired();
            builder.Property(x => x.Description).HasColumnName("Description").IsRequired();
            builder.Property(x => x.CreatorId).HasColumnName("CreatorId").IsRequired();
            builder.Property(x => x.CreationDate).HasColumnName("CreationDate").IsRequired();
            builder.Property(x => x.UserToNotifyId).HasColumnName("UserToNotifyId").IsRequired();
            builder.Property(x => x.LastModificationDate).HasColumnName("LastModificationDate").IsRequired(false);

            builder.HasOne(x => x.Creator)
                .WithMany(y => y.CreatedNotifications)
                .HasForeignKey(x => x.CreatorId);
        }
    }
}
