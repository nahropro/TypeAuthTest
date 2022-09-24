namespace TypeAuthTest.Models
{
    public class Role
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<UserInRole> UserInRoles { get; set; }
        public IEnumerable<RoleClaim> RoleClaims { get; set; }

        public Role()
        {
            UserInRoles=new  List<UserInRole>();
            RoleClaims=new List<RoleClaim>();
        }
    }
}
