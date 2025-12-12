using DbHandeller.Db_Access;
using DomainCore.Contracts.RepositoryContracts;
using DomainCore.Dtos.OrderItemDtos;
using DomainCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class OrderItemRepository(AppDbContext context) : IOrderItemRepository
    {
        public async Task<bool> Add(List<CreateOrderItemDto> OrderItems, CancellationToken cancellationToken)
        {
            var entities = OrderItems.Select(o => new OrderItem
            {
                ProductId = o.ProductId,
                OrderId = o.OrderId.Value, 
                Count = o.Count,
                UnitPrice = o.UnitPrice

            }).ToList();

            await context.OrderItems.AddRangeAsync(entities, cancellationToken);
            return await context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<List<GetOrderItemDto>> GetAll(int orderId, CancellationToken cancellationToken)
        {

            return await context.OrderItems
                .AsNoTracking()
                .Where(o => o.OrderId == orderId)
                .Select(o => new GetOrderItemDto
                {
                    Count = o.Count,
                    UnitPrice = o.UnitPrice,
                    ProductId = o.ProductId,
                    ProductImagePath = o.Product.ImagePath,
                    ProductName = o.Product.Name,
                    TotalPrice = o.TotalPrice,

                }).ToListAsync(cancellationToken);
        }
    }
}
