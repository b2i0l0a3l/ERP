using ERP.Core.Entities;
using ERP.Core.enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.presistence.configuration
{
    public class NotificationConfig : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Type).HasDefaultValue(enNotificationType.LowStock).HasSentinel(enNotificationType.LowStock).IsRequired();
            builder.Property(x => x.Priority).HasDefaultValue(enNotificationPriority.Normal).HasSentinel(enNotificationPriority.Normal).IsRequired();
            builder.Property(x => x.Title).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Message).HasMaxLength(1000).IsRequired();
            builder.Property(x => x.RelatedEntityType).HasMaxLength(100).IsRequired(false);
            builder.Property(x => x.TargetUserId).HasMaxLength(450).IsRequired(false);
            builder.Property(x => x.IsRead).HasDefaultValue(false).IsRequired();
            builder.Property(x => x.ReadAt).IsRequired(false);
            builder.Property(x => x.CreatedAt).HasDefaultValueSql("GETDATE()").IsRequired();
            builder.ToTable(t =>
            {
                t.HasCheckConstraint("CK_NotificationType", "[Type] in (1,2,3,4,5,6,7)");
                t.HasCheckConstraint("CK_NotificationPriority", "[Priority] in (1,2,3,4)");
            });
            builder.HasIndex(x => x.TargetUserId);
            builder.HasIndex(x => x.IsRead);
            builder.HasIndex(x => x.CreatedAt);
        }
    }
}
