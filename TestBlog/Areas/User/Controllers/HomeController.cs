using Microsoft.AspNetCore.Mvc;

namespace TestBlog.Areas.User.Controllers
{
    public class HomeController : UserBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
