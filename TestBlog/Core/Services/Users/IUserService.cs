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
    }
}
