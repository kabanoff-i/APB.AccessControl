using APB.AccessControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APB.AccessControl.DataAccess.Configurations
{
    public class AccessPointTypeConfiguration : IEntityTypeConfiguration<AccessPointType>
    {
        public void Configure(EntityTypeBuilder<AccessPointType> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .IsRequired();

            builder.Property(e => e.Name)
                .IsRequired();

            builder.HasMany(e => e.AccessPoints)
                .WithOne(e => e.AccessPointType)
                .HasForeignKey(e => e.AccessPointTypeId);
        }
    }
}
