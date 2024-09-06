using System.ComponentModel.DataAnnotations;

namespace Appointments_API.Models.Dto;

public class AppointmentCreateDTO
{
    [Required]
    public DateTime DateTime { get; set; }

    [Required]
    [MaxLength(30)]
    public string? Title { get; set; }

    [Required]
    public int? JobId { get; set; }

    [Required]
    public int? CustomerId { get; set; }
}
