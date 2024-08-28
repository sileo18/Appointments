using Appointments_API.Data;
using Appointments_API.Models;
using Appointments_API.Models.Dto;
using Appointments_API.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Appointments_API.Controllers
{
    [ApiController]
    [Route("api/AppointmentsAPI")]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly IUserRepository _dbUser;

        public UserController(IUserRepository dbUser, IMapper mapper)
        {
            _dbUser = dbUser;
            _mapper = mapper;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}", Name = "GetUser")]
        public async Task<ActionResult<UserDTO>> GetUser(int id)
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

            return Ok(user);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost]
        public async Task<ActionResult<UserCreateDTO>> CreateUser([FromBody] UserCreateDTO userCreateDto) 
        {


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (userCreateDto == null)
            {
                return BadRequest(userCreateDto);
            }

            User model = _mapper.Map<User>(userCreateDto);

            await _dbUser.CreateAsync(model);            

            return CreatedAtRoute("GetUser", new { id = model.id }, model);
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete]
        public async Task<IActionResult> DeleteUser(int id)
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
            return NoContent();
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserUpdateDTO userUpdateDto)
        {
            if (userUpdateDto == null || id != userUpdateDto.id)
            {
                return BadRequest();
            }

            User model = _mapper.Map<User>(userUpdateDto);

            await _dbUser.UpdateAsync(model);
            return NoContent();
        }
    }    
}