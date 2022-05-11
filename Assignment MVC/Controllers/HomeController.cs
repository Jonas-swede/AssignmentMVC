using Microsoft.AspNetCore.Mvc;
using Assignment_MVC.Models;

namespace Assignment_MVC.Controllers
{
    public class HomeController : Controller
    {
        Data db = new Data();


        public IActionResult Projects()
        {
            var model = db;
            return View(model);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View(db);
        }

        
    }
}
