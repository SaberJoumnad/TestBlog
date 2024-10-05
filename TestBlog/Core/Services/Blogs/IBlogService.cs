using TestBlog.Core.ViewModels.Admin.Blog;

namespace TestBlog.Core.Services.Blogs
{
    public interface IBlogService
    {
        #region admin
        Task<List<FilterBlogViewModel>> GetAllBlogs();
        Task<CreateBlogResult> CreateBlog(CreateBlogViewModel createBlog);
        Task<EditAndDeleteBlogViewModel> GetBlogById(int blogId);
        Task<EditAndDeleteBlogResult> EditBlog(EditAndDeleteBlogViewModel editBlog, int id);
        Task<EditAndDeleteBlogResult> DeleteBlog(int blogId);
        #endregion
    }
}
