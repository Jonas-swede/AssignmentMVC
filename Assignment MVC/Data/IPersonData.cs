using Assignment_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_MVC.Data
{
    public interface IPersonData
    {
        public string SearchString { get; set; }
        List<Person> persons { get; set; }

        List<Person> GetAll();

        public bool AddPerson(Person p);

        public bool RemovePerson(int id);

        public bool EditPerson(int id);
        public Person GetById(int id);

    }
}
