using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_MVC.Models
{
    public class PersonViewModel
    {
        
        [Display(Name = "Search")]
        public string SearchPhrase { get; set; }
        public CreatePersonViewModel newPerson { get; set; }
        public List<Person> Persons { get; set; }

        public PersonViewModel(List<Person> data)
        {
            Persons = data;
        }

        public PersonViewModel()
        {

        }
      
    }
}
