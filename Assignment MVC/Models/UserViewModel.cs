using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_MVC.Models
{
    public class UserViewModel
    {
        public List<UserSelected> Users { get; set; }
        public List<IdentityRole> Roles { get; set; }
        public UserViewModel()
        {
            Users = new List<UserSelected>();
        }
        public string NewRole { get; set; }
        public string UserId { get; set; }
    }


    public class UserSelected
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public IList<string> Roles { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

