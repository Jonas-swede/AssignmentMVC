using Assignment_MVC.Data;
using Assignment_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Assignment_MVC.Services;
using Microsoft.AspNetCore.Authorization;

namespace Assignment_MVC.Controllers
{
    [Authorize(Roles = "Admin")]


    public class CountriesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ICountryServices _countryServices;

        public CountriesController(ApplicationDbContext context, ICountryServices countryServices)
        {
            _context = context;
            _countryServices = countryServices;
        }
        public IActionResult Index()
        {
            return View(_countryServices.GetAll());
        }
        public IActionResult Create()
        {
            ViewData["CountryName"] = new SelectList(_countryServices.GetAll(), "CountryName", "CountryName");
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("CityID,CityName,CountryName")] Country country)
        {
            if (ModelState.IsValid)
            {
                _countryServices.CreateCountry(country);
                return RedirectToAction(nameof(Index));
            }
            return View(country);
        }

        public IActionResult EditCountry(int CountryId)
        {
            var country = _countryServices.FindById(CountryId);
            return View(country);
        }

        [HttpPost]
        public IActionResult EditCountry(Country country)
        {
            _countryServices.UpdateCountry(country);
            return RedirectToAction("Index");
        }

        public IActionResult RemoveCountry(int CountryId)
        {
            _countryServices.DeleteCountry(CountryId);
            return RedirectToAction("Index");
        }

    }

    
}

