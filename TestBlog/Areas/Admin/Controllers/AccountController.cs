using Microsoft.AspNetCore.Mvc;
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

        #region delete-user
        [HttpGet("delete-user/{id}")]
        public async Task<IActionResult> DeleteUser(int? id)
        {
            var data = await _userService.GetUserByIdForDelete(id.Value);
            if (data == null) return NotFound();
            return View(data);
        }

        [HttpPost("delete-user/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _userService.DeleteUser(id);
            switch (result)
            {
                case DeleteUserResult.Notfound:
                    TempData[ErrorMessage] = "کاربر مورد نظر پیدا نشد";
                    break;
                case DeleteUserResult.Success:
                    TempData[SuccessMessage] = "کاربر مورد نظر با موفقیت حذف شد";
                    return RedirectToAction(nameof(FilterUsers));
            }

            return View(id);
        }

        #endregion

        #region restore-user
        [HttpGet("filter-restore-user")]
        public async Task<IActionResult> FilterRestoreUsers()
        {
            return View(await _userService.GetAllDeletedUser());
        }

        [HttpGet("restore-user/{id}")]
        public async Task<IActionResult> RestoreUser(int? id)
        {
            var data = await _userService.GetUserByIdForRestore(id.Value);
            if (data == null) return NotFound();
            return View(data);
        }

        [HttpPost("restore-user/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RestoreUser(int id)
        {
            var result = await _userService.RestoreUser(id);
            switch (result)
            {
                case RestoreUserResult.Notfound:
                    TempData[ErrorMessage] = "کاربر مورد نظر پیدا نشد";
                    break;
                case RestoreUserResult.Success:
                    TempData[SuccessMessage] = "کاربر مورد نظر با موفقیت بازگردانی شد";
                    return RedirectToAction(nameof(FilterUsers));
            }

            return View(id);
        }



        #endregion

    }
}
