using Assignment_MVC.Models;
using System.Collections.Generic;

namespace Assignment_MVC.Services
{
    public interface ICityServices
    {
        bool CreateCity();
        bool DeleteCity(string name);
        List<City> GetAll();
        City GetCity(string name);
        List<City> Search();
        bool UpdateCity(City c);
    }
}