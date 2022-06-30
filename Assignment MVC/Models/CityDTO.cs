using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_MVC.Models
{
    public class CityDTO
    {
        public int CityID { get; set; }
        public string CityName { get; set; }
        public string CountryName { get; set; }
        public int CountryId { get; set; }
        
    }
}
