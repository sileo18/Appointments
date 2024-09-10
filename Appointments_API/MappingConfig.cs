using Appointments_API.Models;
using Appointments_API.Models.Dto;
using AutoMapper;
namespace Appointments_API

{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<RegistrationDTO, User>();
            CreateMap<User, RegistrationDTO>();           

            CreateMap<ProfessionalCreateDTO, Professional>();
            CreateMap<Professional, ProfessionalCreateDTO>();

            CreateMap<ProfessionalUpdateDTO, Professional>();
            CreateMap<Professional, ProfessionalUpdateDTO>();

            CreateMap<JobCreateDTO, Job>();
            CreateMap<Job, JobCreateDTO>();

            CreateMap<JobUpdateDTO, Job>();
            CreateMap<Job, JobUpdateDTO>();

            CreateMap<AppointmentCreateDTO, Appointment>();
            CreateMap<Appointment, AppointmentCreateDTO>();

            CreateMap<AppointmentUpdateDTO, Appointment>();
            CreateMap<Appointment, AppointmentUpdateDTO>();

            CreateMap<ApplicationUser, UserDTO>().ReverseMap();
            
        }
    }
}
