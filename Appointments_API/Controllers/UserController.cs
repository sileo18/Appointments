using Appointments_API.Data;
using Appointments_API.Models;
using Appointments_API.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Appointments_API.Controllers
{
    [ApiController]
    [Route("api/AppointmentsAPI")]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public UserController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet("{id}", Name = "GetUser")]
        public ActionResult<UserDto> GetUser(int id)
        {
            if (id == 0)
            {

                return BadRequest();

            }
            var user = _db.users.FirstOrDefault(u => u.id == id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<UserDto> CreateUser([FromBody] UserDto userDto) 
        {


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (userDto == null)
            {
                return BadRequest(userDto);
            }

            User model = new()
            {
                email = userDto.email,
                phone = userDto.phone,
                name = userDto.name,
                password = userDto.password
            };

            _db.users.Add(model);
            _db.SaveChanges();

            return CreatedAtRoute("GetUser", new { id = userDto.id }, userDto);
        }
    }    
}