using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TypeAuthTest.Models;

namespace TypeAuthTest.Data.Configurations
{
    public class RoleClaimConfigurations : IEntityTypeConfiguration<RoleClaim>
    {
        public void Configure(EntityTypeBuilder<RoleClaim> builder)
        {
            builder.HasKey(x => new { x.RoleId, x.ClaimId });

            builder.HasOne(x => x.Role).WithMany(x => x.RoleClaims)
                .HasForeignKey(x => x.RoleId).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Claim).WithMany(x => x.RoleClaims)
                .HasForeignKey(x => x.ClaimId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
