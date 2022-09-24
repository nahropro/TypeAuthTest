namespace TypeAuthTest.Models
{
    public class ClaimDependency
    {
        public int BaseClaimId { get; set; }
        public int DependedOnClaimId { get; set; }
        public Claim BaseClaim { get; set; }
        public Claim DependedOnClaim { get; set; }
    }
}
