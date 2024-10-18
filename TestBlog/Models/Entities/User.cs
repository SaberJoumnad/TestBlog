using System.ComponentModel.DataAnnotations;

namespace TestBlog.Models.Entities
{
    public class User
    {
        #region properties

        [Key]
        public int UserId { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;

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

        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد")]
        public string Password { get; set; }

        [Display(Name = "پروفایل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد")]
        public string Avatar { get; set; }

        [Display(Name = "مسدود شده  / نشده")]
        public bool IsBlocked { get; set; }

        [Display(Name = "کد احرازهویت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(50, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد")]
        public string MobileActiveCode { get; set; }

        [Display(Name = "تایید شده / نشده")]
        public bool IsMobileActive { get; set; }

        [Display(Name = "جنسیت")]
        public UserGender UserGender { get; set; }

        [Display(Name = "ادمین")]
        public bool IsAdmin { get; set; }

        #endregion
    }

    #region enum
    public enum UserGender
    {
        [Display(Name = "آقا")]
        MALE,
        [Display(Name = "خانم")]
        Female,
        [Display(Name = "نامشخص")]
        Unknown
    }
    #endregion


}

