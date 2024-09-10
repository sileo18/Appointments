﻿using System.ComponentModel.DataAnnotations;

namespace Appointments_API.Models.Dto
{
    public class RegistrationDTO
    {        
        public string Name { get; set; }        
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Phone { get; set; }
    }
}
