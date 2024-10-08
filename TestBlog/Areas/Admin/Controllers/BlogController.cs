﻿using Microsoft.AspNetCore.Mvc;
using TestBlog.Core.Services.Blogs;
using TestBlog.Core.ViewModels.Admin.Blog;

namespace TestBlog.Areas.Admin.Controllers
{
    public class BlogController : AdminBaseController
    {
        #region constructor
        private readonly IBlogService _blogService;
        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }
        #endregion

        #region filter-blog

        [HttpGet("filter-blog")]
        public async Task<IActionResult> FilterBlogs()
        {
            return View(await _blogService.GetAllBlogs());
        }

        #endregion

        #region create-blog
        [HttpGet("create-blog")]
        public IActionResult CreateBlog()
        {
            return View();
        }

        [HttpPost("create-blog")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateBlog(CreateBlogViewModel blog)
        {
            if (ModelState.IsValid)
            {
                var result = await _blogService.CreateBlog(blog);
                switch (result)
                {
                    case CreateBlogResult.TitleExist:
                        TempData[ErrorMessage] = "عنوان در سیستم ذخیره شده است";
                        break;
                    case CreateBlogResult.Success:
                        TempData[SuccessMessage] = "افزودن مقاله با موفقیت انجام شد.";
                        return RedirectToAction(nameof(FilterBlogs));
                }
            }
            return View(blog);
        }

        #endregion

        #region edit-blog
        [HttpGet("edit-blog/{id}")]
        public async Task<IActionResult> EditBlog(int id)
        {
            var data = await _blogService.GetBlogById(id);
            if (data == null)
            {
                return NotFound();
            }
            return View(data);
        }

        [HttpPost("edit-blog/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditBlog(EditAndDeleteBlogViewModel editBlog, int id)
        {
            var result = await _blogService.EditBlog(editBlog, id);
            switch (result)
            {
                case EditAndDeleteBlogResult.NotFound:
                    TempData[ErrorMessage] = "مقاله مورد نظر پیدا نشد";
                    break;
                case EditAndDeleteBlogResult.Success:
                    TempData[SuccessMessage] = "مقاله مورد نظر با موفقیت ویرایش شد";
                    return RedirectToAction(nameof(FilterBlogs));
            }
            return View(editBlog);
        }
        #endregion

        #region delete-blog
        [HttpGet("delete-blog/{id}")]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            var data = await _blogService.GetBlogById(id);
            if (data == null)
                return NotFound();

            return View(data);
        }
        [HttpPost("delete-blog/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteBlog(int? id)
        {
            var result = await _blogService.DeleteBlog(id.Value);
            switch (result)
            {
                case EditAndDeleteBlogResult.NotFound:
                    TempData[ErrorMessage] = "مقاله مورد نظر پیدا نشد";
                    break;
                case EditAndDeleteBlogResult.Success:
                    TempData[SuccessMessage] = "مقاله مورد نظر با موفقیت حذف شد";
                    return RedirectToAction(nameof(FilterBlogs));
            }
            return View(result);
        }

        #endregion

    }
}
