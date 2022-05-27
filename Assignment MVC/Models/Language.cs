﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_MVC.Models
{
    public class Language
    {
        [Key]
        public string LanguageName { get; set; }
        public List<PersonLanguage> PersonLanguages { get; set; }
    }
}
