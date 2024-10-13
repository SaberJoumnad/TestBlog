﻿using Microsoft.AspNetCore.Mvc;
using TestBlog.Core.Services.Users;
using TestBlog.Core.ViewModels.Admin.Account;

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

        #region edit-user
        [HttpGet("edit-user/{id}")]
        public async Task<IActionResult> EditUser(int id)
        {
            var data = await _userService.GetUserByIdForEdit(id);
            if (data == null) return NotFound();
            return View(data);
        }

        [HttpPost("edit-user/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUser(EditUserViewModel user, int id)
        {
            var result = await _userService.EditUser(user, id);
            switch (result)
            {
                case EditUserResult.NotFound:
                    TempData[ErrorMessage] = "کاربر مورد نظر پیدا نشد";
                    break;
                case EditUserResult.Success:
                    TempData[SuccessMessage] = "کاربر مورد نظر با موفقیت ویرایش شد";
                    return RedirectToAction(nameof(FilterUsers));
            }

            return View(user);
        }
        #endregion

    }
}
