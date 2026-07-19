using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.presistence.configuration
{
    public class PurchaseOrderItemConfig : IEntityTypeConfiguration<PurchaseOrderItem>
    {
        public void Configure(EntityTypeBuilder<PurchaseOrderItem> builder)
        {
            BaseEntityConfigurationHelper.ConfigureBaseEntity(builder);
            builder.Property(x => x.Quantity).IsRequired();
            builder.Property(x => x.PurchaseOrderId).IsRequired();
            builder.Property(x => x.Price).HasPrecision(18,2).IsRequired();
            builder.Property(x => x.ProductId).IsRequired();
            builder.ToTable(t =>
            {
                t.HasCheckConstraint("CK_PurchaseOrderItemQuantity", "[Quantity] >= 0");
                t.HasCheckConstraint("CK_PurchaseOrderItemPrice", "[Price] >= 0");
            });
            builder.HasOne(x => x.Product).WithMany(x => x.PurchaseOrderItems).HasForeignKey(k => k.ProductId);
            builder.HasIndex(x => x.CreatedAt);
            builder.HasIndex(x => x.ProductId);
        
            builder.HasOne(x => x.PurchaseOrder).WithMany(x => x.PurchaseOrderItems).HasForeignKey(k => k.PurchaseOrderId);
        }
    }
}