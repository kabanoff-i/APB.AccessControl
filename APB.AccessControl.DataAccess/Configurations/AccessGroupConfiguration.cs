using APB.AccessControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APB.AccessControl.DataAccess.Configurations
{
    public class AccessGroupConfiguration : IEntityTypeConfiguration<AccessGroup>
    {
        public void Configure(EntityTypeBuilder<AccessGroup> builder)
        {
            builder.HasKey(ag => ag.Id);

            builder.Property(ag => ag.Name)
                .IsRequired();

            builder.Property(ag => ag.IsActive)
                .IsRequired();

            builder.Property(ag => ag.CreatedAt)
                .IsRequired();

            builder.Property(ag => ag.UpdatedAt)
                .IsRequired();

            builder.HasMany(ag => ag.AccessRules)
                .WithOne(ar => ar.AccessGroup)
                .HasForeignKey(ar => ar.AccessGroupId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
} 