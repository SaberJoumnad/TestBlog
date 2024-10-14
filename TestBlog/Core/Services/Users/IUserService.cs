using TestBlog.Core.ViewModels.Admin.Account;
using TestBlog.Core.ViewModels.Site.Account;
using TestBlog.Models.Entities;

namespace TestBlog.Core.Services.Users
{
    public interface IUserService
    {
        #region site
        Task<RegisterUserResult> RegisterUser(RegisterUserViewModel register);
        Task<User> GetUserByPhoneNumber(string phoneNumber);
        Task<ActiveAccountResult> ActiveAccount(ActiveAccountViewModel activeAccount);
        Task<LoginUserResult> LoginUser(LoginUserViewModel login);
        #endregion

        #region admin
        Task<List<FilterUserViewModel>> GetAllUser();
        Task<EditUserViewModel> GetUserByIdForEdit(int id);
        Task<EditUserResult> EditUser(EditUserViewModel edit, int id);
        Task<DeleteUserViewModel> GetUserByIdForDelete(int id);
        Task<DeleteUserResult> DeleteUser(int id);
        Task<List<FilterUserViewModel>> GetAllDeletedUser();
        Task<RestoreUserViewModel> GetUserByIdForRestore(int id);
        Task<RestoreUserResult> RestoreUser(int id);
        #endregion

        #region profile
        Task<User> GetUserById(long userId);
        Task<EditUserProfileViewModel> GetEditUserProfile(long userId);
        Task<EditUserProfileResult> EditProfile(long userId, EditUserProfileViewModel editUserProfile);
        #endregion

    }
}
