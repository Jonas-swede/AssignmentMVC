using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_MVC.Models
{
    public class CountryDTO
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public List<CityDTO> cityDTOs { get; set; }
    }
}
