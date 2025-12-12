using DomainCore.Contracts.AppServicesContracts;
using DomainCore.Dtos.CategoryDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HW_23.Araes.Adminpages.Pages.Category
{
    [Area(AreaConstants.Admin)]
    public class UpdateModel(ICategoryAppService categoryAppService) : PageModel
    {
        [BindProperty]
        public GetCategoryDto CategoryDto { get; set; } = new GetCategoryDto();
        public async Task OnGet(int categoryId, CancellationToken cancellationToken)
        {
            CategoryDto = await categoryAppService.GetById(categoryId, cancellationToken);
        }
        public async Task<IActionResult> OnPost(CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {

                return Page();
            }

            var result = await categoryAppService.Update(CategoryDto, cancellationToken);
            if (result.IsSuccess)
            {
                TempData["Message"] = result.Message;
                return RedirectToPage("/Category/Index", new { CategoryDto.Id });
            }
            else
            {
                TempData["ErrorMessage"] = result.Message;
                return RedirectToPage("/Category/Update");
            }
        }
    }
}

