using DomainCore.Dtos.OrderDtos;
using DomainCore.Dtos.Z.Other;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainCore.Contracts.AppServicesContracts
{
    public interface IOrderAppService
    {
        Task<ResultDto<bool>> MakeOrder(CreateOrderDto orderDto, CancellationToken cancellationToken);
        Task<List<GetOrderDto>> GetAll(CancellationToken cancellationToken);
    }
}
