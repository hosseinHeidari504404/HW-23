using DomainCore.Contracts.AppServicesContracts;
using DomainCore.Dtos.CategoryDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HW_23.Araes.Adminpages.Pages.Category
{
    [Area(AreaConstants.Admin)]
    public class IndexModel(ICategoryAppService categoryAppService) : PageModel
    {
        public List<GetCategoryDto> Categories { get; set; } = new List<GetCategoryDto>();
        public async Task OnGet(CancellationToken cancellationToken)
        {
            Categories = await categoryAppService.GetAll(cancellationToken);
        }
        public async Task<IActionResult> OnGetDelete(int categoryId, CancellationToken cancellationToken)
        {
            var result = await categoryAppService.Delete(categoryId, cancellationToken);
            TempData["Message"] = result.Message;
            return RedirectToPage("/Category/Index");
        }
    }
}
