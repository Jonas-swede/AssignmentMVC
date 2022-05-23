using Assignment_MVC.Data;
using Assignment_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_MVC.Controllers
{
    public class PersonsController : Controller
    {
        IPersonData data;
        public PersonsController(IPersonData personData)
        {
            data = personData;
        }
        
        
        public IActionResult Persons()
        {
            List<Person> persons = new List<Person>();
            persons = data.GetAll();
            PersonViewModel model = new PersonViewModel(persons);
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
                    p.City.Contains(SearchPhrase)
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
                p.City = input.newPerson.City;
                p.Name = input.newPerson.Name;
                p.PhoneNumber = input.newPerson.PhoneNumber;
                data.AddPerson(p);
            }
            return View("Persons",model);
        }

        public IActionResult RemovePerson(int id)
        {
            data.RemovePerson(id);
            return RedirectToAction("Persons");
        }

        
        
    }
}
