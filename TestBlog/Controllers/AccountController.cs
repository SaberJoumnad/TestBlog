using Microsoft.AspNetCore.Mvc;
using TestBlog.Core.Services.Users;
using TestBlog.Core.ViewModels.Site.Account;

namespace TestBlog.Controllers
{
    public class AccountController : SiteBaseController
    {
        #region constructor
        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
        #endregion

        #region register

        [HttpGet("register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("register")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserViewModel register)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.RegisterUser(register);
                switch (result)
                {
                    case RegisterUserResult.MobileExists:
                        TempData[ErrorMessage] = "شماره تلفن وارد شده قبلا در سیستم ثبت شده است";
                        break;
                    case RegisterUserResult.Success:
                        TempData[SuccessMessage] = "ثبت نام شما با موفقیت انجام شد";
                        return RedirectToAction("ActiveAccount", "Account", new { mobile = register.PhoneNumber });
                }
            }

            return View(register);
        }

        #endregion

        #region activate account
        [HttpGet("activate-account/{mobile}")]
        public async Task<IActionResult> ActiveAccount(string mobile)
        {
            if (User.Identity.IsAuthenticated) return Redirect("/");
            var activeAccount = new ActiveAccountViewModel
            {
                PhoneNumber = mobile,
            };

            return View(activeAccount);
        }

        [HttpPost("activate-account/{mobile}"), ValidateAntiForgeryToken]
        public async Task<IActionResult> ActiveAccount(ActiveAccountViewModel activeAccount)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.ActiveAccount(activeAccount);
                switch (result)
                {
                    case ActiveAccountResult.Error:
                        TempData[ErrorMessage] = "عملیات فعال کردن حساب کاربری با شکست مواجه شد";
                        break;
                    case ActiveAccountResult.NotFound:
                        TempData[WarningMessage] = "کاربری با مشخصات وارد شده یافت نشد";
                        break;
                    case ActiveAccountResult.Success:
                        TempData[SuccessMessage] = "حساب کاربری شما با موفقیت فعال شد";
                        TempData[InfoMessage] = "لطفا جهت ادامه فراید وارد حساب کاربری خود شوید";
                        return RedirectToAction("Login");

                }
            }
            return View(activeAccount);
        }

        #endregion

    }
}
