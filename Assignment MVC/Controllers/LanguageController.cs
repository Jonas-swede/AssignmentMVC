using Assignment_MVC.Data;
using Assignment_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment_MVC.Services;
using Microsoft.AspNetCore.Authorization;

namespace Assignment_MVC.Controllers
{
    [Authorize(Roles ="Admin")]
    public class LanguageController : Controller
    {
        
        private readonly ILanguageServices _languageServices;
        private readonly IPersonService _personService;
        private readonly IPersonLanguageServices _personLanguageServices;

        public LanguageController(ILanguageServices languageServices,IPersonService personService,IPersonLanguageServices personLanguageServices)
        {
            _languageServices = languageServices;
            _personService = personService;
            _personLanguageServices = personLanguageServices;
        }
        public IActionResult Index()
        {
            ViewData["Languages"] = new SelectList(_languageServices.GetAll(), "LanguageName", "LanguageName");
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

        public IActionResult AddLanguage(LangaugeViewModel langaugeView)
        {
            var langaugeId = _languageServices.GetLanguageByName(langaugeView.NewLanguageName).LanguageId;
            _personLanguageServices.CreatePersonLanguage(langaugeId, langaugeView.NewLanguagePersonId);


            return RedirectToAction("Index");
        }

        public IActionResult EditLanguage(int LanguageId)
        {
            var language = _languageServices.GetLanguage(LanguageId);
            return View(language);
        }

        [HttpPost]
        public IActionResult EditLanguage(Language language)
        {
            _languageServices.UpdateLanguage(language);
            return RedirectToAction("Index");
        }


    }
}
