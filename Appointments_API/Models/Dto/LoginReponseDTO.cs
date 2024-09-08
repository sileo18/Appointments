namespace Appointments_API.Models.Dto
{
    public class LoginResponseDTO
    {
        public User Customer { get; set; }
        public string Token { get; set; }
    }
}
