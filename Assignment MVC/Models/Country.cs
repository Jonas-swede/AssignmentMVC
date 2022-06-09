using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_MVC.Models
{
    public class Country
    {
        
        [Required]
        [Key]
        public int CountryId { get; set; }
        public string CountryName { get; set; }

        public List<City> Cities { get; set; }
    }
}
