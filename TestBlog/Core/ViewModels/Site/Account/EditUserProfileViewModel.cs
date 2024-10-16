﻿using System.ComponentModel.DataAnnotations;
using TestBlog.Models.Entities;

namespace TestBlog.Core.ViewModels.Site.Account
{
    public class EditUserProfileViewModel
    {
        #region properties
        public int BlogId { get; set; }
        public string? AvatarFile { get; set; }




        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string FirstName { get; set; }

        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string LastName { get; set; }

        [Display(Name = "شماره تلفن همراه")]
        public string PhoneNumber { get; set; }
        [Display(Name = "آواتار")]
        public IFormFile? Avatar { get; set; }
        [Display(Name = "جنسیت")]
        public UserGender UserGender { get; set; }
        #endregion
    }

    #region enum
    public enum EditUserProfileResult
    {
        Success,
        NotFound
    }
    #endregion

}
