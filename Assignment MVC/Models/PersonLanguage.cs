using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_MVC.Models
{
    public class PersonLanguage
    {
        public string LanguageName { get; set; }
        public Language Language { get; set; }
        public int Personid { get; set; }
        public Person Person { get; set; }
    }
}
