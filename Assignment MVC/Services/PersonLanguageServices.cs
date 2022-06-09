using Assignment_MVC.Data;
using Assignment_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_MVC.Services
{
    public class PersonLanguageServices : IPersonLanguageServices
    {
        private readonly ApplicationDbContext _context;
        private readonly IPersonService _personService;
        private readonly ILanguageServices _languageServices;

        public PersonLanguageServices(ApplicationDbContext context,IPersonService personService,ILanguageServices languageServices)
        {
            _context = context;
            _personService = personService;
            _languageServices = languageServices;
        }
        public bool CreatePersonLanguage(int languageId, int personId)
        {
            var language = _languageServices.GetLanguage(languageId);
            var personLanguageToAdd = new PersonLanguage()
            {
                LanguageId=languageId,
                LanguageName = language.LanguageName,
                Language = language,
                Personid = personId,
                Person = _personService.ReadPerson(personId)
            };
            if(Find(languageId,personId)==null)_context.PersonLanguage.Add(personLanguageToAdd);
            return _context.SaveChanges()>0?true:false;
            
        }

        public bool DeletePersonLanguage(int languageId, int personId)
        {
            var personLanguageToDelete = Find(languageId, personId);
            _context.Remove(personLanguageToDelete);
            return _context.SaveChanges() > 0 ? true : false;
        }

        public PersonLanguage Find(int languageId, int personId)
        {
            PersonLanguage test = new PersonLanguage() {Personid=1,LanguageId=2 };
            PersonLanguage test2 = new PersonLanguage() { Personid = 2, LanguageId = 1 };

            var testresult = _context.PersonLanguage.Find(test.Personid,test.LanguageId);
            var testresult2 = _context.PersonLanguage.Find(test2.Personid,test2.LanguageId);
            return _context.PersonLanguage.Where(l => l.LanguageId == languageId && l.Personid == personId).SingleOrDefault();
        }

        public PersonLanguage Find(PersonLanguage personLanguage)
        {
            return _context.PersonLanguage.Find(personLanguage);
        }

        public List<PersonLanguage> GetAll()
        {
            return _context.Set<PersonLanguage>().ToList();
        }

        public List<PersonLanguage> Search(string searchPhrase)
        {
            var personLanguagesFound = GetAll();
            personLanguagesFound = personLanguagesFound.Where(
                l => l.LanguageName.Contains(searchPhrase)
                ).ToList();
            return personLanguagesFound;
        }

        public bool UpdatePersonLanguage(PersonLanguage personLanguage)
        {
            var personLanguageToUpdate = Find(personLanguage);
            if (personLanguage.LanguageName != null) personLanguageToUpdate.LanguageName = personLanguage.LanguageName;
            if (personLanguage.Language != null) personLanguageToUpdate.Language = personLanguage.Language;
            if (personLanguage.Person != null) personLanguageToUpdate.Person = personLanguage.Person;
            return _context.SaveChanges() > 0 ? true : false;
        }
    }
    
}
