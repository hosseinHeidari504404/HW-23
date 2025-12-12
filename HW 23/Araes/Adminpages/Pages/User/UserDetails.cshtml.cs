using DomainCore.Contracts.AppServicesContracts;
using DomainCore.Dtos.UserDtos;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HW_23.Araes.Adminpages.Pages.User
{
    public class UserDetailsModel(IUserAppService userAppService) : PageModel
    {
        public GetUserDto UserDetails { get; set; } = new GetUserDto();
        public async Task OnGet(int userId, CancellationToken cancellationToken)
        {
            UserDetails = await userAppService.GetUserDetails(userId, cancellationToken);
        }
    }
}
