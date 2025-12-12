using DomainCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbHandeller.Configorations
{
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasOne(u => u.Wallet)
                .WithOne(w => w.User)
                .HasForeignKey<Wallet>(w => w.UserId);

            builder.HasMany(u => u.Orders)
                .WithOne(o => o.User)
                .HasForeignKey(o => o.UserId);

            builder.Property(u => u.Username).HasMaxLength(50);
            builder.Property(u => u.PasswordHash).HasMaxLength(50);
            builder.Property(u => u.Address).HasMaxLength(500);
            builder.Property(u => u.FirstName).HasMaxLength(50);
            builder.Property(u => u.LastName).HasMaxLength(50);

            builder.HasData(new List<User>
            {
                new User { Id = 1, FirstName ="Hossein" , LastName ="Heidari" , Address = "Tehran,piroozi",PasswordHash = "1234", CreatedAt = new DateTime(2025, 11, 30, 14, 35, 00),Phone = "09101234563",Username="Hossein" },
                new User { Id = 2, FirstName ="Ali" , LastName ="Mahmoodi" , Address = "Karaj,Jahanshar",PasswordHash = "1234", CreatedAt = new DateTime(2025, 11, 30, 14, 35, 00),Phone = "09101234563",Username="Alii" },
                new User { Id = 3, FirstName ="Mehdi" , LastName ="Rezaii" , Address = "Karaj,Banafshe",PasswordHash = "1234", CreatedAt = new DateTime(2025, 11, 30, 14, 35, 00),Phone = "09101234563",Username="Mehdii" },
                new User { Id = 4, FirstName ="Mmd" , LastName ="Ahmadi" , Address = "Tehran,piroozi",PasswordHash = "1234", CreatedAt = new DateTime(2025, 11, 30, 14, 35, 00),Phone = "09101234563",Username="Mmdd" }
            });
        }
    }
}
