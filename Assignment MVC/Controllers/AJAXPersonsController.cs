using Assignment_MVC.Data;
using System;
using Microsoft.AspNetCore.Mvc;
using Assignment_MVC.Models;
using System.Collections.Generic;

namespace Assignment_MVC.Controllers
{
    public class AJAXPersonsController : Controller
    {
        IPersonData data;
        public AJAXPersonsController(IPersonData personData)
        {
            data = personData;
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult People()
        {
            List<Person> persons = new List<Person>();
            persons = data.GetAll();
            PersonViewModel model = new PersonViewModel(persons);
            return PartialView("_AllPeoplePartialView",model);
        }

        [HttpPost]
        public ActionResult Details(string idInput)
        {
            int id;
            int.TryParse(idInput, out id);
            Person person = data.GetById(id);
            
            return PartialView("_PersonDetailsPartialView",person);
        }

        [HttpPost]
        public ActionResult Delete(string idInput)
        {
            int id;
            bool statusCode = false;
            if (int.TryParse(idInput, out id)) statusCode=data.RemovePerson(id);
              
            return Json(new { status = statusCode });
        }
        
    }
}
