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
        public CityServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool CreateCity()
        {
            throw new NotImplementedException();
        }

        public bool DeleteCity(string name)
        {
            throw new NotImplementedException();
        }

        public List<City> GetAll()
        {
            return _context.Set<City>().ToList();
        }

        public City GetCity(string name)
        {
            throw new NotImplementedException();
        }

        public List<City> Search()
        {
            throw new NotImplementedException();
        }

        public bool UpdateCity(City c)
        {
            throw new NotImplementedException();
        }
    }
}
