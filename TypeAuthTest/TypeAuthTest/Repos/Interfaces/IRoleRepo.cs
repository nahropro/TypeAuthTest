using TypeAuthTest.AccessTree;
using TypeAuthTest.DTOs.RoleDTOs;
using TypeAuthTest.Models;

namespace TypeAuthTest.Repos.Interfaces
{
    public interface IRoleRepo
    {
        Task<Role> CreateRoleAsync(Role role);
        Task<List<RoleDTO>> GetAll();
        Task<Role> GetAsync(int id);
        void RemoveRole(Role role);
        Task<Role> UpdateRoleAccessTreeAsync(Role role, BaseAction accessTree);
    }
}