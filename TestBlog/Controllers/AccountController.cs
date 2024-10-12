using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
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

        #region login
        [HttpGet("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("login")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginUserViewModel login)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.LoginUser(login);
                switch (result)
                {
                    case LoginUserResult.NotFound:
                        TempData[WarningMessage] = "کاربری یافت نشد";
                        break;
                    case LoginUserResult.NotActive:
                        TempData[ErrorMessage] = "حساب کاربری شما فعال نمی باشد";
                        break;
                    case LoginUserResult.IsBlocked:
                        TempData[ErrorMessage] = "حساب شما توسط واحد پشتیبانی مسدود شده است";
                        TempData[InfoMessage] = "جهت اطلاع بیشتر لطفا به بخش تماس با ما مراجعه کنید";
                        break;
                    case LoginUserResult.Success:
                        var user = await _userService.GetUserByPhoneNumber(login.PhoneNumber);
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, user.PhoneNumber),
                            new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString())
                        };
                        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var principle = new ClaimsPrincipal(identity);
                        var properties = new AuthenticationProperties
                        {
                            IsPersistent = login.RememberMe
                        };
                        await HttpContext.SignInAsync(principle, properties);
                        TempData[SuccessMessage] = "شما با موفقیت وارد حساب کاربری خود شدید";
                        return Redirect("/");
                }
            }

            return View(login);
        }
        #endregion

        #region log-out
        [HttpGet("log-Out")]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            TempData[WarningMessage] = "شما با موفقیت از حساب کاربری خود خارج شدید";
            return Redirect("/");
        }
        #endregion

    }
}
