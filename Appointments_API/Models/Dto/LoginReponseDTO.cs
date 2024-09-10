namespace Appointments_API.Models.Dto
{
    public class LoginResponseDTO
    {
        public UserDTO Customer { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
    }
}
