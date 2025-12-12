using DomainCore.Contracts.RepositoryContracts;
using DomainCore.Contracts.ServicrsContracts;
using DomainCore.Dtos.OrderDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainServices
{
    public class OrderService(IOrderRepository _repo) : IOrderService
    {
        public async Task<int> Create(int userId, decimal totalPrice, CancellationToken cancellationToken)
        {
            return await _repo.Create(userId, totalPrice, cancellationToken);
        }

        public async Task<List<GetOrderDto>> GetAll(CancellationToken cancellationToken)
        {
            return await _repo.GetAll(cancellationToken);
        }
    }
}
