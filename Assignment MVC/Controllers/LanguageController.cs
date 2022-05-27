using Assignment_MVC.Data;
using Assignment_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_MVC.Controllers
{
    public class LanguageController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LanguageController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            LangaugeViewModel model = new LangaugeViewModel();
            model.Languages = _context.Language.ToList();
            model.People = _context.People.ToList();
            foreach(var p in model.People)
            {
                p.PersonLanguages = _context.Set<PersonLanguage>().Where(l => l.Personid == p.id).ToList();
            }
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Language language)
        {
            if (_context.Language.Find(language.LanguageName) == null&&ModelState.IsValid)
            {
                _context.Language.Add(language);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }


        public IActionResult Remove(string languageName)
        {
            var languageToRemove = _context.Language.Find(languageName);
            _context.Language.Remove(languageToRemove);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        
    }
}
