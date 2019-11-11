using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Cache;
using PANDA.Data.Models.Enums;

namespace PANDA.Data.Models
{
    public class User
    {
        public User()
        {
            Packages = new HashSet<Package>();
            Receipts = new HashSet<Receipt>();
        }
        public string Id  { get; set;}
        
        [Required]
        [MaxLength(20)]
        [MinLength(5)]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [MaxLength(20)]
        [MinLength(5)]
        public string Email { get; set; }

        public UserRole UserRole { get; set; }

        public ICollection<Package> Packages { get; set; }

        public ICollection<Receipt> Receipts { get; set; }
    }
}