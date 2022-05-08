﻿using System.ComponentModel.DataAnnotations;

namespace CSharp.Api.DataTransferObjects
{
    public class RegisterDto
    {
        [Required]
        public string DisplayName { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression("(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{8,24}$", ErrorMessage = "Password need to be more complex")]
        public string Password { get; set; }

    }
}
