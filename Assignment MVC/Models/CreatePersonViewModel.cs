using Google.Type;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_MVC.Models
{
    

    public class CreatePersonViewModel
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        [MaxLength(20)]
        public string City { get; set; }

        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\d{9,15}$", ErrorMessage = "Not a valid phone number")]
        public string PhoneNumber { get; set; }

        public string Language { get; set; }
    }
}
