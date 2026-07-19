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
    public class ReturnConfig : IEntityTypeConfiguration<Return>
    {
        public void Configure(EntityTypeBuilder<Return> builder)
        {
            BaseEntityConfigurationHelper.ConfigureBaseEntity(builder);
            builder.Property(x => x.Status).HasDefaultValue(enReturnStatus.Pending).HasSentinel(enReturnStatus.Pending).IsRequired();
            builder.Property(x => x.Reason).HasMaxLength(500).IsRequired(false);
            builder.ToTable(t =>
            {
                t.HasCheckConstraint("CK_ReturnStatus", "[Status] in (1,2,3)");
            });
            builder.HasOne(s => s.SalesOrder).WithMany(r => r.Returns).HasForeignKey(k => k.SalesOrderId);
            builder.HasIndex(i=>i.CreatedAt);
            builder.HasIndex(i=>i.SalesOrderId);
            builder.HasIndex(i=>i.Status);
        }
    }
}