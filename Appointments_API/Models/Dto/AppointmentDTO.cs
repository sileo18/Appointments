using System.ComponentModel.DataAnnotations;

namespace Appointments_API.Models.Dto;

public class AppointmentGetDTO
{
    public int Id { get; set; }

    public DateTime DateTime { get; set; }

    public string? Title { get; set; }

    public int? JobId { get; set; }

    public string? JobName { get; set; }  

    public int? CustomerId { get; set; }

    public string? CustomerName { get; set; }  
}

