using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TypeAuthTest.Models;

namespace TypeAuthTest.Data.Configurations
{
    public class ClaimConfigurations : IEntityTypeConfiguration<Claim>
    {
        public void Configure(EntityTypeBuilder<Claim> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(500).IsRequired();
            builder.HasIndex(x => x.Name).IsUnique();

            builder.HasOne(x => x.Parent).WithMany(x => x.Childs)
                .IsRequired(false).HasForeignKey(x => x.ParentId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
