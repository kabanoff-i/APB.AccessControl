using APB.AccessControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APB.AccessControl.DataAccess.Configurations
{
    public class AccessGridConfiguration : IEntityTypeConfiguration<AccessGrid>
    {
        public void Configure(EntityTypeBuilder<AccessGrid> builder)
        {
            builder.HasKey(x => new { x.EmployeeId, x.AccessGroupId });

            builder.Property(x => x.IsActive)
                .IsRequired();

            builder.Property(x => x.CreatedAt)
                .IsRequired();

            builder.Property(x => x.UpdatedAt)
                .IsRequired();

            builder.HasOne(x => x.Employee)
                .WithMany(e => e.AccessGrids)
                .HasForeignKey(x => x.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.AccessGroup)
                .WithMany(g => g.AccessGrids)
                .HasForeignKey(x => x.AccessGroupId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

