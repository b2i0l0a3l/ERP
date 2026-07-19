using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.presistence.configuration
{
    public class ReturnItemConfig : IEntityTypeConfiguration<ReturnItem>
    {
        public void Configure(EntityTypeBuilder<ReturnItem> builder)
        {
            BaseEntityConfigurationHelper.ConfigureBaseEntity(builder);
            builder.Property(p => p.Condition).IsRequired();
            builder.Property(p => p.RefundAmount).HasPrecision(18,2).IsRequired();
            builder.ToTable(t =>
            {
                t.HasCheckConstraint("CK_RefundAmount", "[RefundAmount] >= 0");
                t.HasCheckConstraint("CK_ReturnCondition", "[Condition] in (1,2)");
                t.HasCheckConstraint("CK_ReturnQuantity", "[Quantity] > 0");
            });
            builder.HasOne(p => p.Product).WithMany(r => r.ReturnItems).HasForeignKey(k => k.ProductId);
            builder.HasIndex(x => x.Condition);
            builder.HasIndex(x => x.ProductId);
        }
    }
}