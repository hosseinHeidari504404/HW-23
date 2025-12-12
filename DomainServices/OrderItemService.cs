using DomainCore.Contracts.RepositoryContracts;
using DomainCore.Contracts.ServicrsContracts;
using DomainCore.Dtos.OrderItemDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainServices
{
    public class OrderItemService(IOrderItemRepository _repo) : IOrderItemService
    {
        public async Task<bool> AddItems(List<CreateOrderItemDto> OrderItems, CancellationToken cancellationToken)
        {
            return await _repo.Add(OrderItems, cancellationToken);
        }

        public async Task<List<GetOrderItemDto>> GetAll(int orderId, CancellationToken cancellationToken)
        {
            return await _repo.GetAll(orderId, cancellationToken);
        }
    }
}
