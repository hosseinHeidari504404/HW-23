using DomainCore.Contracts.AppServicesContracts;
using DomainCore.Dtos.CategoryDtos;
using HW_23.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace HW_23.Araes.Adminpages.Pages.Category
{
    [Area(AreaConstants.Admin)]
    public class CreateModel(ICategoryAppService categoryAppService) : BasePage
    {
        [BindProperty]
        public CreateCategoryDto CategoryDto { get; set; }
        public void OnGet()
        {

            CategoryDto = new CreateCategoryDto();
            throw new Exception("Test error log");
        }
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {

                return Page();
            }
            var result = await categoryAppService.Create(CategoryDto);
            if (result.IsSuccess)
            {
                TempData["Message"] = result.Message;
                return RedirectToPage("/Category/Index");
            }
            else
            {
                TempData["ErrorMessage"] = result.Message;
                return RedirectToPage("/Category/Create");
            }
        }
    }
}
