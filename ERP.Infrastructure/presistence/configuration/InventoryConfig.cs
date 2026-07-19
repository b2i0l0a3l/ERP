using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.presistence.configuration
{
    public class InventoryConfig : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            BaseEntityConfigurationHelper.ConfigureBaseEntity(builder);
            builder.Property(x => x.Quantity).HasDefaultValue(0).IsRequired();
            builder.ToTable(t =>
            {
                t.HasCheckConstraint("CK_Quantity", "[Quantity] >= 0");
            });

            builder.HasOne(p => p.Product).WithMany(i => i.Inventories).HasForeignKey(k => k.ProductId);
            builder.HasOne(p => p.Warehouse).WithMany(i => i.Inventory).HasForeignKey(k => k.WarehouseId);
            builder.HasIndex(i => i.ProductId);
            builder.HasIndex(i => i.WarehouseId);
            builder.HasIndex(i => new {i.ProductId,i.WarehouseId}).IncludeProperties(i=>i.Quantity);
        }
    }
}