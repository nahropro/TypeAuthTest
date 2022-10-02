using System.Security.Cryptography;
using System.Text;
using System;
using TypeAuthTest.DTOs.General;
using TypeAuthTest.Services.Interfaces;

namespace TypeAuthTest.Services
{
    public class HashService : IHashService
    {
        public HashDTO GenerateHash(string password)
        {
            HashDTO result = new HashDTO();

            using (var hmac = new HMACSHA512())
            {
                result.Salt = hmac.Key;
                result.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }

            return result;
        }

        public bool VerifyPassword(string password, byte[] salt, byte[] passwordHash)
        {
            using (var hmac = new HMACSHA512(salt))
            {
                var generatedPassowrdHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                return generatedPassowrdHash.SequenceEqual(passwordHash);
            }
        }
    }
}
