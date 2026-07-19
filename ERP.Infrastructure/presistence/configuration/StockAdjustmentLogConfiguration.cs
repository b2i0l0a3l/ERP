using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.presistence.configuration
{
    public class StockAdjustmentLogConfiguration : IEntityTypeConfiguration<StockAdjustmentLog>
    {
        public void Configure(EntityTypeBuilder<StockAdjustmentLog> builder)
        {
            BaseEntityConfigurationHelper.ConfigureBaseEntity(builder);

            builder.ToTable("StockAdjustmentLogs");

            builder.Property(x => x.Reason)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.CreatedAt)
                .HasDefaultValueSql("GETDATE()")
                .IsRequired();

            builder.HasOne(x => x.Product)
                .WithMany()
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Warehouse)
                .WithMany()
                .HasForeignKey(x => x.WarehouseId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.AdjustedByUser)
                .WithMany()
                .HasForeignKey(x => x.AdjustedByUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(x => new { x.ProductId, x.WarehouseId });
            builder.HasIndex(x => x.CreatedAt);
        }

      
    }


}