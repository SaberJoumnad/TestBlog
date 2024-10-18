using System.ComponentModel.DataAnnotations;

namespace TestBlog.Core.ViewModels.Site.Account
{
    public class LoginUserViewModel
    {
        #region properties
        [Display(Name = "شماره تلفن همراه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد")]
        public string PhoneNumber { get; set; }

        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد")]
        public string Password { get; set; }

        [Display(Name = "مرا به خاطر بسپار")]
        public bool RememberMe { get; set; }
        #endregion
    }

    #region enum
    public enum LoginUserResult
    {
        NotFound,
        NotActive,
        Success,
        IsBlocked
    }
    #endregion
}
