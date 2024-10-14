using Microsoft.AspNetCore.Mvc;
using TestBlog.Core.Extensions;
using TestBlog.Core.Services.Users;
using TestBlog.Core.ViewModels.Site.Account;

namespace TestBlog.Areas.User.Controllers
{
    public class AccountController : UserBaseController
    {
        #region constructor
        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
        #endregion

        #region edit user profile
        [HttpGet("edit-user-profile")]
        public async Task<IActionResult> EditUserProfile()
        {
            var user = await _userService.GetEditUserProfile(User.GetUserId());
            if (user == null) return NotFound();

            return View(user);
        }

        [HttpPost("edit-user-profile"), ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUserProfile(EditUserProfileViewModel editUserProfile)
        {
            var result = await _userService.EditProfile(User.GetUserId(), editUserProfile);
            if (result != null)
            {
                switch (result)
                {
                    case EditUserProfileResult.NotFound:
                        TempData[WarningMessage] = "کاربری با مشخصات وارد شده یافت نشد";
                        break;
                    case EditUserProfileResult.Success:
                        TempData[SuccessMessage] = "عملیات ویرایش حساب کاربری با موفقیت انجام شد";
                        //return RedirectToAction("EditUserProfile");
                        return RedirectToAction("Index", "Home");
                }
            }
            return View(editUserProfile);
        }

        #endregion

    }
}
