using System.ComponentModel.DataAnnotations;

namespace TestBlog.Core.ViewModels.Admin.Blog
{
    public class CreateBlogViewModel
    {
        // This ViewModel is  for create blog only


        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد")]
        public string Title { get; set; }

        [Display(Name = "متن")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Text { get; set; }

        [Display(Name = "تصویر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public IFormFile ImageName { get; set; }

        [Display(Name = "تاریخ ایجاد")]
        public DateTime CreateTime { get; set; }
    }

    public enum CreateBlogResult
    {
        Success,
        TitleExist
    }

}
