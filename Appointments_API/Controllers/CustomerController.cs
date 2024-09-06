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
    //[Route("api/AppointmentsAPI")]
    [Route("api/CustomersAPI")]
    public class CustomerController : ControllerBase
    {
        protected ApiResponse _response;

        private readonly IMapper _mapper;

        private readonly ICustomerRepository _dbUser;

        public CustomerController(ICustomerRepository dbUser, IMapper mapper)
        {
            this._response = new();
            _dbUser = dbUser;
            _mapper = mapper;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}", Name = "GetCustomer")]
        public async Task<ActionResult<ApiResponse>> GetCustomer(int id)
        {
            try
            {
                if (id == 0)
                {

                    return BadRequest();

                }
                var user = await _dbUser.GetAsync(u => u.Id == id);

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
        public async Task<ActionResult<ApiResponse>> CreateCustomer([FromBody] CustomerCreateDTO customerCreateDTO)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (customerCreateDTO == null)
                {
                    return BadRequest(customerCreateDTO);
                }

                Customer customer = _mapper.Map<Customer>(customerCreateDTO);
                await _dbUser.CreateAsync(customer);

                _response.Result = customer;
                _response.StatusCode = HttpStatusCode.Created;

                return CreatedAtRoute("GetCustomer", new { id = customer.Id }, _response);
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
        public async Task<ActionResult<ApiResponse>> DeleteCustomer(int id)
        {
            try
            {
                if (id == 0)
                {

                    return BadRequest();

                }
                var customer = await _dbUser.GetAsync(u => u.Id == id);

                if (customer == null)
                {
                    return NotFound();
                }

                await _dbUser.RemoveAsync(customer);

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
        public async Task<ActionResult<ApiResponse>> UpdateUser(int id, [FromBody] CustomerUpdateDTO customerUpdateDTO)
        {
            try
            {
                if (customerUpdateDTO == null || id != customerUpdateDTO.id)
                {
                    return BadRequest();
                }

                Customer customer = _mapper.Map<Customer>(customerUpdateDTO);

                await _dbUser.UpdateAsync(customer);

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