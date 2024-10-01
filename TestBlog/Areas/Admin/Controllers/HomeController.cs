using Microsoft.AspNetCore.Mvc;

namespace TestBlog.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
