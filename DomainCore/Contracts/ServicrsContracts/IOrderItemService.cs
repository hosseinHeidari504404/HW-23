using DomainCore.Dtos.OrderItemDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainCore.Contracts.ServicrsContracts
{
    public interface IOrderItemService
    {
        Task<bool> AddItems(List<CreateOrderItemDto> OrderItems, CancellationToken cancellationToken);
        Task<List<GetOrderItemDto>> GetAll(int orderId, CancellationToken cancellationToken);
    }
}
