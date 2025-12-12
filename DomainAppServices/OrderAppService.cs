using DomainCore.Contracts.AppServicesContracts;
using DomainCore.Contracts.ServicrsContracts;
using DomainCore.Dtos.OrderDtos;
using DomainCore.Dtos.Z.Other;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainAppServices
{
    public class OrderAppService(IOrderService orderService, IOrderItemService orderItemService, IUserService userService, IWalletService walletService, IProductService productService) : IOrderAppService
    {
        public Task<List<GetOrderDto>> GetAll(CancellationToken cancellationToken)
        {
            return orderService.GetAll(cancellationToken);
        }

        public async Task<ResultDto<bool>> MakeOrder(CreateOrderDto orderDto, CancellationToken cancellationToken)
        {

            var userWalletBalance = await userService.GetUserWalletBalance(orderDto.UserId, cancellationToken);
            if (userWalletBalance < orderDto.TotalPrice)
            {
                return ResultDto<bool>.Failure("Not enough Balance in your Wallet");
            }

            var newWalletAmount = userWalletBalance - orderDto.TotalPrice;
            var walletDeductionResult = await walletService.Update(orderDto.UserId, newWalletAmount, cancellationToken);
            if (!walletDeductionResult)
                return ResultDto<bool>.Failure("Wallet update failed.");


            var orderCreationResult = await orderService.Create(orderDto.UserId, orderDto.TotalPrice, cancellationToken);
            if (orderCreationResult <= 0)
            {
                return ResultDto<bool>.Failure("Order creation failed.");
            }

            foreach (var item in orderDto.OrederItems)
            {
                item.OrderId = orderCreationResult;
                var newProductStock = await productService.GetProductCount(item.ProductId, cancellationToken) - item.Count;
                var productStockUpdateResult = await productService.UpdateCount(item.ProductId, newProductStock, cancellationToken);
                if (!productStockUpdateResult)
                {
                    return ResultDto<bool>.Failure("Failed to update stock for product.");
                }

            }

            var orderItemCreationResult = await orderItemService.AddItems(orderDto.OrederItems, cancellationToken);
            if (orderItemCreationResult == false)
            {
                return ResultDto<bool>.Failure("Order Item creation failed.");
            }

            return ResultDto<bool>.Success("Checkout done successfully!", false);


        }
    }
}
