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
    public class PurchaseOrderConfig : IEntityTypeConfiguration<PurchaseOrder>
    {
        public void Configure(EntityTypeBuilder<PurchaseOrder> builder)
        {
            BaseEntityConfigurationHelper.ConfigureBaseEntity(builder);
            builder.Property(x => x.Total).HasPrecision(18,2).HasDefaultValue(0m).IsRequired();
            builder.Property(x => x.SupplierId).IsRequired();
            builder.Property(x => x.OrderStatus).HasDefaultValue(enStatus.Pending).HasSentinel(enStatus.Pending).IsRequired();
            builder.Property(x => x.PaymentStatus).HasDefaultValue(enPaymentStatus.Unpaid).HasSentinel(enPaymentStatus.Unpaid).IsRequired();
            builder.ToTable(t =>
            {
                t.HasCheckConstraint("CK_PurschaseOrderStatus", "[OrderStatus] in (1,2,3,4,5)");
                t.HasCheckConstraint("CK_PurschasePaymentStatus", "[OrderStatus] in (1,2,3)");
            });
            builder.ToTable(t => t.HasCheckConstraint("CK_PurchaseOrderTotal", "[Total] >= 0"));
            builder.HasOne(x => x.Supplier).WithMany(x => x.PurchaseOrders).HasForeignKey(k => k.SupplierId);
            builder.HasIndex(x => x.SupplierId);
            builder.HasIndex(x => x.OrderStatus);
            builder.HasIndex(x => x.CreatedAt);
            builder.HasIndex(x => x.PaymentStatus);
   
        }
    }
}