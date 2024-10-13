using Microsoft.EntityFrameworkCore;
using TestBlog.Core.Utilities.Password;
using TestBlog.Core.Utilities.SMS;
using TestBlog.Core.ViewModels.Admin.Account;
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
        private readonly ISmsService _smsService;
        public UserService(BlogContext context, IPasswordHelper passwordHelper, ISmsService smsService)
        {
            _context = context;
            _passwordHelper = passwordHelper;
            _smsService = smsService;
        }



        #endregion

        #region site

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
                    IsAdmin = false,
                };

                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();

                // send sms
                await _smsService.SendVerificationCode(user.PhoneNumber, user.MobileActiveCode);

                return RegisterUserResult.Success;
            }

            return RegisterUserResult.MobileExists;
        }


        public async Task<User> GetUserByPhoneNumber(string phoneNumber)
        {
            return await _context.Users
                .SingleOrDefaultAsync(s => s.PhoneNumber == phoneNumber);
        }

        public async Task<ActiveAccountResult> ActiveAccount(ActiveAccountViewModel activeAccount)
        {
            var user = await _context.Users
                .SingleOrDefaultAsync(s => s.PhoneNumber == activeAccount.PhoneNumber);

            if (user == null) return ActiveAccountResult.NotFound;
            if (user.MobileActiveCode == activeAccount.ActiveCode)
            {
                user.MobileActiveCode = new Random().Next(10000, 99999).ToString();
                user.IsMobileActive = true;

                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                return ActiveAccountResult.Success;
            }

            return ActiveAccountResult.Error;
        }

        public async Task<LoginUserResult> LoginUser(LoginUserViewModel login)
        {
            var user = await _context.Users
                .SingleOrDefaultAsync(s => s.PhoneNumber == login.PhoneNumber);

            if (user == null) return LoginUserResult.NotFound;
            if (user.IsBlocked) return LoginUserResult.IsBlocked;
            if (!user.IsMobileActive) return LoginUserResult.NotActive;
            if (user.Password != _passwordHelper.EncodePasswordMd5(login.Password)) return LoginUserResult.NotFound;

            return LoginUserResult.Success;
        }

        #endregion

        #region admin

        public async Task<List<FilterUserViewModel>> GetAllUser()
        {
            return await _context.Users.AsQueryable().OrderByDescending(o => o.CreateDate)
                .Where(j => j.IsDelete == false)
                .Select(c => new FilterUserViewModel
                {
                    IsAdmin = c.IsAdmin,
                    IsBlocked = c.IsBlocked,
                    LastName = c.LastName,
                    PhoneNumber = c.PhoneNumber,
                    UserId = c.UserId
                }).ToListAsync();
        }

        #endregion

    }
}
