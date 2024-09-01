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
    [Route("api/ProfessionalAPI")]
    public class ProfessionalController : ControllerBase
    {
        protected ApiResponse _response;

        private readonly IMapper _mapper;

        private readonly IProfessionalRepository _dbProfessional;

        public ProfessionalController(IProfessionalRepository dbProfessional, IMapper mapper)
        {
            this._response = new();
            _dbProfessional = dbProfessional;
            _mapper = mapper;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id:int}", Name = "GetProfessional")]
        public async Task<ActionResult<ApiResponse>> GetProfessional(int id)
        {
            try
            {
                if (id == 0)
                {

                    return BadRequest();

                }
                var professional = await _dbProfessional.GetAsync(u => u.id == id);

                if (professional == null)
                {
                    return NotFound();
                }
                _response.Result = professional;
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
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost]
        public async Task<ActionResult<ApiResponse>> CreateProfessional([FromBody] ProfessionalCreateDTO professionalCreateDTO)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (professionalCreateDTO == null)
                {
                    return BadRequest(professionalCreateDTO);
                }

                Professional professional = _mapper.Map<Professional>(professionalCreateDTO);
                await _dbProfessional.CreateAsync(professional);

                _response.Result = professional;
                _response.StatusCode = HttpStatusCode.Created;

                return CreatedAtRoute("GetProfessional", new { id = professional.id }, _response);
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
        public async Task<ActionResult<ApiResponse>> DeleteProfessional(int id)
        {
            try
            {
                if (id == 0)
                {

                    return BadRequest();

                }
                var professional = await _dbProfessional.GetAsync(u => u.id == id);

                if (professional == null)
                {
                    return NotFound();
                }

                await _dbProfessional.RemoveAsync(professional);

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
        [HttpPut("{id:int}", Name = "UpdateProfessional")]
        public async Task<ActionResult<ApiResponse>> UpdateProfessional(int id, [FromBody] ProfessionalUpdateDTO  professionalUpdateDTO)
        {
            try
            {
                if (professionalUpdateDTO == null || id != professionalUpdateDTO.id)
                {
                    return BadRequest();
                }

                Professional professional = _mapper.Map<Professional>(professionalUpdateDTO);

                await _dbProfessional.UpdateAsync(professional);

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