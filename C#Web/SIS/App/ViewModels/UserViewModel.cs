using System;
using SIS.WebServer.Attributes.Validation;


namespace App.ViewModels
{
    public class UserViewModel
    {
       
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

        [Required]
        public string ConfirmPassword { get; set; }
        [Required]
        public string Email { get; set; }

    }
}