﻿using System.ComponentModel.DataAnnotations;

namespace Appointments_API.Models.Dto
{
    public class UserDto
    {
        public int id { get; set; }
        [Required]
        [MaxLength(30)]
        public string name { get; set; }
        [Required]
        public string email { get; set; }
        public string password { get; set; }
        public string phone { get; set; }
    }
}
