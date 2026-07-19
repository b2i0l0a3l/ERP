using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.presistence.configuration
{
    public class CustomerAddressConfig : IEntityTypeConfiguration<CustomerAddress>
    {
        public void Configure(EntityTypeBuilder<CustomerAddress> builder)
        {
            BaseEntityConfigurationHelper.ConfigureBaseEntity(builder);
            builder.Property(x => x.Name).HasMaxLength(20).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(20).IsRequired();
            builder.HasOne(x => x.Customer).WithMany(c => c.CustomerAddresses).HasForeignKey(k => k.CustomerId);
            builder.HasIndex(x => x.Name);
       
        }
    }
}