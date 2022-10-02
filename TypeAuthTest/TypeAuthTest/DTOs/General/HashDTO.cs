namespace TypeAuthTest.DTOs.General
{
    public class HashDTO
    {
        public byte[] Salt { get; set; }

        public byte[] PasswordHash { get; set; }
    }
}
