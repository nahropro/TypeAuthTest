using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TypeAuthTest.DTOs.UserDTOs;
using TypeAuthTest.Models;
using TypeAuthTest.Repos.Interfaces;
using TypeAuthTest.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TypeAuthTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public UsersController(IUnitOfWork unitOfWork, IUserService userService, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.userService = userService;
            this.mapper = mapper;
        }

        // GET: api/<UsersController>
        [HttpGet]
        [Authorize]
        public async Task<UserDTO> Get()
        {
            int userId = int.Parse(User.Claims.Single(x => x.Type == "UserId").Value);
            var user = await userService.GetUserAsync(userId);

            return mapper.Map<UserDTO>(user);
        }

        [HttpPost("SetUserInRole/{userId:int}")]
        public async Task<IActionResult> SetUserInRole(int userId, [FromBody] int[] roleIds)
        {
            var user = await userService.GetUserAsync(userId);

            if (user is null)
                return BadRequest("User-id is invalid");

            user.UserInRoles.AddRange(roleIds.Select(x =>
                new UserInRole
                {
                    RoleId=x
                }));

            await unitOfWork.SaveChangesAsync();

            user = await userService.GetUserAsync(userId);

            return Ok(mapper.Map<UserDTO>(user));
        }

        // POST api/<UsersController>
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDTO registerUser)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await userService.RegisterUserAsync(registerUser);

            await unitOfWork.SaveChangesAsync();

            return Ok(mapper.Map<UserDTO>(user));
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO login)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var token =await userService.LoginAsync(login);

            if (string.IsNullOrWhiteSpace(token))
                return BadRequest("Username or password is invalid");

            return Ok(token);
        }
    }
}
