using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using System.Security.Cryptography;

namespace App.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

        public string Email { get; set; }

    }
}
