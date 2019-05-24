using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace App.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

        public string Nickname { get; set; }

    }
}
