using Microsoft.AspNetCore.Mvc;
using TestBlog.Core.Services.Users;

namespace TestBlog.Areas.Admin.Controllers
{
    public class AccountController : AdminBaseController
    {
        #region constructor
        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
        #endregion

        #region filter-user
        [HttpGet("filter-user")]
        public async Task<IActionResult> FilterUsers()
        {
            return View(await _userService.GetAllUser());
        }
        #endregion

    }
}
