using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_MVC.Models
{
    public class City
    {
        [Display]
        [Key]
        public int CityID { get; set; }
        [Display(Name = "City")]
        public string CityName { get; set; }
        [Display(Name = "Country")]
        public string CountryName { get; set; }
        public Country Country { get; set; } 
        public List<Person> People { get; set; }
    }
}
