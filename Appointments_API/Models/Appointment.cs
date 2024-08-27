﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Appointments_API.Models
{
    public class Appointment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public DateTime dateTime { get; set; }        
        public int userId { get; set; }
        public int serviceId {  get; set; }
        public int professionalId { get; set; }

    }
}