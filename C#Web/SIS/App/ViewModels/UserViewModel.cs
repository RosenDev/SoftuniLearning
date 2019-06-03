using System;
using System.ComponentModel.DataAnnotations;

namespace App.ViewModels
{
    public class UserViewModel
    {
        public string Id  { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

        public string Email { get; set; }

    }
}