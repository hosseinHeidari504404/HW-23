using DomainCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbHandeller.Configorations
{
    public class ProductConfigurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasOne(p => p.Category)
                .WithMany(p => p.Products)
                .HasForeignKey(p => p.CategoryId);

            builder.Property(p => p.Name).HasMaxLength(100);
            builder.Property(p => p.Name).HasMaxLength(200);

            builder.Property(p => p.Price)
                .HasPrecision(18, 3);


            builder.HasData(new List<Product> {
                new Product {Id = 1 , Name = "17 pro max" , CategoryId = 2 , Count = 3 , CreatedAt = new DateTime(2025, 11, 30, 14, 35, 00) , Price = 1400,ImagePath = "/Images/Products/17 max.jpg",Description = "The iPhone 17 Pro Max display has rounded corners that follow a beautiful curved design, and these corners are within a standard rectangle. When measured as a standard rectangular shape, the screen is 6.86 inches diagonally (actual viewable area is less).."},
                new Product {Id = 2 , Name = "Sony 110" , CategoryId = 1 , Count = 5 , CreatedAt = new DateTime(2025, 11, 30, 14, 35, 00) , Price = 600000,ImagePath = "/Images/Products/Sony.jpg",Description = "Offer expires 12/31/25 in the US only at electronics.sony.com. $25 off purchases of $100 or more; or get 10% off select Sony TVs*.."},
                new Product {Id = 3 , Name = "Mac pro" , CategoryId = 3 , Count = 6 , CreatedAt = new DateTime(2025, 11, 30, 14, 35, 00) , Price =700000,ImagePath = "/Images/Products/Mac.jpg",Description = "The MacBook Pro is a line of Mac laptop computers developed and manufactured by Apple. Introduced in 2006, it is the high-end sibling of the MacBook family."},
                new Product {Id = 4 , Name = "Airpod pro" , CategoryId = 4, Count = 4 , CreatedAt = new DateTime(2025, 11, 30, 14, 35, 00) , Price = 200000, ImagePath = "/Images/Products/Airpod.jpg",Description = "AirPods Pro are wireless Bluetooth in-ear headphones designed by Apple, initially introduced on October 30, 2019."},
            });
        }
    }
}
