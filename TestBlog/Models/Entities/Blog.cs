using System.ComponentModel.DataAnnotations;

namespace TestBlog.Models.Entities
{
    public class Blog
    {
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
    }
}
