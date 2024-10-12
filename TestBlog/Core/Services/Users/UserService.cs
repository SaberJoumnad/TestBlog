using Microsoft.EntityFrameworkCore;
using TestBlog.Core.Utilities.Password;
using TestBlog.Core.ViewModels.Site.Account;
using TestBlog.Models.Context;
using TestBlog.Models.Entities;

namespace TestBlog.Core.Services.Users
{
    public class UserService : IUserService
    {
        #region constructor
        private readonly BlogContext _context;
        private readonly IPasswordHelper _passwordHelper;
        public UserService(BlogContext context, IPasswordHelper passwordHelper)
        {
            _context = context;
            _passwordHelper = passwordHelper;
        }


        #endregion

        #region site


        //public async Task<bool> IsUserExistPhoneNumber(string phoneNumber)
        //{
        //    return await _context.Users.AsQueryable().AnyAsync(x => x.PhoneNumber == phoneNumber);
        //}


        public async Task<RegisterUserResult> RegisterUser(RegisterUserViewModel register)
        {
            if (! await _context.Users.AsQueryable().AnyAsync(x=>x.PhoneNumber == register.PhoneNumber))
            {
                var user = new User
                {
                    FirstName = register.FirstName,
                    LastName = register.LastName,
                    UserGender = UserGender.Unknown,
                    Password = _passwordHelper.EncodePasswordMd5(register.Password),
                    PhoneNumber = register.PhoneNumber,
                    Avatar = "default.png",
                    IsMobileActive = false,
                    MobileActiveCode = new Random().Next(10000, 99999).ToString(),
                    IsDelete = false,
                    IsBlocked = false,
                };

                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();

                // send sms

                return RegisterUserResult.Success;
            }

            return RegisterUserResult.MobileExists;
        }

        #endregion

    }
}
