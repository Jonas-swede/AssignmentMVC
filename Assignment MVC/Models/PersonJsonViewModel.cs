using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_MVC.Models
{
    public class PersonJsonViewModel
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int CityID { get; set; }
        public string CityName { get; set; }
        public string CountryName { get; set; }
        public string PhoneNumber { get; set; }
        public List<LanguageJsonViewModel> PersonLanguages { get; set; }

        public PersonJsonViewModel()
        {
            PersonLanguages = new List<LanguageJsonViewModel>();
        }
    }
}
