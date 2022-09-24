using System.Collections;

namespace TypeAuthTest.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] Salt { get; set; }

        public IEnumerable<UserInRole> UserInRoles { get; set; }

        public User()
        {
            UserInRoles=new List<UserInRole>();
        }
    }
}
