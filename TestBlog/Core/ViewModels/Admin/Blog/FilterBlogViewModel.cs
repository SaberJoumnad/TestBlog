namespace TestBlog.Core.ViewModels.Admin.Blog
{
    public class FilterBlogViewModel
    {

        // this view model for list in index view in admin

        public int BlogId { get; set; }
        public string Title { get; set; }
        public string ImageName { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
