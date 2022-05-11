using Assignment_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_MVC.Controllers
{
    public class FeverCheck : Controller
    {
        FeverCheckModel fever = new FeverCheckModel();

        public IActionResult Fever()
        {
            return View(fever);
        }

        [HttpPost]
        public IActionResult Fever(FeverCheckModel feverCheck)
        {
            feverCheck.GetFever();
            return View(feverCheck);
        }
    }
}
