using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.presistence.configuration
{
    public class SettingConfig : IEntityTypeConfiguration<Setting>
    {
        public void Configure(EntityTypeBuilder<Setting> builder)
        {
            BaseEntityConfigurationHelper.ConfigureBaseEntity(builder);
            builder.Property(x => x.CompanyName).HasMaxLength(20).IsRequired();
            builder.Property(x => x.LogoUrl).HasMaxLength(300).IsRequired(false);
            builder.Property(x => x.Tax).HasPrecision(18,2).HasDefaultValue(0m).IsRequired();
            builder.ToTable(t =>
            {
                t.HasCheckConstraint("CK_Tax", "[Tax] >= 0 and [Tax] <= 100");
            });
            builder.HasOne(x => x.Warehouse).WithOne(x => x.Setting);
            builder.HasIndex(x => x.CompanyName);
            builder.HasIndex(x => x.Tax);
        
        }
    }
}