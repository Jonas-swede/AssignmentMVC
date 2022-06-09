using Assignment_MVC.Data;
using Assignment_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_MVC.Services
{
    public class LanguageServices : ILanguageServices
    {
        private readonly ApplicationDbContext _context;

        public LanguageServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool CreateLanguage(Language language)
        {
            _context.Language.Add(language);
            return _context.SaveChanges()>0?true:false;
        }

        public bool DeleteLanguage(int languageId)
        {
            var languageToRemove = GetLanguage(languageId);
            _context.Language.Remove(languageToRemove);
            return _context.SaveChanges() > 0 ? true : false;
        }

        public List<Language> GetAll()
        {
            return _context.Set<Language>().ToList();
        }

        public Language GetLanguage(int languageId)
        {
            return _context.Language.Find(languageId);
           
        }

        public Language GetLanguageByName(string name)
        {
            var langaugeFound=Search(name).First();
            

            return langaugeFound;
        }

        public List<Language> Search(string searchTerm)
        {
            return GetAll().Where(
                l=>l.LanguageName.Contains(searchTerm)
                ).ToList();
        }

        public bool UpdateLanguage(Language l)
        {
            var languageToUpdate = GetLanguage(l.LanguageId);
            _context.Language.Update(languageToUpdate);
            if (l.LanguageName != null) languageToUpdate.LanguageName = l.LanguageName;
            if (l.PersonLanguages!=null&&l.PersonLanguages.Count() >0) languageToUpdate.PersonLanguages = l.PersonLanguages;
            return _context.SaveChanges() > 0 ? true : false;
        }
    }
}
