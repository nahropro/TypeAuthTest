using TypeAuthTest.Models;

namespace TypeAuthTest.Repos.Interfaces
{
    public interface IUserRepo
    {
        Task<User> CreateUserAsync(User user);
        Task<User> GetUserAsync(int id);
        Task<User> GetUserByUserNameAsync(string username);
    }
}