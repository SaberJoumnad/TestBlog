using System.ComponentModel.DataAnnotations;
using TestBlog.Models.Entities;

namespace TestBlog.Core.ViewModels.Admin.Account
{
    public class RestoreUserViewModel
    {
        #region properties
        [Key]
        public int UserId { get; set; }
        public bool IsDelete { get; set; }
        [Display(Name = "تاریخ ثبت نام")]
        public DateTime CreateDate { get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد")]
        public string FirstName { get; set; }

        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد")]
        public string LastName { get; set; }

        [Display(Name = "شماره تلفن همراه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد")]
        public string PhoneNumber { get; set; }

        [Display(Name = "مسدود شده  / نشده")]
        public bool IsBlocked { get; set; }

        [Display(Name = "تایید شده / نشده")]
        public bool IsMobileActive { get; set; }

        [Display(Name = "جنسیت")]
        public UserGender UserGender { get; set; }

        [Display(Name = "ادمین")]
        public bool IsAdmin { get; set; }
        #endregion
    }

    #region enum
    public enum RestoreUserResult
    {
        Success,
        Notfound
    }
    #endregion
}
