using Appointments_API.Data;
using Appointments_API.Models;
using Appointments_API.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

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
        public ActionResult<UserDTO> GetUser(int id)
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
        public ActionResult<UserCreateDTO> CreateUser([FromBody] UserCreateDTO userCreateDto) 
        {


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (userCreateDto == null)
            {
                return BadRequest(userCreateDto);
            }

            User model = new()
            {
                email = userCreateDto.email,
                phone = userCreateDto.phone,
                name = userCreateDto.name,
                password = userCreateDto.password
            };

            EntityEntry<User> userSaved = _db.users.Add(model);
            _db.SaveChanges();

            return CreatedAtRoute("GetUser", new { id = model.id }, model);
        }
    }    
}