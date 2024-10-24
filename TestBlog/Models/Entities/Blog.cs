﻿using System.ComponentModel.DataAnnotations;

namespace TestBlog.Models.Entities
{
    public class Blog
    {

        // بین جدول دسته بندی و جدول وبلاگ، رابطه یک به چند وجود دارد
        // یعنی هر مقاله می تواند فقط برای یک دسته بندی باشد اما دسته بندی می تواند هر چند تا مقاله داشته باشد


        #region properties
        [Key]
        public int BlogId { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد")]
        public string Title { get; set; }

        [Display(Name = "متن")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Text { get; set; }

        [Display(Name = "تصویر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string ImageName { get; set; }

        [Display(Name = "تاریخ ایجاد")]
        public DateTime CreateTime { get; set; }
        #endregion

        #region relations

        [Display(Name = "نام دسته بندی")]
        public Category Category { get; set; }

        [Display(Name = "دسته بندی")]
        public int CategoryId { get; set; }

        #endregion

    }
}
