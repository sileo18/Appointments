using System.ComponentModel.DataAnnotations;

namespace Appointments_API.Models.Dto;

public class AppointmentUpdateDTO
{

    [Required]
    public int Id { get; set; }

    [Required]
    public DateTime DateTime { get; set; }

    [Required]
    public string? Title { get; set; }

    [Required]
    public int? JobId { get; set; }

    [Required]
    public int? CustomerId { get; set; }
}

