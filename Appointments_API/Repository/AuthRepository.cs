using Appointments_API.Data;
using Appointments_API.Models;
using Appointments_API.Models.Dto;
using Appointments_API.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Appointments_API.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private string _secretKey;
        private readonly IMapper _mapper;

        public AuthRepository (ApplicationDbContext dbContext, IConfiguration configuration, UserManager<ApplicationUser> userMangaer,
            IMapper mapper, RoleManager<IdentityRole> roleManager)
        {
            _dbContext = dbContext;
            _secretKey = configuration.GetValue<string>("ApiSettings:Secret");
            _userManager = userMangaer;
            _mapper = mapper;
            _roleManager = roleManager;
        }

        public bool IsUniqueUser(string email)
        {
            var user = _dbContext.ApplicationUsers.FirstOrDefault(x => x.Email == email);

            if (user==null)
            {
                return true;
            }

            return false;
        }

        public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO)
        {
           var user = _dbContext.ApplicationUsers
                .FirstOrDefault(user =>  user.Email.ToLower() == loginRequestDTO.Email.ToLower());


            bool isValid = await _userManager.CheckPasswordAsync(user, loginRequestDTO.Password);

        if (user==null || isValid == false)
            {
               return new LoginResponseDTO()
                {
                    Token ="",
                    Customer = null
                };
            }

            var roles = await _userManager.GetRolesAsync(user);

            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Email.ToString()),
                    new Claim(ClaimTypes.Role, roles.FirstOrDefault())


                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            LoginResponseDTO login = new LoginResponseDTO()
            {
                Token = tokenHandler.WriteToken(token),
                Customer = _mapper.Map<UserDTO>(user),
                Role = roles.FirstOrDefault()
            };

            return login;
        }

        public async Task<UserDTO> Register(RegistrationDTO customerRegistrationDTO)
        {
            ApplicationUser customer = new()
            {
                Email = customerRegistrationDTO.Email,
                UserName = customerRegistrationDTO.Email,
                NormalizedEmail = customerRegistrationDTO.Email.ToUpper(),
                Name = customerRegistrationDTO.Name  
               
            };

            try
            {
                var result = await _userManager.CreateAsync(customer, customerRegistrationDTO.Password);
                await _dbContext.SaveChangesAsync();
                if (result.Succeeded)
                {
                    if (!_roleManager.RoleExistsAsync("Customer").GetAwaiter().GetResult()) {
                        await _roleManager.CreateAsync(new IdentityRole("Customer"));
                        await _roleManager.CreateAsync(new IdentityRole("Professional"));
                    }
                    await _userManager.AddToRoleAsync(customer, "Customer");
                    var userToReturn = _dbContext.ApplicationUsers.
                        FirstOrDefault(u => u.Email == customerRegistrationDTO.Email);

                   return _mapper.Map<UserDTO>(userToReturn);
                }
            }

            catch (Exception e)
            {

            }

            

            return new UserDTO();
        }
    }
}
