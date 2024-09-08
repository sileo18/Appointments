using Appointments_API.Models;
using Appointments_API.Models.Dto;

namespace Appointments_API.Repository.IRepository
{
    public interface IAuthRepository
    {
        bool IsUniqueUser(string email); 
        Task<LoginResponseDTO> Login(LoginRequestDTO customerLoginRequestDTO);
        Task<User> Register(RegistrationDTO customerRegistrationDTO);
    }
}
