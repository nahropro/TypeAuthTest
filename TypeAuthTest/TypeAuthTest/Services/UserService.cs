using TypeAuthTest.DTOs.UserDTOs;
using TypeAuthTest.Models;
using TypeAuthTest.Repos.Interfaces;
using TypeAuthTest.Services.Interfaces;

namespace TypeAuthTest.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo userRepo;
        private readonly IHashService hashService;
        private readonly ITokenService tokenService;

        public UserService(IUserRepo userRepo, IHashService hashService, ITokenService tokenService)
        {
            this.userRepo = userRepo;
            this.hashService = hashService;
            this.tokenService = tokenService;
        }

        public async Task<User> RegisterUserAsync(RegisterUserDTO registerUser)
        {
            var hash = hashService.GenerateHash(registerUser.Password);

            User user = new()
            {
                Username = registerUser.Username,
                PasswordHash = hash.PasswordHash,
                Salt = hash.Salt,
            };

            user = await userRepo.CreateUserAsync(user);

            return user;
        }

        public async Task<string> LoginAsync(LoginDTO login)
        {
            var user = await userRepo.GetUserByUserNameAsync(login.Username);

            if (user is null)
                return null;

            if (!hashService.VerifyPassword(login.Password, user.Salt, user.PasswordHash))
                return null;

            return tokenService.GenerateJwtToken(user);
        }

        public async Task<User> GetUserAsync(int id)
        {
            return await userRepo.GetUserAsync(id);
        }
    }
}
