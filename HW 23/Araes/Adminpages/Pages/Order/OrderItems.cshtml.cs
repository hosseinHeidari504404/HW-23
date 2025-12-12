using DomainCore.Contracts.AppServicesContracts;
using DomainCore.Dtos.OrderItemDtos;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HW_23.Araes.Adminpages.Pages.Order
{
    public class OrderItmesModel(IOrderItemAppService orderItemAppService) : PageModel
    {
        public List<GetOrderItemDto> Items { get; set; }
        public async Task OnGet(int orderId, CancellationToken cancellationToken)
        {
            Items = await orderItemAppService.GetAll(orderId, cancellationToken);
        }
    }
}
