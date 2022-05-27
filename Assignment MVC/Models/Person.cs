﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_MVC.Models
{
    public class Person
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
        public int CityID { get; set; }
        public City City { get; set; }
        public string PhoneNumber { get; set; }
        public List<PersonLanguage> PersonLanguages { get; set; }

    }
}
