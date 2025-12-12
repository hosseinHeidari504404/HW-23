using DomainCore.Contracts.AppServicesContracts;
using DomainCore.Dtos.OrderDtos;
using DomainCore.Dtos.OrderItemDtos;
using HW_23.Basket_Handeller.ServiceB;
using HW_23.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace HW_23.Pages.Cart
{
    public class IndexModel(ILogger<IndexModel> _logger, IBasketService basketService, IOrderAppService orderAppService) : BasePage
    {
        public List<GetOrderItemDto> OrderItems { get; set; } = new();

        public string Message { get; set; }
        public async Task OnGet(CancellationToken cancellationToken)
        {
            OrderItems = await basketService.GetBasketItems(cancellationToken);
        }
        public async Task<IActionResult> OnGetAdd(int productId, CancellationToken cancellationToken)
        {
            var result = await basketService.IncreaseItem(productId, cancellationToken);
            Message = result.Message;
            _logger.LogInformation("User add increased one item to their basket");
            return RedirectToPage("/Cart/Index");
        }
        public async Task<IActionResult> OnGetReduct(int productId, CancellationToken cancellationToken)
        {
            await basketService.RemoveItem(productId, cancellationToken);
            _logger.LogInformation("User removed one item of their basker");
            return RedirectToPage("/Cart/Index");
        }
        public async Task<IActionResult> OnGetClearItem(int productId, CancellationToken cancellationToken)
        {
            await basketService.ClearItem(productId, cancellationToken);
            _logger.LogInformation("User cleared one item of their basker");
            return RedirectToPage("/Cart/Index");
        }
        public async Task<IActionResult> OnGetCheckOut(CancellationToken cancellationToken)
        {
            if (UserIsLoggedIn())
            {
                var basketItems = await basketService.GetBasketItems(cancellationToken);
                List<CreateOrderItemDto> orderItems = new List<CreateOrderItemDto>();
                foreach (var item in basketItems)
                {
                    var orderItem = new CreateOrderItemDto
                    {
                        ProductId = item.ProductId,
                        Count = item.Count,
                        UnitPrice = item.UnitPrice,
                    };
                    orderItems.Add(orderItem);
                }

                var Order = new CreateOrderDto()
                {
                    OrederItems = orderItems,
                    UserId = GetUserId(),
                    TotalPrice = basketItems.Sum(x => x.UnitPrice * x.Count)
                };
                var checkoutResult = await orderAppService.MakeOrder(Order, cancellationToken);

                if (checkoutResult.IsSuccess)
                {
                    _logger.LogWarning("Product stock updated");
                    _logger.LogInformation("User checkedout");
                    TempData["AccountMessage"] = checkoutResult.Message;
                    basketService.DeleteBasket();

                    return RedirectToPage("/Home/Index");

                }

                _logger.LogError("Failed in Checkout");
                TempData["ErrorMessage"] = checkoutResult.Message;
                return RedirectToPage("/Cart/Index");
            }
            else
            {
                return RedirectToPage("/Account/Login");
            }
        }

    }
}
