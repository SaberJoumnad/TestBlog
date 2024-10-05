using Microsoft.EntityFrameworkCore;
using TestBlog.Core.ViewModels.Admin.Blog;
using TestBlog.Models.Context;
using TestBlog.Models.Entities;

namespace TestBlog.Core.Services.Blogs
{
    public class BlogService : IBlogService
    {
        #region constructor
        private readonly BlogContext _context;
        public BlogService(BlogContext context)
        {
            _context = context;
        }

        #endregion

        #region admin

        public async Task<List<FilterBlogViewModel>> GetAllBlogs()
        {
            return await _context.Blogs.AsQueryable().OrderByDescending(o => o.CreateTime)
                .Select(c => new FilterBlogViewModel
                {
                    BlogId = c.BlogId,
                    CreateTime = c.CreateTime,
                    ImageName = c.ImageName,
                    Title = c.Title,
                }).ToListAsync();
        }

        public async Task<CreateBlogResult> CreateBlog(CreateBlogViewModel createBlog)
        {
            if (await _context.Blogs.AnyAsync(o => o.Title == createBlog.Title.ToLower()))
            {
                return CreateBlogResult.TitleExist;
            }
            else
            {
                var newBlog = new Blog()
                {
                    Title = createBlog.Title,
                    CreateTime = DateTime.Now,
                    Text = createBlog.Title,
                };

                string filename = null;
                if (createBlog.ImageName != null)
                {
                    string UploadDir = Path.Combine("wwwroot\\Images");
                    filename = Guid.NewGuid().ToString() + "-" + createBlog.ImageName.FileName;
                    string filepath = Path.Combine(UploadDir, filename);
                    using (var filestream = new FileStream(filepath, FileMode.Create))
                    {
                        createBlog.ImageName.CopyTo(filestream);
                        newBlog.ImageName = filename;
                    }
                }
                await _context.Blogs.AddAsync(newBlog);
                await _context.SaveChangesAsync();
                return CreateBlogResult.Success;

            }
        }

        public async Task<EditAndDeleteBlogViewModel> GetBlogById(int blogId)
        {
            var currentBlog = await _context.Blogs.AsQueryable()
                .FirstOrDefaultAsync(c => c.BlogId == blogId);

            if (currentBlog == null)
            {
                return null;
            }

            return new EditAndDeleteBlogViewModel
            {
                BlogId = currentBlog.BlogId,
                Title = currentBlog.Title,
                Text = currentBlog.Title,
                ImageFile = currentBlog.ImageName,
                CreateTime = currentBlog.CreateTime,
            };

        }

        public async Task<EditAndDeleteBlogResult> EditBlog(EditAndDeleteBlogViewModel editBlog, int id)
        {
            var blog = await _context.Blogs.AsQueryable().FirstOrDefaultAsync(o => o.BlogId == id);

            if (blog == null)
            {
                return EditAndDeleteBlogResult.NotFound;
            }

            string filename = null;
            if (editBlog.ImageName != null)
            {
                string UploadDir = Path.Combine("wwwroot\\Images");
                filename = Guid.NewGuid().ToString() + "-" + editBlog.ImageName.FileName;
                string filepath = Path.Combine(UploadDir, filename);
                using (var filestream = new FileStream(filepath, FileMode.Create))
                {
                    editBlog.ImageName.CopyTo(filestream);
                }
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images", blog.ImageName);
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                blog.ImageName = filename;
            }
            blog.Title = editBlog.Title;
            blog.Text = editBlog.Text;
            _context.Blogs.Update(blog);
            await _context.SaveChangesAsync();

            return EditAndDeleteBlogResult.Success;

        }

        public async Task<EditAndDeleteBlogResult> DeleteBlog(int blogId)
        {
            var currentBlog = await _context.Blogs.FirstOrDefaultAsync(o => o.BlogId == blogId);
            if (currentBlog == null)
            {
                return EditAndDeleteBlogResult.NotFound;
            }
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images", currentBlog.ImageName);
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            _context.Blogs.Remove(currentBlog);
            await _context.SaveChangesAsync();
            return EditAndDeleteBlogResult.Success;
        }
    }

    #endregion
}
