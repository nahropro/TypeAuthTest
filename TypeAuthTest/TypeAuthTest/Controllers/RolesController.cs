using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyModel.Resolution;
using TypeAuthTest.DTOs.RoleDTOs;
using TypeAuthTest.Models;
using TypeAuthTest.Repos.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TypeAuthTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IRoleRepo roleRepo;
        private readonly IMapper mapper;

        public RolesController(IUnitOfWork unitOfWork, IRoleRepo roleRepo, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.roleRepo = roleRepo;
            this.mapper = mapper;
        }

        // GET: api/<RolesController>
        [HttpGet]
        public async Task<List<RoleDTO>> Get()
        {
            return await roleRepo.GetAll();
        }

        // GET api/<RolesController>/5
        [HttpGet("{id}")]
        public async Task<RoleDTO> Get(int id)
        {
            var role= await roleRepo.GetAsync(id);
            return mapper.Map<RoleDTO>(role);
        }

        // POST api/<RolesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateRoleDTO roleDTO)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var role = mapper.Map<Role>(roleDTO);

            role = await roleRepo.CreateRoleAsync(role);
            await unitOfWork.SaveChangesAsync();

            return Ok(mapper.Map<RoleDTO>(role));
        }

        // PUT api/<RolesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RolesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var role = await roleRepo.GetAsync(id);

            if (role is null)
                return BadRequest("Role not found");

            roleRepo.RemoveRole(role);

            await unitOfWork.SaveChangesAsync();

            return Ok(mapper.Map<RoleDTO>(role));
        }
    }
}
