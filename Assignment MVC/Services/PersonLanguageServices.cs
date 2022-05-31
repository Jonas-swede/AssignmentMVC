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
            _context.PersonLanguage.Add(personLanguageToAdd);
            return _context.SaveChanges()>0?true:false;
            
        }

        public bool DeletePersonLanguage(PersonLanguage personLanguage)
        {
            var personLanguageToDelete = Find(personLanguage.LanguageId, personLanguage.Personid);
            _context.Remove(personLanguageToDelete);
            return _context.SaveChanges() > 0 ? true : false;
        }

        public PersonLanguage Find(int languageId, int personId)
        {
            return _context.PersonLanguage.Find(languageId, personId);
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
            throw new NotImplementedException();
        }
    }
}
