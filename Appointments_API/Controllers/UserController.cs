using Appointments_API.Data;
using Appointments_API.Models;
using Appointments_API.Models.Dto;
using Appointments_API.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Net;

namespace Appointments_API.Controllers
{
    [ApiController]
    [Route("api/AppointmentsAPI")]
    public class UserController : ControllerBase
    {
        protected ApiResponse _response;

        private readonly IMapper _mapper;

        private readonly IUserRepository _dbUser;

        public UserController(IUserRepository dbUser, IMapper mapper)
        {
            this._response = new();
            _dbUser = dbUser;
            _mapper = mapper;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}", Name = "GetUser")]
        public async Task<ActionResult<ApiResponse>> GetUser(int id)
        {
            try
            {
                if (id == 0)
                {

                    return BadRequest();

                }
                var user = await _dbUser.GetAsync(u => u.id == id);

                if (user == null)
                {
                    return NotFound();
                }
                _response.Result = user;
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return Ok();
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost]
        public async Task<ActionResult<ApiResponse>> CreateUser([FromBody] UserCreateDTO userCreateDto)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (userCreateDto == null)
                {
                    return BadRequest(userCreateDto);
                }

                User user = _mapper.Map<User>(userCreateDto);
                await _dbUser.CreateAsync(user);

                _response.Result = user;
                _response.StatusCode = HttpStatusCode.Created;

                return CreatedAtRoute("GetUser", new { id = user.id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return Ok();
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete]
        public async Task<ActionResult<ApiResponse>> DeleteUser(int id)
        {
            try
            {
                if (id == 0)
                {

                    return BadRequest();

                }
                var user = await _dbUser.GetAsync(u => u.id == id);

                if (user == null)
                {
                    return NotFound();
                }

                await _dbUser.RemoveAsync(user);

                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.NoContent;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return Ok();
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut]
        public async Task<ActionResult<ApiResponse>> UpdateUser(int id, [FromBody] UserUpdateDTO userUpdateDto)
        {
            try
            {
                if (userUpdateDto == null || id != userUpdateDto.id)
                {
                    return BadRequest();
                }

                User model = _mapper.Map<User>(userUpdateDto);

                await _dbUser.UpdateAsync(model);

                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.NoContent;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return Ok();
        }
    }
}