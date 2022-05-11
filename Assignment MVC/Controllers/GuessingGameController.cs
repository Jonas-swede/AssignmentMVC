using Assignment_MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Assignment_MVC.Controllers
{
    public class GuessingGameController : Controller
    {
        
        public IActionResult GuessingGame()
        {
            GuessingGameModel model = new GuessingGameModel();
            HttpContext.Session.SetInt32("number", model.NewNumber());
            return View(model);

        }

        [HttpPost]
        public IActionResult GuessingGame(int Guessednumber)
        {
            GuessingGameModel model = new GuessingGameModel();
            model.Number = (int)HttpContext.Session.GetInt32("number");
            model.GuessNumber(Guessednumber);
            
            
            return View(model);
        }
    }
}
