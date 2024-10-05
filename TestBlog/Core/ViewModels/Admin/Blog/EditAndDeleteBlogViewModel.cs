using System.ComponentModel.DataAnnotations;

namespace TestBlog.Core.ViewModels.Admin.Blog
{
    public class EditAndDeleteBlogViewModel
    {
        // this view model is for get blog by Id and edit and delete blog

        public int BlogId { get; set; }
        public string? ImageFile { get; set; }



        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد")]
        public string Title { get; set; }

        [Display(Name = "متن")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Text { get; set; }

        [Display(Name = "تصویر")]
        public IFormFile ImageName { get; set; }

        [Display(Name = "تاریخ ایجاد")]
        public DateTime CreateTime { get; set; }
    }

    public enum EditAndDeleteBlogResult
    {
        Success,
        NotFound
    }
}
