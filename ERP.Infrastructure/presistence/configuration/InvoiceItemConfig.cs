using ERP.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.presistence.configuration
{
    public class InvoiceItemConfig : IEntityTypeConfiguration<InvoiceItem>
    {
        public void Configure(EntityTypeBuilder<InvoiceItem> builder)
        {
            BaseEntityConfigurationHelper.ConfigureBaseEntity(builder);
            builder.Property(x => x.InvoiceId).IsRequired();
            builder.Property(x => x.ProductId).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(200).IsRequired(false);
            builder.Property(x => x.Quantity).IsRequired();
            builder.Property(x => x.UnitPrice).HasPrecision(18, 2).IsRequired();
            builder.Property(x => x.TaxRate).HasPrecision(18, 2).HasDefaultValue(0m).IsRequired();
            builder.Property(x => x.LineTotal).HasPrecision(18, 2).HasComputedColumnSql("CAST((UnitPrice * Quantity) * (1.0 + (TaxRate / 100.0)) AS DECIMAL(18,2))", stored: true).IsRequired();
            builder.ToTable(t =>
            {
                t.HasCheckConstraint("CK_InvoiceItemQuantity", "[Quantity] > 0");
                t.HasCheckConstraint("CK_InvoiceItemUnitPrice", "[UnitPrice] >= 0");
            t.HasCheckConstraint("CK_InvoiceItemTaxRate", "[TaxRate] >= 0 AND [TaxRate] <= 100");
                
            });
            builder.HasOne(i=>i.Invoice).WithMany(i => i.Items).HasForeignKey(k => k.InvoiceId);
            builder.HasOne(x => x.Product).WithMany(i=>i.InvoiceItems).HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.Restrict);
            builder.HasIndex(x => x.InvoiceId);
            builder.HasIndex(x => x.ProductId);
        }
    }
}
