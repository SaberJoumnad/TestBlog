using System.ComponentModel.DataAnnotations;

namespace TestBlog.Core.ViewModels.Site.Account
{
    public class ActiveAccountViewModel
    {
        #region properties
        [Display(Name = "شماره تلفن همراه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد")]
        public string PhoneNumber { get; set; }

        [Display(Name = "کد فعال سازی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(20, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد")]
        public string ActiveCode { get; set; }
        #endregion
    }

    #region enum
    public enum ActiveAccountResult
    {
        Success,
        Error,
        NotFound
    }
    #endregion
}
