using AutoMapper;
using TypeAuthTest.DTOs.UserDTOs;
using TypeAuthTest.Models;

namespace TypeAuthTest.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>()
                .ForMember(x=> x.Roles, s=> s.MapFrom(x=> x.UserInRoles.Select(p=> p.Role)));
            CreateMap<Role, RoleDTO>();

            CreateMap<RegisterUserDTO, User>();
        }
    }
}
