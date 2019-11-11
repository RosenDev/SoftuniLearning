using System;
using System.Collections.Generic;
using PANDA.Models.Enums;

namespace PANDA.Models
{
    public class User
    {
        public User()
        {
            Packages = new HashSet<Package>();
            Receipts = new HashSet<Receipt>();
        }
        public string Id  { get; set;}
        
        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public UserRole UserRole { get; set; }

        public ICollection<Package> Packages { get; set; }

        public ICollection<Receipt> Receipts { get; set; }
    }
}