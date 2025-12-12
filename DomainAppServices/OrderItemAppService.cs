using DomainCore.Contracts.AppServicesContracts;
using DomainCore.Contracts.ServicrsContracts;
using DomainCore.Dtos.OrderItemDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainAppServices
{
    public class OrderItemAppService(IOrderItemService orderItemService, IProductService productService) : IOrderItemAppService
    {
        public async Task<List<GetOrderItemDto>> GetAll(int orderId, CancellationToken cancellationToken)
        {
            return await orderItemService.GetAll(orderId, cancellationToken);
        }
    }
}
