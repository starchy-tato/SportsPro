using Microsoft.AspNetCore.Mvc;
using SportsPro.Models;

namespace SportsPro.Controllers
{
    public class HomeController : Controller
    {
        public SportsProContext context { get; set; }

        public HomeController(SportsProContext ctx)
        {
            context = ctx;
        }


        public IActionResult Index()
        {
            return View(); // Views/Home/Index.cshtml
        }

        public IActionResult About()
        {
            return View();
        }

   

    }//class
}//namespace