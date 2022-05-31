using Assignment_MVC.Data;
using Assignment_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment_MVC.Services;

namespace Assignment_MVC.Controllers
{
    public class LanguageController : Controller
    {
        private readonly ILanguageServices _languageServices;
        private readonly IPersonService _personService;

        //private readonly ApplicationDbContext _context;

        public LanguageController(ILanguageServices languageServices,IPersonService personService)
        {
            _languageServices = languageServices;
            _personService = personService;
            //_context = context;
        }
        public IActionResult Index()
        {
            LangaugeViewModel model = new LangaugeViewModel();
            model.Languages = _languageServices.GetAll();
            model.People = _personService.GetAll();
           
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Language language)
        {
            if (_languageServices.GetLanguage(language.LanguageId) == null&&ModelState.IsValid)
            {
                _languageServices.CreateLanguage(language);
                
            }
            return RedirectToAction("Index");
        }


        public IActionResult Remove(int languageId)
        {
            _languageServices.DeleteLanguage(languageId);
            return RedirectToAction("Index");
        }

        
    }
}
