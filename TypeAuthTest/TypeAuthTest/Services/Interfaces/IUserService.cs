using TypeAuthTest.DTOs.UserDTOs;
using TypeAuthTest.Models;

namespace TypeAuthTest.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> RegisterUserAsync(RegisterUserDTO registerUser);
    }
}