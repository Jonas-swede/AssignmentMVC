using Assignment_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_MVC.Data
{
    public class PersonData:IPersonData
    {
        public readonly ApplicationDbContext _context;

        public PersonData(ApplicationDbContext context)
        {
            _context = context;
        }
        public string SearchString { get; set; }
        public List<Person> persons { get; set; }

        public bool AddPerson(Person p)
        {
            _context.People.Add(p);
            return _context.SaveChanges() > 0 ? true : false;


        }

        public bool EditPerson(int id)
        {
            throw new NotImplementedException();
        }

        public List<Person> GetAll()
        {
            var returnList = _context.Set<Person>().ToList();
            foreach(Person p in returnList)
            {
                p.City = _context.Cities.Find(p.CityID);
            }
            return returnList;
        }

        public Person GetById(int id)
        {
            return _context.People.Find(id);
        }

        public bool RemovePerson(int id)
        {
            Person personToRemove = GetById(id);
            _context.People.Remove(personToRemove);
            return _context.SaveChanges() > 0 ? true : false;
        }
    }
}
