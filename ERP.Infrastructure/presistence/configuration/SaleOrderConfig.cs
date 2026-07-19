using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Core.Entities;
using ERP.Core.enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.presistence.configuration
{
    public class SaleOrderConfig : IEntityTypeConfiguration<SalesOrder>
    {
        public void Configure(EntityTypeBuilder<SalesOrder> builder)
        {
            BaseEntityConfigurationHelper.ConfigureBaseEntity(builder);
            builder.Property(x => x.CustomerId).IsRequired(false);
            builder.Property(x => x.Status).HasDefaultValue(enStatus.Pending).HasSentinel(enStatus.Pending).IsRequired();
            builder.Property(x => x.PaymentStatus).HasDefaultValue(enPaymentStatus.Unpaid).HasSentinel(enPaymentStatus.Unpaid).IsRequired();
            builder.Property(x => x.Discount).HasPrecision(18,2).HasDefaultValue(0m).IsRequired();
            builder.Property(x => x.Total).HasPrecision(18,2).HasDefaultValue(0m).IsRequired();
            builder.Property(x => x.Total).HasPrecision(18,2).HasDefaultValue(0m).IsRequired();
            builder.Property(x => x.PaidAmount).HasPrecision(18,2).HasDefaultValue(0m).IsRequired();
            builder.ToTable(t =>
            {
                t.HasCheckConstraint("CK_SaleOrderDiscount", "[Discount] >= 0 AND [Discount] < 100 ");
                t.HasCheckConstraint("CK_SaleOrderTotal", "[Total] >= 0");
                t.HasCheckConstraint("CK_SaleOrderStatus", "[Status] in (1,2,3,4,5)");
                t.HasCheckConstraint("CK_SaleOrderPaymentStatus", "[PaymentStatus] in (1,2,3)");
            });
            builder.HasIndex(x => x.CustomerId);
            builder.HasIndex(x => x.CreatedAt);
            builder.HasOne(x => x.Customer).WithMany(x => x.SalesOrders).HasForeignKey(k => k.CustomerId);
        }
    }
}