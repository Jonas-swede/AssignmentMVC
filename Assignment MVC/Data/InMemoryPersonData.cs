using Assignment_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_MVC.Data
{
    
    public class InMemoryPersonData : IPersonData
    {
        public string SearchString { get; set; }
        List<Person> IPersonData.persons { get; set; }

        public List<Person> persons;
        public InMemoryPersonData()
        {
            persons = new List<Person>()
            {
                new Person {id=1,Name="Kalle",City=new City{CityName="Stad 1" },PhoneNumber="01234562"},
                new Person {id=2,Name="Sten",City=new City{CityName="Stad 2" },PhoneNumber="01698941"},
                new Person {id=3,Name="Börje",City=new City{CityName="Stad 3" },PhoneNumber="016161814"}
            };
        }



        public List<Person> GetAll()
        {
            return persons;
        }

        public bool AddPerson(Person p)
        {
            persons.Add(p);
            return true;
        }

        public bool RemovePerson(int id)
        {
            if (persons.Exists(p => (p.id) == id))
            {
                return persons.Remove(persons.Single(p => (p.id) == id));
            }
            else return false;
            
        }

        public bool EditPerson(int id)
        {
            throw new NotImplementedException();
        }

        public Person GetById(int id)
        {
            if (persons.Exists(p => (p.id) == id))
            {
                return persons.Single(p => (p.id) == id);
            }
            else return null;

        }
    }
}
