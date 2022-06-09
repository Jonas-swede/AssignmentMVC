using Assignment_MVC.Data;
using Assignment_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_MVC.Services
{
    public class PersonService : IPersonService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILanguageServices _languageServices;
        private readonly ICityServices _cityServices;

        public PersonService(ApplicationDbContext context,ILanguageServices languageServices,ICityServices cityServices)
        {
            _context = context;
            _languageServices = languageServices;
            _cityServices = cityServices;
        }
        public bool CreatePerson(string Name, string City, string PhoneNumber, int FirstLanguage)
        {
            Person p = new Person();
            p.Name = Name;
            p.City= _context.Cities.First(n => n.CityName == City);
            p.PhoneNumber = PhoneNumber;
            _context.People.Add(p);
            var saved=_context.SaveChanges();
            var language = new PersonLanguage();
            language.LanguageId = FirstLanguage;
            language.Personid = p.id;

            _context.PersonLanguage.Add(language);
            saved+=_context.SaveChanges();

            return saved > 1 ? true : false;

        }

        public bool DeletePerson(int id)
        {
            var Person = _context.People.Find(id);
            if (Person != null)
            {
                _context.Remove(Person);
                _context.SaveChanges();
                return true;
            }
            else return false;
        }

        public List<Person> FindPeople(string SearchPhrase)
        {
            var Persons = GetAll();
            var returnPerson = Persons.Where(
                p =>
                    p.Name.Contains(SearchPhrase) ||
                    p.City.CityName.Contains(SearchPhrase)
                    ).ToList();
            return returnPerson;
        }

        public Person ReadPerson(int id)
        {
            var Person = _context.People.Find(id);
            Person.PersonLanguages = _context.Set<PersonLanguage>().Where(l => l.Personid == Person.id).ToList();
            return Person;
        }

        public List<Person> GetAll()
        {
            var returnList = _context.Set<Person>().ToList();
            foreach (Person p in returnList)
            {
                p.City = _cityServices.GetCity(p.CityID);
                p.PersonLanguages = _context.Set<PersonLanguage>().Where(l => l.Personid == p.id).ToList();
                foreach(PersonLanguage l in p.PersonLanguages)
                {
                    l.LanguageName = _context.Language.Find(l.LanguageId).LanguageName;
                }
            }
            return returnList;
        }

        public bool UpdatePerson(Person p)
        {
            var PersonToUpdate = _context.People.Find(p.id);
            if (PersonToUpdate != null)
            {
                _context.People.Update(PersonToUpdate);
                PersonToUpdate.PhoneNumber = p.PhoneNumber;
                PersonToUpdate.Name = p.Name;
                PersonToUpdate.CityID = p.CityID;
                return _context.SaveChanges() > 0 ? true : false;
                
            }
            else return false;
        }
    }

}
