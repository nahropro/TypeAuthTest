using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;
using TypeAuthTest.AccessTree;
using TypeAuthTest.Data;
using TypeAuthTest.DTOs.RoleDTOs;
using TypeAuthTest.Models;
using TypeAuthTest.Repos.Interfaces;

namespace TypeAuthTest.Repos
{
    public class RoleRepo : IRoleRepo
    {
        private readonly TypeAuthDbContext db;
        private readonly IMapper mapper;

        public RoleRepo(TypeAuthDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<Role> GetAsync(int id)
        {
            return await db.Roles.FindAsync(id);
        }

        public async Task<List<RoleDTO>> GetAll()
        {
            return await db.Roles.ProjectTo<RoleDTO>(mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<Role> CreateRoleAsync(Role role)
        {
            await db.Roles.AddAsync(role);

            return role;
        }

        public void RemoveRole(Role role)
        {
            db.Roles.Remove(role);
        }

        public async Task<Role> UpdateRoleAccessTreeAsync(Role role, BaseAction accessTree)
        {
            role.AccessTree = JsonSerializer.Serialize(accessTree);

            return role;
        }
    }
}
