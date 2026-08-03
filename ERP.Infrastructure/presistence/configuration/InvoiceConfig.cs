using ERP.Core.Entities;
using ERP.Core.enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.presistence.configuration
{
    public class InvoiceConfig : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            BaseEntityConfigurationHelper.ConfigureBaseEntity(builder);
            builder.Property(x => x.InvoiceNumber).HasMaxLength(50).IsRequired(false); 
            builder.Property(x => x.Type).HasDefaultValue(enInvoiceType.Sale).HasSentinel(enInvoiceType.Sale).IsRequired();
            builder.Property(x => x.Status).HasDefaultValue(enInvoiceStatus.Draft).HasSentinel(enInvoiceStatus.Draft).IsRequired();
            builder.Property(x => x.CustomerId).IsRequired(false);
            builder.Property(x => x.SalesOrderId).IsRequired(false);
            builder.Property(x => x.SupplierId).IsRequired(false);
            builder.Property(x => x.IssueDate).HasDefaultValueSql("GETDATE()").IsRequired();
            builder.Property(x => x.DueDate).IsRequired(false);
            builder.Property(x => x.SubTotal).HasPrecision(18, 2).HasDefaultValue(0m).IsRequired();
            builder.Property(x => x.TaxAmount).HasPrecision(18, 2).HasDefaultValue(0m).IsRequired();
            builder.Property(x => x.DiscountAmount).HasPrecision(18, 2).HasDefaultValue(0m).IsRequired();
            builder.Property(x => x.TotalAmount).HasPrecision(18, 2).HasDefaultValue(0m).IsRequired();
            builder.Property(x => x.Notes).HasMaxLength(500).IsRequired(false);
            builder.ToTable(t =>
            {
                t.HasCheckConstraint("CK_InvoiceSubTotal", "[SubTotal] >= 0");
                t.HasCheckConstraint("CK_InvoiceTaxAmount", "[TaxAmount] >= 0");
                t.HasCheckConstraint("CK_InvoiceDiscountAmount", "[DiscountAmount] >= 0");
                t.HasCheckConstraint("CK_InvoiceTotalAmount", "[TotalAmount] >= 0");
                t.HasCheckConstraint("CK_InvoiceType", "[Type] in (1,2,3)");
                t.HasCheckConstraint("CK_InvoiceStatus", "[Status] in (1,2,3,4)");
            });
            builder.HasOne(s => s.SalesOrder).WithMany(i => i.Invoices).HasForeignKey(k => k.SalesOrderId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Customer).WithMany(i=>i.Invoices).HasForeignKey(x => x.CustomerId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Supplier).WithMany(i=>i.Invoices).HasForeignKey(x => x.SupplierId).OnDelete(DeleteBehavior.Restrict);
            builder.HasIndex(x => x.CustomerId);
            builder.HasIndex(x => x.SupplierId);
            builder.HasIndex(x => x.InvoiceNumber);
            builder.HasIndex(x => x.CreatedAt);
        }
    }
}
