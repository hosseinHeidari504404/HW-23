using Azure.Core;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HW_23.Extensions
{
    public class BasePage : PageModel
    {
        public int GetUserId()
        {
            if (Request.Cookies.TryGetValue("Id", out var userIdStr) &&
                int.TryParse(userIdStr, out var userIdFromCookie))
            {
                return userIdFromCookie;
            }

            throw new Exception("User is not logged in.");
        }

        public bool IsAdmin()
        {
            return Request.Cookies.Any(x => x.Key == "IsAdmin" && x.Value == "1");

            throw new Exception("User is not admin.");
        }

        public bool UserIsLoggedIn()
        {
            return Request.Cookies.Any(x => x.Key == "Id");
        }

    }
}
