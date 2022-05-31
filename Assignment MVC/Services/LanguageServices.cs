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

        public List<Language> Search()
        {
            throw new NotImplementedException();
        }

        public bool UpdateLanguage(Language l)
        {
            throw new NotImplementedException();
        }
    }
}
