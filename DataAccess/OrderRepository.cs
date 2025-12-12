using DbHandeller.Db_Access;
using DomainCore.Contracts.RepositoryContracts;
using DomainCore.Dtos.OrderDtos;
using DomainCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class OrderRepository(AppDbContext _context) : IOrderRepository
    {
        public async Task<int> Create(int userId, decimal totalPrice, CancellationToken cancellationToken)
        {
            var entity = new Order
            {
                UserId = userId,
                TotalPrice = totalPrice,
            };
            await _context.Orders.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }

        public async Task<List<GetOrderDto>> GetAll(CancellationToken cancellationToken)
        {
            return await _context.Orders.Select(o => new GetOrderDto
            {
                TotalPrice = o.TotalPrice,
                OrderId = o.Id,
                CustomerFullName = $"{o.User.FirstName} {o.User.LastName}",
                CreatedAt = o.CreatedAt

            }).ToListAsync(cancellationToken);
        }
    }
}
