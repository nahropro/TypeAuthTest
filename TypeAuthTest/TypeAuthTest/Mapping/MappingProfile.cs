using AutoMapper;
using TypeAuthTest.DTOs.UserDTOs;
using TypeAuthTest.Models;

namespace TypeAuthTest.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>();

            CreateMap<RegisterUserDTO, User>();
        }
    }
}
