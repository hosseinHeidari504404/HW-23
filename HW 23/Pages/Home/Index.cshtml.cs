using DomainCore.Contracts.AppServicesContracts;
using DomainCore.Dtos.CategoryDtos;
using DomainCore.Dtos.ProductDtos;
using HW_23.Basket_Handeller.ServiceB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HW_23.Pages.Home
{
    public class HomeModel(ILogger<HomeModel> logger, IProductAppService productAppService, ICategoryAppService categoryAppService, IBasketService basketService) : PageModel
    {
        private readonly ILogger<HomeModel> _logger = logger;
        public List<GetProductDto> Products { get; set; }
        public List<GetCategoryDto> Categories { get; set; } = new();
        public string Message { get; set; }


        public async Task OnGet(CancellationToken cancellationToken)
        {
            Products = await productAppService.GetAll(cancellationToken);
            Categories = await categoryAppService.GetAll(cancellationToken);

        }

        public async Task<IActionResult> OnPostAddToBasket(int productId, CancellationToken cancellationToken)
        {
            var result = await basketService.IncreaseItem(productId, cancellationToken);
            Message = result.Message;


            _logger.LogInformation("User Added Product In Home Page");
            return RedirectToPage("/Home/Index");
        }
    }
}
