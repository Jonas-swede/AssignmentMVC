using Assignment_MVC.Models;
using System.Collections.Generic;

namespace Assignment_MVC.Services
{
    public interface IPersonService
    {
        bool CreatePerson(string Name,string City, string PhoneNumber,int FirstLanguage);
        bool DeletePerson(int id);
        Person ReadPerson(int id);
        List<Person> FindPeople(string SearchPhrase);
        List<Person> GetAll();
        bool UpdatePerson(Person p);
    }
}