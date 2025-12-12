using DomainCore.Contracts.AppServicesContracts;
using DomainCore.Dtos.OrderDtos;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HW_23.Araes.Adminpages.Pages.Order
{
    public class IndexModel(IOrderAppService orderAppService) : PageModel
    {
        public List<GetOrderDto> Orders { get; set; } = new List<GetOrderDto>();
        public async Task OnGet(CancellationToken cancellationToken)
        {
            Orders = await orderAppService.GetAll(cancellationToken);
        }
    }
}
