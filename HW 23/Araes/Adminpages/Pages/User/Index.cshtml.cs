using DomainCore.Contracts.AppServicesContracts;
using DomainCore.Dtos.UserDtos;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HW_23.Araes.Adminpages.Pages.User
{
    public class IndexModel(IUserAppService userAppService) : PageModel
    {
        public List<GetUserDto> Users { get; set; } = new List<GetUserDto>();

        public async Task OnGet(CancellationToken cancellationToken)
        {
            Users = await userAppService.GetUsers(cancellationToken);
        }
    }
}
}
