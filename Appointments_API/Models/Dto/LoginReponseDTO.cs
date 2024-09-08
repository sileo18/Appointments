namespace Appointments_API.Models.Dto
{
    public class LoginResponseDTO
    {
        public Customer Customer { get; set; }
        public string Token { get; set; }
    }
}
