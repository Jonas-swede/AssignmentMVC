using Assignment_MVC.Models;
using System.Collections.Generic;

namespace Assignment_MVC.Services
{
    public interface IPersonLanguageServices
    {
        bool CreatePersonLanguage(int languageId, int personId);
        bool DeletePersonLanguage(PersonLanguage personLanguage);
        PersonLanguage Find(int languageId, int personId);
        List<PersonLanguage> GetAll();
        List<PersonLanguage> Search(string searchPhrase);
        bool UpdatePersonLanguage(PersonLanguage personLanguage);
    }
}