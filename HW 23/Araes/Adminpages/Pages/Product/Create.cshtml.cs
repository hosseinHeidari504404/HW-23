using DomainCore.Contracts.AppServicesContracts;
using DomainCore.Dtos.CategoryDtos;
using DomainCore.Dtos.ProductDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HW_23.Araes.Adminpages.Pages.Product
{
    [Area(AreaConstants.Admin)]
    public class CreateModel(ILogger<CreateModel> logger, IProductAppService productAppService, ICategoryAppService categoryAppService) : PageModel
    {
        [BindProperty]
        public CreateProductDto CreateProductDto { get; set; }
        public List<GetCategoryDto> Categories { get; set; } = new List<GetCategoryDto>();
        public async Task OnGet(CancellationToken cancellationToken)
        {
            Categories = await categoryAppService.GetAll(cancellationToken);
        }
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {

                return Page();
            }
            var result = await productAppService.Create(CreateProductDto);
            if (result.IsSuccess)
            {
                logger.LogWarning("A product created by admin");
                TempData["Message"] = result.Message;
                return RedirectToPage("/Product/Index");
            }
            else
            {
                TempData["ErrorMessage"] = result.Message;
                return RedirectToPage("/Product/Create");
            }
        }
    }
}
