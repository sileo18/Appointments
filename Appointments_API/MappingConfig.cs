
using Appointments_API.Models;
using Appointments_API.Models.Dto;
using AutoMapper;
namespace Appointments_API

{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<UserCreateDTO, User>();
            CreateMap<User, UserCreateDTO>();

            CreateMap<UserUpdateDTO, User>();
            CreateMap<User, UserUpdateDTO>();

            CreateMap<ProfessionalCreateDTO, Professional>();
            CreateMap<Professional, ProfessionalCreateDTO>();

            CreateMap<ProfessionalUpdateDTO, Professional>();
            CreateMap<Professional, ProfessionalUpdateDTO>();

            CreateMap<ServiceCreateDTO, Service>();
            CreateMap<Service, ServiceCreateDTO>();

            CreateMap<ServiceUpdateDTO, Service>();
            CreateMap<Service, ServiceUpdateDTO>();
        }
    }
}
