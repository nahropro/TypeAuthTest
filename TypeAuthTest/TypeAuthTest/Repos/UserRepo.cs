using Microsoft.EntityFrameworkCore;
using TypeAuthTest.Data;
using TypeAuthTest.Models;
using TypeAuthTest.Repos.Interfaces;

namespace TypeAuthTest.Repos
{
    public class UserRepo : IUserRepo
    {
        private readonly TypeAuthDbContext db;

        public UserRepo(TypeAuthDbContext db)
        {
            this.db = db;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            await db.Users.AddAsync(user);

            return user;
        }

        public async Task<User> GetUserAsync(int id)
        {
            return await db.Users.Include(x => x.UserInRoles).ThenInclude(x => x.Role).
                SingleAsync(x => x.Id == id);
        }

        public async Task<User> GetUserByUserNameAsync(string username)
        {
            return await db.Users.Include(x => x.UserInRoles).ThenInclude(x => x.Role).
                SingleAsync(x => x.Username.ToLower() == username.ToLower());
        }
    }
}
