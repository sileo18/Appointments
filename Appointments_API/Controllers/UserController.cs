using Appointments_API.Data;
using Appointments_API.Models;
using Appointments_API.Models.Dto;
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

        private readonly ApplicationDbContext _db;

        public UserController(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
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
            var user = await _db.users.FirstOrDefaultAsync(u => u.id == id);

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

            EntityEntry<User> userSaved = await _db.users.AddAsync(model);
            await _db.SaveChangesAsync();

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
            var user = await _db.users.FirstOrDefaultAsync(u => u.id == id);

            if (user == null)
            {
                return NotFound();
            }

            _db.users.Remove(user);
            await _db.SaveChangesAsync();
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

            _db.users.Update(model);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }    
}