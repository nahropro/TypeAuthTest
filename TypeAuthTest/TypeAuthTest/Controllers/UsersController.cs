using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TypeAuthTest.DTOs.UserDTOs;
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
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
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
