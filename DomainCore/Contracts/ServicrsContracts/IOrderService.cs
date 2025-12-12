using DomainCore.Dtos.OrderDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainCore.Contracts.ServicrsContracts
{
    public interface IOrderService
    {
        Task<int> Create(int userId, decimal totalPrice, CancellationToken cancellationToken);
        Task<List<GetOrderDto>> GetAll(CancellationToken cancellationToken);
    }
}
