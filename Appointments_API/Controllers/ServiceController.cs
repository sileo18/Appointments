using Appointments_API.Models;
using Appointments_API.Models.Dto;
using Appointments_API.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Runtime.ConstrainedExecution;


namespace Appointments_API.Controllers
{
    [Route("api/ServiceAPI")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        protected ApiResponse _response;
        private readonly IMapper _mapper;
        private readonly IProfessionalRepository _dbProfessional;
        private readonly IServiceRepository _dbService;

        public ServiceController(IMapper mapper, IServiceRepository dbService, IProfessionalRepository dbProfessional)
        {
            this._response = new();
            _mapper = mapper;
            _dbService = dbService;
            _dbProfessional = dbProfessional;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}", Name = "GetService")]

        public async Task<ActionResult<ApiResponse>> GetService(int id)
        {
            try
            {
                if (id == 0)
                {

                    return BadRequest();

                }

                var service = await _dbService.GetAsync(u => u.id == id);

                if (service == null)
                {
                    return NotFound();
                }

                _response.Result = service;
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
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
        [HttpPost]
        public async Task<ActionResult<ApiResponse>> CreateService([FromBody] ServiceCreateDTO serviceCreateDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                if (await _dbProfessional.GetAsync(u => u.id == serviceCreateDTO.ProfessionalId)== null)
                {
                    ModelState.AddModelError("Custom Error", "Professional Id is invalid!");
                    return BadRequest(ModelState);
                }
                if (serviceCreateDTO == null)
                {
                    return BadRequest(serviceCreateDTO);
                }

                Service service = _mapper.Map<Service>(serviceCreateDTO);
                await _dbService.CreateAsync(service);

                _response.Result = service;
                _response.StatusCode = HttpStatusCode.Created;
                _response.IsSuccess = true;

                return CreatedAtRoute("GetService", new { id = service.id }, _response);
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
        public async Task<ActionResult<ApiResponse>> DeleteService(int id)
        {
            try
            {
                if (id == 0)
                {

                    return BadRequest();

                }
                var service = await _dbService.GetAsync(u => u.id == id);

                if (service == null)
                {
                    return NotFound();
                }

                await _dbService.RemoveAsync(service);

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
        public async Task<ActionResult<ApiResponse>> UpdateService(int id,[FromBody] ServiceUpdateDTO serviceUpdateDto)
        {
            try
            {
                if (serviceUpdateDto == null || id != serviceUpdateDto.id)
                {
                    return BadRequest();
                }

                if (await _dbProfessional.GetAsync(u => u.id == serviceUpdateDto.ProfessionalId) == null)
                {
                    ModelState.AddModelError("Custom Error", "Professional Id is invalid!");
                    return BadRequest(ModelState);
                }               

                Service service = _mapper.Map<Service>(serviceUpdateDto);

                await _dbService.UpdateAsync(service);

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
