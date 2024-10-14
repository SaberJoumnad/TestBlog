using Microsoft.AspNetCore.Mvc;
using TestBlog.Core.Extensions;
using TestBlog.Core.Services.Users;

namespace TestBlog.Areas.User.ViewComponents
{
    #region UserSideBar
    public class UserSideBarViewComponent : ViewComponent
    {
        private readonly IUserService _userService;
        public UserSideBarViewComponent(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = await _userService.GetUserById(User.GetUserId());
                return View("UserSideBar", user);
            }

            return View("UserSideBar");
        }
    }
    #endregion

    #region UserInformation
    public class UserInformationViewComponent : ViewComponent
    {
        private readonly IUserService _userService;
        public UserInformationViewComponent(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = await _userService.GetUserById(User.GetUserId());
                return View("UserInformation", user);
            }
            return View("UserInformation");
        }
    }
    #endregion

}
