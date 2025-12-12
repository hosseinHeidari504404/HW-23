using DomainCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbHandeller.Configorations
{
    public class WalletConfigurations : IEntityTypeConfiguration<Wallet>
    {
        public void Configure(EntityTypeBuilder<Wallet> builder)
        {

            builder.HasData(new List<Wallet>
            {
                new Wallet { Id = 1, Amount = 2000000, UserId = 1 },
                new Wallet { Id = 2, Amount = 3000000, UserId = 2 },
                new Wallet { Id = 3, Amount = 4000000, UserId = 3 },
                new Wallet { Id = 4, Amount = 5000000, UserId = 4 },
            });
        }
    }
}
