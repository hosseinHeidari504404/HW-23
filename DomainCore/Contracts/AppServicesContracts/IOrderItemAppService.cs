using DomainCore.Dtos.OrderItemDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainCore.Contracts.AppServicesContracts
{
    public interface IOrderItemAppService
    {
        Task<List<GetOrderItemDto>> GetAll(int orderId, CancellationToken cancellationToken);
    }
}
