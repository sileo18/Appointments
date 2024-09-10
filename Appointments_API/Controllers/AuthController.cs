using Appointments_API.Models;
using Appointments_API.Models.Dto;
using Appointments_API.Repository.IRepository;
using Azure;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Appointments_API.Controllers
{
    [Route("api/customerAuth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _customerAuthenthicationRepository;

        public AuthController(IAuthRepository customerAuthenthicationRepository)
        {
            _customerAuthenthicationRepository = customerAuthenthicationRepository;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO customerLoginRequestDTO)
        {
            var log = await _customerAuthenthicationRepository.Login(customerLoginRequestDTO);
            var response = new ApiResponse();

            if (string.IsNullOrEmpty(log.Token) || log.Customer == null)
            {
                response.IsSuccess = false;
                response.StatusCode = HttpStatusCode.BadRequest;
                response.ErrorMessages = new List<string>() { "Email or password is incorrect" };
                return BadRequest(response);
            }

            response.IsSuccess = true;
            response.StatusCode = HttpStatusCode.OK;
            response.Result = log;
            return Ok(response);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationDTO customerRegistrationDTO)
        {
            var response = new ApiResponse();

            bool ifEmailUnique = _customerAuthenthicationRepository.IsUniqueUser(customerRegistrationDTO.Email);

            if (!ifEmailUnique)
            {
                response.IsSuccess = false;
                response.StatusCode = HttpStatusCode.BadRequest;
                response.ErrorMessages = new List<string>() { "Email is already registered!" };
                return BadRequest(response);
            }

            var user = await _customerAuthenthicationRepository.Register(customerRegistrationDTO);

            if (user == null)
            {
                response.IsSuccess = false;
                response.StatusCode = HttpStatusCode.BadRequest;
                response.ErrorMessages.Add("Error while registering");
                return BadRequest(response);
            }

            response.IsSuccess = true;
            response.StatusCode = HttpStatusCode.OK;
            response.Result = user;
            return Ok(response);
        }
    }
}
