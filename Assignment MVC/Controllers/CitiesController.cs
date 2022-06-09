using Assignment_MVC.Data;
using Assignment_MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment_MVC.Services;

namespace Assignment_MVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CitiesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ICountryServices _countryServices;
        private readonly ICityServices _cityServices;

        public CitiesController(ApplicationDbContext context,ICountryServices countryServices,ICityServices cityServices)
        {
            _context = context;
            _countryServices = countryServices;
            _cityServices = cityServices;
        }
        public IActionResult Index()
        {
            List<City> cities = _context.Cities.ToList();
            foreach (City c in cities)
            {
                c.CountryName = _countryServices.FindById(c.CountryId).CountryName;
            }
            return View(cities);
        }

        public IActionResult Create()
        {
            ViewData["CountryName"] = new SelectList(_context.Countries, "CountryId", "CountryName");
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("CityName,CountryId")] City city)
        {
            if (ModelState.IsValid)
            {
                _context.Add(city);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(city);
        }

       
        public IActionResult EditCity(int CityID)
        {
            ViewData["Countries"] = new SelectList(_countryServices.GetAll(), "CountryId", "CountryName");
            var city = _cityServices.GetCity(CityID);
            city.Country = _countryServices.FindById(city.CountryId);
            return View(city);
        }

        [HttpPost]
        public IActionResult EditCity(City city)
        {
            _cityServices.UpdateCity(city);
            return RedirectToAction("Index");

        }

        public IActionResult RemoveCity(int CityID)
        {
            _cityServices.DeleteCity(CityID);
            return RedirectToAction("Index");
        }
    }
}
