using System;
using System.Collections.Generic;
using PANDA.Models.Enums;

namespace PANDA.Models
{
    public class User
    {
       
        public Guid Id  { get; set;}
        
        
        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public Role Role { get; set; }

        public ICollection<Package> Packages { get; set; }

        public ICollection<Receipt> Receipts { get; set; }
    }
}