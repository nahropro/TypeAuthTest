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

        public UserService(IUserRepo userRepo, IHashService hashService)
        {
            this.userRepo = userRepo;
            this.hashService = hashService;
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
    }
}
