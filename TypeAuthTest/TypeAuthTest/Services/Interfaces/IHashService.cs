using TypeAuthTest.DTOs.General;

namespace TypeAuthTest.Services.Interfaces
{
    public interface IHashService
    {
        HashDTO GenerateHash(string password);
        bool VerifyPassword(string password, byte[] salt, byte[] passwordHash);
    }
}