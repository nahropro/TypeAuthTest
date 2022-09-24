using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TypeAuthTest.Models;

namespace TypeAuthTest.Data.Configurations
{
    public class ClaimDependencyConfigurations : IEntityTypeConfiguration<ClaimDependency>
    {
        public void Configure(EntityTypeBuilder<ClaimDependency> builder)
        {
            builder.HasKey(x => new { x.BaseClaimId, x.DependedOnClaimId });

            builder.HasOne(x=> x.BaseClaim).WithMany(x=> x.ThisClaimDependedOn)
                .HasForeignKey(x=>x.BaseClaimId).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.DependedOnClaim).WithMany(x => x.DependedOnThisClaim)
                .HasForeignKey(x => x.DependedOnClaimId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
