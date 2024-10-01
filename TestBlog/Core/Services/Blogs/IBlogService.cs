using TestBlog.Core.ViewModels.Admin.Blog;

namespace TestBlog.Core.Services.Blogs
{
    public interface IBlogService
    {
        #region admin
        Task<List<FilterBlogViewModel>> GetAllBlogs();
        Task<CreateBlogResult> CreateBlog(CreateBlogViewModel createBlog);
        Task<EditBlogViewModel> GetBlogById(int blogId);
        Task<EditBlogResult> EditBlog(EditBlogViewModel editBlog, int id);

        #endregion
    }
}
