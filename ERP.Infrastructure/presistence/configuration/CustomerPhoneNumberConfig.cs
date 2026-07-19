using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.presistence.configuration
{
    public class CustomerPhoneNumberConfig : IEntityTypeConfiguration<CustomerPhoneNumber>
    {
        public void Configure(EntityTypeBuilder<CustomerPhoneNumber> builder)
        {
            BaseEntityConfigurationHelper.ConfigureBaseEntity(builder);
            builder.Property(x => x.PhoneNumber).HasMaxLength(20).IsRequired();
        }
    }
}