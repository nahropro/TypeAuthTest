using System.Reflection.PortableExecutable;
using System.Security.Principal;

namespace TypeAuthTest.Models
{
    public class Claim
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public byte Datatype { get; set; }

        public byte ValueType { get; set; }

        public string MinMax { get; set; }

        public int? ParentId { get; set; }

        public Claim Parent { get; set; }

        public IEnumerable<Claim> Childs { get; set; }

        public IEnumerable<ClaimDependency> DependedOnThisClaim { get; set; }

        public IEnumerable<ClaimDependency> ThisClaimDependedOn { get; set; }

        public IEnumerable<RoleClaim> RoleClaims { get; set; }

        public Claim()
        {
            Childs = new List<Claim>();
            DependedOnThisClaim= new List<ClaimDependency>();
            ThisClaimDependedOn= new List<ClaimDependency>();
            RoleClaims= new List<RoleClaim>();
        }
    }
}
