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
    [Route("api/AppointmentAPI")]
    public class AppointmentController : ControllerBase
    {
        protected ApiResponse _response;

        private readonly IMapper _mapper;

        private readonly IAppointmentRepository _dbAppointment;

        public AppointmentController(IAppointmentRepository dbAppointment, IMapper mapper)
        {
            this._response = new();
            _dbAppointment = dbAppointment;
            _mapper = mapper;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}", Name = "GetAppointment")]
        public async Task<ActionResult<ApiResponse>> GetAppointment(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                var appointment = await _dbAppointment.GetAsync(u => u.Id == id, true,
                                                                 a => a.Customer,
                                                                 a => a.Job);

                if (appointment == null)
                {
                    return NotFound();
                }
                _response.Result = appointment;
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
        public async Task<ActionResult<ApiResponse>> CreateAppointment([FromBody] AppointmentCreateDTO appointmentCreateDTO)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (appointmentCreateDTO == null)
                {
                    return BadRequest(appointmentCreateDTO);
                }

                Appointment appointment = _mapper.Map<Appointment>(appointmentCreateDTO);
                await _dbAppointment.CreateAsync(appointment);

                _response.Result = appointment;
                _response.StatusCode = HttpStatusCode.Created;

                return CreatedAtRoute("GetAppointment", new { id = appointment.Id }, _response);
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
        public async Task<ActionResult<ApiResponse>> DeleteAppointment(int id)
        {
            try
            {
                if (id == 0)
                {

                    return BadRequest();

                }
                var appointment = await _dbAppointment.GetAsync(u => u.Id == id);

                if (appointment == null)
                {
                    return NotFound();
                }

                await _dbAppointment.RemoveAsync(appointment);

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
        public async Task<ActionResult<ApiResponse>> UpdateAppointment(int id, [FromBody] AppointmentUpdateDTO appointmentUpdateDTO)
        {
            try
            {
                if (appointmentUpdateDTO == null || id != appointmentUpdateDTO.Id)
                {
                    return BadRequest();
                }

                Appointment appointment = _mapper.Map<Appointment>(appointmentUpdateDTO);

                await _dbAppointment.UpdateAsync(appointment);

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