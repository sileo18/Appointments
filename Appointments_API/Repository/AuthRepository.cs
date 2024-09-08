using Appointments_API.Data;
using Appointments_API.Models;
using Appointments_API.Models.Dto;
using Appointments_API.Repository.IRepository;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Appointments_API.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private string _secretKey;

        public AuthRepository (ApplicationDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _secretKey = configuration.GetValue<string>("ApiSettings:Secret");
        }

        public bool IsUniqueUser(string email)
        {
            var user = _dbContext.Customers.FirstOrDefault(x => x.Email == email);

            if (user==null)
            {
                return true;
            }

            return false;
        }

        public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO)
        {
           var user = _dbContext.Customers.FirstOrDefault(user =>  user.Email.ToLower() == loginRequestDTO.Email.ToLower() 
           && user.Password == loginRequestDTO.Password.ToLower());

        if (user==null)
            {
               return new LoginResponseDTO()
                {
                    Token ="",
                    Customer = null
                };
            }

            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Email.ToString()),
                    new Claim(ClaimTypes.Role, user.Role)

                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            LoginResponseDTO login = new LoginResponseDTO()
            {
                Token = tokenHandler.WriteToken(token),
                Customer = user
            };

            return login;
        }

        public async Task<User> Register(RegistrationDTO customerRegistrationDTO)
        {
            User customer = new()
            {
                Email = customerRegistrationDTO.Email,
                Name = customerRegistrationDTO.Name,
                Password = customerRegistrationDTO.Password,
                Phone = customerRegistrationDTO.Phone
            };

            _dbContext.Add(customer);

            await _dbContext.SaveChangesAsync();

            customer.Password = "";

            return customer;
        }
    }
}
