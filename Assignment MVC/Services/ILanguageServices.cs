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
        List<Language> Search();
        bool UpdateLanguage(Language language);
    }
}