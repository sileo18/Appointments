
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
        }
    }
}
