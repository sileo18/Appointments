using Appointments_API.Models.Dto;
using Appointments_API.Models;
using Appointments_API.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.AspNetCore.Authorization;

namespace Appointments_API.Controllers
{
    [Route("api/JobAPI")]
    [ApiController]
    public class JobController : ControllerBase
    {
        protected ApiResponse _response;
        private readonly IMapper _mapper;
        private readonly IProfessionalRepository _dbProfessional;
        private readonly IJobRepository _dbJob;

        public JobController(IMapper mapper, IJobRepository dbJob, IProfessionalRepository dbProfessional)
        {
            this._response = new();
            _mapper = mapper;
            _dbJob = dbJob;
            _dbProfessional = dbProfessional;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}", Name = "GetJob")]
        [Authorize]
        public async Task<ActionResult<ApiResponse>> GetJob(int id)
        {
            try
            {
                if (id == 0)
                {

                    return BadRequest();

                }

                var job = await _dbJob.GetAsync(u => u.Id == id);

                if (job == null)
                {
                    return NotFound();
                }

                _response.Result = job;
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
        [Authorize(Roles = "Professional")]
        public async Task<ActionResult<ApiResponse>> CreateJob([FromBody] JobCreateDTO jobCreateDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                if (await _dbProfessional.GetAsync(u => u.Id == jobCreateDTO.ProfessionalId) == null)
                {
                    ModelState.AddModelError("Custom Error", "Professional Id is invalid!");
                    return BadRequest(ModelState);
                }
                if (jobCreateDTO == null)
                {
                    return BadRequest(jobCreateDTO);
                }

                Job job = _mapper.Map<Job>(jobCreateDTO);
                await _dbJob.CreateAsync(job);
                var jobDto = _mapper.Map<JobDTO>(job);

                _response.Result = jobDto;
                _response.StatusCode = HttpStatusCode.Created;
                _response.IsSuccess = true;

                return CreatedAtRoute("GetJob", new { id = jobDto.id }, _response);
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
        [Authorize(Roles = "Professional")]
        public async Task<ActionResult<ApiResponse>> DeleteJob(int id)
        {
            try
            {
                if (id == 0)
                {

                    return BadRequest();

                }
                var job = await _dbJob.GetAsync(u => u.Id == id);

                if (job == null)
                {
                    return NotFound();
                }

                await _dbJob.RemoveAsync(job);

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
        [Authorize(Roles = "Professional")]
        public async Task<ActionResult<ApiResponse>> UpdateService(int id,[FromBody] JobUpdateDTO jobUpdateDTO)
        {
            try
            {
                if (jobUpdateDTO == null || id != jobUpdateDTO.id)
                {
                    return BadRequest();
                }

                if (await _dbProfessional.GetAsync(u => u.Id == jobUpdateDTO.ProfessionalId) == null)
                {
                    ModelState.AddModelError("Custom Error", "Professional Id is invalid!");
                    return BadRequest(ModelState);
                }               

                Job job = _mapper.Map<Job>(jobUpdateDTO);

                await _dbJob.UpdateAsync(job);

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
