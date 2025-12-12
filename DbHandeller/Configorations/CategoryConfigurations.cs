using DomainCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbHandeller.Configorations
{
    public class CategoryConfigurations : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);

            builder.Property(p => p.Name).HasMaxLength(50);

            builder.HasData(new List<Category>
            {
               new Category { Id = 1 , Name = "Television" , ImagePath = "/Images/Category/Television.jpg",Description = "For better show"},
                new Category { Id = 2 , Name = "Iphone",ImagePath = "/Images/Category/Iphone.png" ,Description = "to easy work"},
                new Category { Id = 3 , Name = "Laptop",ImagePath = "/Images/Category/Laptop.jpg" , Description = "for daily use"},
                new Category { Id = 4 , Name = "Airpods",ImagePath = "/Images/Category/Airpods.jpg" , Description= "for Music lover"},
            });
        }
    }
}
