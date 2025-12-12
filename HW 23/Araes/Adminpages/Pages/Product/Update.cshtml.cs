using DomainCore.Contracts.AppServicesContracts;
using DomainCore.Dtos.CategoryDtos;
using DomainCore.Dtos.ProductDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HW_23.Araes.Adminpages.Pages.Product
{
    [Area(AreaConstants.Admin)]
    public class UpdateModel(ILogger<UpdateModel> logger, IProductAppService productAppService, ICategoryAppService categoryAppService) : PageModel
    {
        [BindProperty]
        public UpdateProductDto updateProductDto { get; set; }
        public List<GetCategoryDto> Categories { get; set; } = new List<GetCategoryDto>();
        public async Task OnGet(int productId, CancellationToken cancellationToken)
        {
            updateProductDto = await productAppService.GetUpdatedProduct(productId, cancellationToken);
            Categories = await categoryAppService.GetAll(cancellationToken);
        }
        public async Task<IActionResult> OnPost(CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {

                return Page();
            }
            var result = await productAppService.Update(updateProductDto, cancellationToken);
            if (result.IsSuccess)
            {
                logger.LogWarning("A product updated by admin");
                TempData["Message"] = result.Message;
                return RedirectToPage("/Product/Index", new { updateProductDto.Id });
            }
            else
            {
                TempData["ErrorMessage"] = result.Message;
                return RedirectToPage("/Product/Update");
            }
        }
    }
}
