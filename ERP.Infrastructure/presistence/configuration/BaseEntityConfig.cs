using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.presistence.configuration
{
    public static class BaseEntityConfigurationHelper
    {
        public static void ConfigureBaseEntity<T>(EntityTypeBuilder<T> builder) 
            where T : BaseEntity
        {
            builder.HasKey(x => x.Id);

                     builder.Property(x => x.CreatedAt)
                            .HasDefaultValueSql("GETDATE()")
                            .IsRequired();
                   
                   builder.Property(x => x.UpdatedAt)
                   .HasDefaultValueSql("GETDATE()")
                   .IsRequired();

            builder.Property(x => x.IsDeleted)
                   .IsRequired()
                   .HasDefaultValue(false);

            builder.Property(x => x.DeletedAt)
                   .IsRequired(false);

            builder.Property(x => x.DeletedByUserId)
                   .HasMaxLength(450);

            builder.Property(x => x.CreatedByUserId)
                   .HasMaxLength(450);

            builder.HasOne(x => x.CreatedByUser)
                   .WithMany()
                   .HasForeignKey(x => x.CreatedByUserId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.DeletedByUser)
                   .WithMany()
                   .HasForeignKey(x => x.DeletedByUserId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}