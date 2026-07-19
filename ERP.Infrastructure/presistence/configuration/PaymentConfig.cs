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
    public class PaymentConfig : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            BaseEntityConfigurationHelper.ConfigureBaseEntity(builder);
            builder.Property(x => x.Amount).HasPrecision(18,2).HasDefaultValue(0).IsRequired();
            builder.Property(x => x.Notes).HasMaxLength(200).IsRequired(false);
            builder.Property(x => x.PaymentMethod).HasDefaultValue(enPaymentMethod.Cash).HasSentinel(enPaymentMethod.Cash).IsRequired();
            builder.Property(x => x.ReferenceNumber).HasMaxLength(100).IsRequired(false);
            builder.ToTable(t =>
            {
                t.HasCheckConstraint("CK_PaymentAmount", "[Amount] > 0");
                t.HasCheckConstraint("CK_PaymentMethod", "[PaymentMethod] in (0,1,2)");
            });
            builder.HasOne(x => x.PurchaseOrder).WithMany(x => x.Payments).HasForeignKey(k => k.PurchaseOrderId);
            builder.HasOne(x => x.SalesOrder).WithMany(x => x.Payments).HasForeignKey(k => k.SaleOrderId);
            builder.HasIndex(x => x.PurchaseOrderId);
            builder.HasIndex(x => x.SaleOrderId);
            builder.HasIndex(x => x.CreatedAt);

        }
    }
}