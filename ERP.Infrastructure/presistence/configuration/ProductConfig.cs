using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.presistence.configuration
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            BaseEntityConfigurationHelper.ConfigureBaseEntity(builder);
            builder.ToTable("Products");
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(500).IsRequired(false);
            builder.Property(x => x.SKU).HasMaxLength(20).IsRequired(false);
            builder.Property(x => x.Barcode).HasMaxLength(20).IsRequired(false);

            builder.ToTable(t =>
            {
                t.HasCheckConstraint("CK_SellingPrice", "[SellingPrice] >= 0");
            });
            builder.ToTable(t =>
           {
               t.HasCheckConstraint("CK_CostPrice", "[CostPrice] >= 0");
           });
            builder.Property(x => x.CostPrice).HasPrecision(18, 2).IsRequired();
            builder.Property(x => x.SellingPrice).HasPrecision(18, 2).IsRequired();

            builder.HasOne(c => c.Category).WithMany(p => p.Products).HasForeignKey(k => k.CategoryId).HasConstraintName("FK_CategoryId");
            builder.HasOne(c => c.Brand).WithMany(p => p.Products).HasForeignKey(k => k.BrandId).HasConstraintName("FK_BrandId");

            builder.HasIndex(x => x.Barcode).IsUnique();
            builder.HasIndex(x => x.SKU).IsUnique();
            builder.HasIndex(x => x.CreatedAt);
        }
    }
}