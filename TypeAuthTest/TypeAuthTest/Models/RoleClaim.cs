namespace TypeAuthTest.Models
{
    public class RoleClaim
    {
        public int RoleId { get; set; }
        public int ClaimId { get; set; }
        public string Value { get; set; }
        public bool Active { get; set; }

        public Role Role { get; set; }

        public Claim Claim { get; set; }
    }
}
