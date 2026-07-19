using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.presistence.configuration
{
    public class WarehouseConfig : IEntityTypeConfiguration<Warehouse>
    {
        
        public void Configure(EntityTypeBuilder<Warehouse> builder)
        {
            BaseEntityConfigurationHelper.ConfigureBaseEntity(builder);
            builder.Property(x => x.Name).HasMaxLength(20).IsRequired();
            builder.HasIndex(x => x.Name);
            
        }
    }
}