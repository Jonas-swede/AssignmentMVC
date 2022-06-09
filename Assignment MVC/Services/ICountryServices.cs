using Assignment_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_MVC.Services
{
    public interface ICountryServices
    {
        public bool CreateCountry(Country country);
        public Country FindById(int countryId);
        public Country FindByName(string countryName);
        public List<Country> GetAll();
        public bool UpdateCountry(Country country);
        public bool DeleteCountry(int countryId);
        
    }
}
