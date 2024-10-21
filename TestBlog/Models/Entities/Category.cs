using System.ComponentModel.DataAnnotations;

namespace TestBlog.Models.Entities
{
    public class Category
    {
        // بین جدول دسته بندی و جدول وبلاگ، رابطه یک به چند وجود دارد
        // یعنی هر مقاله می تواند فقط برای یک دسته بندی باشد اما دسته بندی می تواند هر چند تا مقاله داشته باشد

        #region properties

        [Key]
        public int CategoryId { get; set; }

        [Display(Name = "نام دسته بندی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Name { get; set; }

        [Display(Name = "عنوان صفحه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string PageTitle { get; set; }

        [Display(Name = "توضیحات کوتاه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string ShortDescription { get; set; }

        [Display(Name = "تاریخ ایجاد")]
        public DateTime CreateTime { get; set; } = DateTime.Now;

        #endregion

        #region relations

        public List<Blog> Blogs { get; set; }

        #endregion

    }
}
