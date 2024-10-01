using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestBlog.Models;

namespace TestBlog.Controllers
{
    public class HomeController : SiteBaseController
    {
        public IActionResult Index()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
