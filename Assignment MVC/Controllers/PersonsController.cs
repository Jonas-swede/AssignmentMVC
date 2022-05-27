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
    public class PersonsController : Controller
    {
        public readonly ApplicationDbContext _context;
        private readonly PersonData data;
        
        public PersonsController(ApplicationDbContext context)
        {
            _context = context;
            data = new PersonData(_context);
        }
        
        
        public IActionResult Persons()
        {
            ViewData["CityName"] = new SelectList(_context.Cities, "CityName", "CityName");
            ViewData["Languages"] = new SelectList(_context.Language, "LanguageName", "LanguageName");
            List<Person> persons = new List<Person>();
            persons = data.GetAll();
            
            PersonViewModel model = new PersonViewModel(persons);
            foreach(Person p in model.Persons)
            {
                p.PersonLanguages = _context.Set<PersonLanguage>().Where(l => l.Personid == p.id).ToList();
            }
            model.SearchPhrase = data.SearchString != null ? data.SearchString:null;
            return View(model);
        }

        [HttpPost]
        public IActionResult Persons(string SearchPhrase)
        {
            PersonViewModel model = new PersonViewModel(data.GetAll());
            if (SearchPhrase != null) { 
                model.Persons = model.Persons.Where(
                    p =>
                    p.Name.Contains(SearchPhrase) ||
                    p.City.CityName.Contains(SearchPhrase)
                    ).ToList();
                data.SearchString = SearchPhrase;
            }
            else
            {
                data.SearchString = null;
            }
            return View(model);
        }

        public IActionResult CreatePerson(PersonViewModel input)
        {
            
            List<Person> persons = new List<Person>();
            persons = data.GetAll();
            PersonViewModel model = new PersonViewModel(persons);
            if (ModelState.IsValid)
            {
                Person p = new Person();
                p.City = _context.Cities.First(n => n.CityName == input.newPerson.City);
                p.Name = input.newPerson.Name;
                p.PhoneNumber = input.newPerson.PhoneNumber;
                p=_context.People.Add(p).Entity;
                _context.SaveChanges();
                //int personId = _context.People.Last(person=>person.Name==p.Name).id;
                var language = new PersonLanguage();
                language.LanguageName = input.newPerson.Language;
                language.Personid = p.id;
                _context.PersonLanguage.Add(language);
                _context.SaveChanges();
                
            }
            return RedirectToAction("Persons");
        }

        public IActionResult RemovePerson(int id)
        {
            data.RemovePerson(id);
            return RedirectToAction("Persons");
        }

        [HttpPost]
        public IActionResult AddLanguage(Person person)
        {
            var DataToAdd = new PersonLanguage();
            DataToAdd.LanguageName = person.PersonLanguages[0].LanguageName;
            DataToAdd.Personid = person.id;
            if (_context.PersonLanguage.Find(DataToAdd.Personid, DataToAdd.LanguageName)==null) {
                _context.PersonLanguage.Add(DataToAdd);
                _context.SaveChanges();
            }
            

            return RedirectToAction("Persons");
        }

        
        
    }
}
