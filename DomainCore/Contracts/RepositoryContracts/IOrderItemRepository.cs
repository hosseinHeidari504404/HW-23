using DomainCore.Dtos.OrderItemDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainCore.Contracts.RepositoryContracts
{
    public interface IOrderItemRepository
    {
        Task<bool> Add(List<CreateOrderItemDto> OrderItems, CancellationToken cancellationToken);
        Task<List<GetOrderItemDto>> GetAll(int orderId, CancellationToken cancellationToken);
    }
}
