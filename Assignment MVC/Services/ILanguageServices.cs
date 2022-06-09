using Assignment_MVC.Models;
using System.Collections.Generic;

namespace Assignment_MVC.Services
{
    public interface ILanguageServices
    {
        bool CreateLanguage(Language language);
        bool DeleteLanguage(int languageId);
        List<Language> GetAll();
        Language GetLanguage(int languageId);
        Language GetLanguageByName(string name);
        List<Language> Search(string searchTerm);
        bool UpdateLanguage(Language language);
    }
}