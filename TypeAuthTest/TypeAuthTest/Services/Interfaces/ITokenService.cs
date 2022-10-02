using TypeAuthTest.Models;

namespace TypeAuthTest.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateJwtToken(User user, int expireAfterDays = 30);
    }
}