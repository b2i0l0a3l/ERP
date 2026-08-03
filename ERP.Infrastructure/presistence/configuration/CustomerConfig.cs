using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.presistence.configuration
{
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            BaseEntityConfigurationHelper.ConfigureBaseEntity(builder);
            builder.Property(x => x.FirstName).HasMaxLength(20).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(20).IsRequired();
            builder.Property(x => x.Info).HasMaxLength(200).IsRequired(false);
            builder.Property(x => x.CreditLimit).HasPrecision(18,2).IsRequired(false);
            builder.HasIndex(x=>x.FirstName);
        }
    }
}