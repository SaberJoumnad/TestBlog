using Microsoft.AspNetCore.Mvc;
using TestBlog.Core.Services.Users;

namespace TestBlog.ViewComponets
{
    #region site header

    public class SiteHeaderViewComponent : ViewComponent
    {
        private readonly IUserService _userService;
        public SiteHeaderViewComponent(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.User = await _userService.GetUserByPhoneNumber(User.Identity.Name);
            }
            return View("SiteHeader");
        }
    }

    #endregion

}
