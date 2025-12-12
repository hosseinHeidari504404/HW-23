using DomainCore.Contracts.AppServicesContracts;
using DomainCore.Dtos.OrderItemDtos;
using DomainCore.Dtos.Z.Other;
using HW_23.Basket_Handeller.Models;
using Newtonsoft.Json;

namespace HW_23.Basket_Handeller.ServiceB
{
    public class BasketService : IBasketService
    {
        private readonly IHttpContextAccessor accessor;
        private readonly IProductAppService productAppService;
        private const string key = "Basket";

        public BasketService(IHttpContextAccessor accessor, IProductAppService productAppService)
        {
            this.accessor = accessor;
            this.productAppService = productAppService;
        }
        public async Task<ResultDto<bool>> AddToBasket(int productId, int count, CancellationToken cancellationToken)
        {

            var product = await productAppService.Get(productId, cancellationToken);

            var basket = GetBasket();

            var basketItem = basket.BasketItems.FirstOrDefault(x => x.ProductId == productId);


            if (count > await productAppService.GetProductCount(productId, cancellationToken))
            {
                return ResultDto<bool>.Failure("Not enough product in stock");
            }

            if (count == 0)
            {
                return await ClearItem(productId, cancellationToken);
            }

            if (basketItem != null)
            {

                basketItem.Count = count;

            }
            else
            {
                basketItem = new BasketItem()
                {
                    Count = count,
                    ProductId = productId,
                    UnitPrice = product.Price,
                };
                basket.BasketItems.Add(basketItem);
            }

            Write(basket);
            return ResultDto<bool>.Success("Order Successfully Added!");

        }

        public async Task<ResultDto<bool>> IncreaseItem(int productId, CancellationToken cancellationToken)
        {

            var product = await productAppService.Get(productId, cancellationToken);

            var basket = GetBasket();

            var basketItem = basket.BasketItems.FirstOrDefault(x => x.ProductId == productId);

            int basketItemCount;
            if (basketItem is null)  //ارور نال رفرنس
            {
                basketItemCount = 0;
            }
            else
            {
                basketItemCount = basketItem.Count;
            }


            return await AddToBasket(productId, basketItemCount + 1, cancellationToken);

        }

        public Basket GetBasket()
        {
            var basketStr = accessor.HttpContext.Session.GetString(key);
            if (basketStr is not null)
            {
                var basket = JsonConvert.DeserializeObject<Basket>(basketStr);
                return basket;
            }
            return new Basket();
        }
        public void Write(Basket basket)
        {

            accessor.HttpContext.Session.SetString(key, JsonConvert.SerializeObject(basket));
        }

        public async Task RemoveItem(int productId, CancellationToken cancellationToken)
        {

            var basket = GetBasket();

            var basketItem = basket.BasketItems.FirstOrDefault(b => b.ProductId == productId);
            if (basketItem != null)
            {
                basketItem.Count--;
                if (basketItem.Count == 0)
                {
                    basket.BasketItems.Remove(basketItem);
                }
                Write(basket);
            }

        }
        

        public async Task<ResultDto<bool>> ClearItem(int productId, CancellationToken cancellationToken)
        {
            var basket = GetBasket();
            var basketItem = basket.BasketItems.FirstOrDefault(b => b.ProductId == productId);
            if (basketItem != null)
            {
                basket.BasketItems.Remove(basketItem);
                Write(basket);
                return ResultDto<bool>.Success("Item Cleared from Basket");
            }
            else
            {
                return ResultDto<bool>.Failure("Item Not Found in Basket");
            }

        }

        public void DeleteBasket()
        {
            accessor.HttpContext.Session.Remove(key);
        }

        public int GetOrderItemCount(int productId)
        {
            var basket = GetBasket();
            return basket.BasketItems.Where(i => i.ProductId == productId).Select(i => i.Count).FirstOrDefault();
        }

        public int GetOrderCount()
        {
            var basket = GetBasket();
            return basket.BasketItems.Sum(b => b.Count);
        }
        public async Task<List<GetOrderItemDto>> GetBasketItems(CancellationToken cancellationToken)
        {
            var basket = GetBasket();

            var result = new List<GetOrderItemDto>();

            foreach (var item in basket.BasketItems)
            {

                var product = await productAppService.Get(item.ProductId, cancellationToken);

                result.Add(new GetOrderItemDto
                {
                    Count = item.Count,
                    ProductName = product.Name,
                    TotalPrice = item.Price,
                    ProductImagePath = product.ImagePath,
                    ProductId = item.ProductId,
                    UnitPrice = item.UnitPrice
                });
            }

            return result;
        }
    }
}
