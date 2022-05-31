using Assignment_MVC.Data;
using Assignment_MVC.Models;
using Assignment_MVC.Services;
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
        private readonly IPersonService _personService;
        private readonly ILanguageServices _languageServices;
        private readonly ICityServices _cityServices;
        private readonly IPersonLanguageServices _personLanguageServices;
        
        public PersonsController(IPersonService personService,ILanguageServices languageServices,ICityServices cityServices, IPersonLanguageServices personLanguageServices)
        {
            _personService = personService;
            _languageServices = languageServices;
            _cityServices = cityServices;
            _personLanguageServices = personLanguageServices;
            
        }
        
        
        public IActionResult Persons()
        {
            ViewData["CityName"] = new SelectList(_cityServices.GetAll(), "CityName", "CityName");
            ViewData["Languages"] = new SelectList(_languageServices.GetAll(), "LanguageName", "LanguageName");
            List<Person> persons = new List<Person>();
            persons = _personService.GetAll();
            
            PersonViewModel model = new PersonViewModel(persons);
            
            return View(model);
        }

        [HttpPost]
        public IActionResult Persons(string SearchPhrase)
        {
            PersonViewModel model = new PersonViewModel(_personService.GetAll());
            if (SearchPhrase != null) {
                model.Persons = _personService.FindPeople(SearchPhrase);
               
            }
            
            return View(model);
        }

        public IActionResult CreatePerson(PersonViewModel input)
        {
            
            List<Person> persons = new List<Person>();
            persons = _personService.GetAll();
            PersonViewModel model = new PersonViewModel(persons);
            if (ModelState.IsValid)
            {
                _personService.CreatePerson(
                    input.newPerson.Name,
                    input.newPerson.City,
                    input.newPerson.PhoneNumber,
                    input.newPerson.Language);
                
            }
            return RedirectToAction("Persons");
        }

        public IActionResult RemovePerson(int id)
        {
            _personService.DeletePerson(id);
            return RedirectToAction("Persons");
        }

        [HttpPost]
        public IActionResult AddLanguage(Person person)
        {
            _personLanguageServices.CreatePersonLanguage(person.PersonLanguages[0].LanguageId, person.id);
            

            return RedirectToAction("Persons");
        }

        
        
    }
}
