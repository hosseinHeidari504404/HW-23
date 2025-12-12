using DomainCore.Dtos.OrderItemDtos;
using DomainCore.Dtos.Z.Other;
using HW_23.Basket_Handeller.Models;

namespace HW_23.Basket_Handeller.ServiceB
{
    public interface IBasketService
    {
        Task<ResultDto<bool>> AddToBasket(int productId, int count, CancellationToken cancellationToken);
        Basket GetBasket();
        void Write(Basket basket);
        Task<ResultDto<bool>> ClearItem(int productId, CancellationToken cancellationToken);
        Task RemoveItem(int productId, CancellationToken cancellationToken);
        Task<ResultDto<bool>> IncreaseItem(int productId, CancellationToken cancellationToken);
        void DeleteBasket();
        Task<List<GetOrderItemDto>> GetBasketItems(CancellationToken cancellationToken);
        int GetOrderCount();
        int GetOrderItemCount(int productId);
    }
}
