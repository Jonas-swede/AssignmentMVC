using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment_MVC.Services;
using Newtonsoft.Json;
using Assignment_MVC.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class APIController : ControllerBase
    {
        private readonly IPersonService _personService;
        private readonly ILanguageServices _languageServices;
        private readonly ICountryServices _countryServices;
        private readonly ICityServices _cityServices;

        public APIController(IPersonService personService,ILanguageServices languageServices,ICountryServices countryServices,ICityServices cityServices)
        {
            _personService = personService;
            _languageServices = languageServices;
            _countryServices = countryServices;
            _cityServices = cityServices;
        }
        [Route ("getpersons")]

        [HttpGet]
        public string GetPersons()
        {
            var persons = _personService.GetAll();
            List<PersonJsonViewModel> personList = new List<PersonJsonViewModel>();
            foreach(Person p in persons)
            {
                PersonJsonViewModel personJsonViewModel = new PersonJsonViewModel() {
                    id = p.id,
                    Name = p.Name,
                    CityID = p.CityID,
                    CityName = p.City.CityName,
                    CountryName = p.City.CountryName,
                    PhoneNumber=p.PhoneNumber
                    
                };
                foreach(PersonLanguage l in p.PersonLanguages)
                {
                    LanguageJsonViewModel languageJsonViewModel = new LanguageJsonViewModel() {
                        LanguageId=l.LanguageId,
                        LanguageName=l.LanguageName
                    };
                    personJsonViewModel.PersonLanguages.Add(languageJsonViewModel);
                }
                personList.Add(personJsonViewModel);
            }
            var json = JsonConvert.SerializeObject(personList);
            return json;
        }
        [Route ("deleteperson")]
        [HttpPost]
        public bool DeletePerson(int id)
        {
            return _personService.DeletePerson(id);
        }

        [HttpPost]

        public bool TestFunction(string Name)
        {
            return true;
        }

        [HttpGet]
        [Route ("getlanguages")]
        public string GetLanguages()
        {
            var LanguageList = _languageServices.GetAll();
            List<LanguageDTO> languageDTOs = new List<LanguageDTO>();
            foreach(Language l in LanguageList)
            {
                var lang = new LanguageDTO();
                lang.LanguageId = l.LanguageId;
                lang.LanguageName = l.LanguageName;
                languageDTOs.Add(lang);
            }
            var json = JsonConvert.SerializeObject(languageDTOs);
            return json;
        }

        [HttpGet]
        [Route("getcountries")]
        public string GetCountries()
        {
            var CountryList = _countryServices.GetAll();
            List<CountryDTO> countryDTOs = new List<CountryDTO>();
            foreach (Country c in CountryList)
            {
                var country = new CountryDTO();
                country.CountryId = c.CountryId;
                country.CountryName = c.CountryName;
                
                List<CityDTO> cityDTOs = new List<CityDTO>();
                c.Cities = _cityServices.Search(c.CountryName);
                if(c.Cities!=null)
                    foreach (City city in c.Cities)
                    {
                        CityDTO cityDTO = new CityDTO();
                        cityDTO.CityID = city.CityID;
                        cityDTO.CityName = city.CityName;
                        cityDTOs.Add(cityDTO);
                    }
                country.cityDTOs = cityDTOs;
                countryDTOs.Add(country);
            }
            var json = JsonConvert.SerializeObject(countryDTOs);
            return json;
        }

        [HttpGet]
        [Route ("getcities")]
        public string GetCities()
        {
            var CityList = _cityServices.GetAll();
            var cityDTOs = new List<CityDTO>();
            foreach(City city in CityList)
            {
                CityDTO cityDTO = new CityDTO();
                cityDTO.CityID = city.CityID;
                cityDTO.CityName = city.CityName;
                cityDTO.CountryId = city.CountryId;
                cityDTO.CountryName = city.CountryName;
                cityDTOs.Add(cityDTO);
            }
            var json = JsonConvert.SerializeObject(cityDTOs);
            return json;
        }

        [HttpPost]
        [Route ("createperson")]

        public bool CreatePerson(string Name,string City,string PhoneNumber,int FirstLanguage)
        {
            return _personService.CreatePerson(Name, City, PhoneNumber, FirstLanguage);
           
        }
    }
}
