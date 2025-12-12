using DomainCore.Contracts.AppServicesContracts;
using DomainCore.Dtos.ProductDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HW_23.Araes.Adminpages.Pages.Product
{
    [Area(AreaConstants.Admin)]
    public class IndexModel(IProductAppService productAppService) : PageModel
    {
        public List<GetProductDto> Products { get; set; } = new List<GetProductDto>();
        public async Task OnGet(CancellationToken cancellationToken)
        {
            Products = await productAppService.GetAll(cancellationToken);
        }

        public async Task<IActionResult> OnGetDelete(int productId, CancellationToken cancellationToken)
        {
            var result = await productAppService.Delete(productId, cancellationToken);
            if (result.IsSuccess)
            {
                TempData["Message"] = result.Message;
                return RedirectToPage("/Product/Index");
            }
            else
            {
                TempData["ErrorMessage"] = result.Message;
                return RedirectToPage("/Product/");
            }
        }
    }
}
