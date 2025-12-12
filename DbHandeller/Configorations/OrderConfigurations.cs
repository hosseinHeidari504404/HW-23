using DomainCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbHandeller.Configorations
{
    public class OrderConfigurations : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasMany(o => o.OrderItems)
                .WithOne(o => o.Order)
                .HasForeignKey(o => o.OrderId);

            builder.HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId);

            builder.Property(o => o.TotalPrice)
                .HasPrecision(18, 3);


        }
    }
}
