using TestBlog.Core.ViewModels.Site.Account;

namespace TestBlog.Core.Services.Users
{
    public interface IUserService
    {
        #region site
        //Task<bool> IsUserExistPhoneNumber(string phoneNumber);

        Task<RegisterUserResult> RegisterUser(RegisterUserViewModel register);
        


        #endregion
    }
}
