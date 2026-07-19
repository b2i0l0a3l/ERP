using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.presistence.configuration
{
    public class SaleOrderItemConfig : IEntityTypeConfiguration<SalesOrderItem>
    {
        public void Configure(EntityTypeBuilder<SalesOrderItem> builder)
        {
            BaseEntityConfigurationHelper.ConfigureBaseEntity(builder);
            builder.Property(x => x.ProductId).IsRequired();
            builder.Property(x => x.Total).HasPrecision(18, 2).HasDefaultValue(0m).IsRequired();
            builder.Property(x => x.Discount).HasPrecision(18, 2).HasDefaultValue(0m).IsRequired();
            builder.Property(x => x.SellingPrice).HasPrecision(18, 2).IsRequired();
            builder.ToTable(t =>
            {
                t.HasCheckConstraint("CK_SaleOrderItemTotal", "[Total] >=0");
                t.HasCheckConstraint("CK_SaleOrderItemDiscount", "[Discount] >=0 And [Discount] < 100");
                t.HasCheckConstraint("CK_SaleOrderItemSellingPrice", "[SellingPrice] >= 0 ");
            });
            builder.HasOne(p => p.Product).WithMany(s => s.SalesOrderItems).HasForeignKey(k => k.ProductId);
            builder.HasOne(p => p.SalesOrder).WithMany(s => s.SalesOrderItems).HasForeignKey(k => k.SalesOrderId);

            builder.HasIndex(x => x.ProductId);
            builder.HasIndex(x => x.SalesOrderId)
            .IncludeProperties(x => new { x.Quantity, x.SellingPrice, x.Discount, x.Total });
        }
    }
}