using Assignment_MVC.Models;
using System.Collections.Generic;

namespace Assignment_MVC.Services
{
    public interface ICityServices
    {
        bool CreateCity(City city);
        bool DeleteCity(int CityId);
        List<City> GetAll();
        City GetCity(int CityId);
        List<City> Search(string SearchPhrase);
        bool UpdateCity(City c);
    }
}