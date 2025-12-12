using DomainCore.Contracts.AppServicesContracts;
using DomainCore.Dtos.CategoryDtos;
using DomainCore.Dtos.ProductDtos;
using HW_23.Basket_Handeller.ServiceB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HW_23.Pages.Product
{
    public class CategoryProductsModel(ILogger<CategoryProductsModel> _logger, IProductAppService productAppService, ICategoryAppService categoryAppService, IBasketService basketService) : PageModel
    {
        public List<GetProductDto> ProductDtos { get; set; } = new List<GetProductDto>();
        public GetCategoryDto Category { get; set; } = new GetCategoryDto();
        public string Message { get; set; }
        public async Task OnGet(int categoryId, CancellationToken cancellationToken)
        {
            ProductDtos = await productAppService.GetCategoryProducts(categoryId, cancellationToken);
            Category = await categoryAppService.GetById(categoryId, cancellationToken);
            _logger.LogInformation("User Viewed Category Products");
        }
        public async Task<IActionResult> OnPostAddToBasket(int productId, int categoryId, CancellationToken cancellationToken)
        {
            var result = await basketService.IncreaseItem(productId, cancellationToken);
            Message = result.Message;

            _logger.LogInformation("User Added Product In Home Page");
            return RedirectToPage("/Product/CategoryProducts", new { categoryId });
        }
    }
}
