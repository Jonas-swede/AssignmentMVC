using Assignment_MVC.Data;
using Assignment_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_MVC.Services
{
    public class CityServices : ICityServices
    {
        private readonly ApplicationDbContext _context;
        private readonly ICountryServices _countryServices;

        public CityServices(ApplicationDbContext context,ICountryServices countryServices)
        {
            _context = context;
            _countryServices = countryServices;
        }

        public bool CreateCity(City city)
        {
            _context.Cities.Add(city);
            return _context.SaveChanges() > 0 ? true : false;
        }

        public bool DeleteCity(int CityId)
        {
            var cityToRemove = GetCity(CityId);
            _context.Remove(cityToRemove);
            return _context.SaveChanges() > 0 ? true : false;
        }

        public List<City> GetAll()
        {
            return _context.Set<City>().ToList();
        }

        public City GetCity(int CityId)
        {
            var city = _context.Cities.Find(CityId);
            city.CountryName = _countryServices.FindById(city.CountryId).CountryName;
            return city;
        }

        public List<City> Search(string SearchPhrase)
        {
            var cities = _context.Set<City>().Where(c=>
            c.CityName.Contains(SearchPhrase)||
            c.CountryName.Contains(SearchPhrase)
            ).ToList();
            return cities;
        }

        public bool UpdateCity(City c)
        {
            var CityToUpdate = GetCity(c.CityID);
            _context.Cities.Update(CityToUpdate);
            if (c.CityName != null) CityToUpdate.CityName = c.CityName;
            if (c.CountryName != null) CityToUpdate.CountryName = c.CountryName;
            if (c.CountryId != 0) CityToUpdate.CountryId = c.CountryId;
            if (c.People!=null&&c.People.Count >0) CityToUpdate.People = c.People;
            return _context.SaveChanges() > 0 ? true : false;
        }
    }
}
