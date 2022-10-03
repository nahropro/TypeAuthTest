using AutoMapper;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using TypeAuthTest.AccessTree;
using TypeAuthTest.DTOs.RoleDTOs;
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
            CreateMap<Role, RoleDTO>()
                .ForMember(x => x.AccessTree, s => s.MapFrom(x => JsonSerializer.Deserialize<BaseAction>(x.AccessTree,
                new JsonSerializerOptions())));

            CreateMap<RegisterUserDTO, User>();
            CreateMap<CreateRoleDTO, Role>()
                .ForMember(x => x.AccessTree, s => s.MapFrom(x => JsonSerializer.Serialize(x.AccessTree,
                new JsonSerializerOptions())));
        }
    }
}
