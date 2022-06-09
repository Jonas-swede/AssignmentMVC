using Assignment_MVC.Data;
using Assignment_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_MVC.Services
{
    public class CountryServices : ICountryServices
    {
        private readonly ApplicationDbContext _context;

        public CountryServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool CreateCountry(Country country)
        {
            _context.Countries.Add(country);
            return _context.SaveChanges() > 0 ? true : false;
        }

        public bool DeleteCountry(int countryId)
        {
            var countryToDelete = FindById(countryId);
            _context.Countries.Remove(countryToDelete);
            return _context.SaveChanges() > 0 ? true : false;
        }

        public Country FindById(int countryId)
        {
            return _context.Countries.Find(countryId);
        }

        public Country FindByName(string countryName)
        {
            var allCountries = GetAll();
            return allCountries.Where(c => c.CountryName.Contains(countryName)).First();
        }

        public List<Country> GetAll()
        {
            return _context.Set<Country>().ToList();
        }

        public bool UpdateCountry(Country country)
        {
            var countryToUpdate = FindById(country.CountryId);
            if (country.CountryName != null) countryToUpdate.CountryName = country.CountryName;
            if (country.Cities!=null&&country.Cities.Count >0) countryToUpdate.Cities = country.Cities;
            return _context.SaveChanges() > 0 ? true : false;
        }
    }
}
