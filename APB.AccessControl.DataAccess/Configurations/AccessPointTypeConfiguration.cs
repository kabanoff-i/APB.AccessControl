using APB.AccessControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APB.AccessControl.DataAccess.Configurations
{
    public class AccessPointTypeConfiguration : IEntityTypeConfiguration<AccessPointType>
    {
        public void Configure(EntityTypeBuilder<AccessPointType> builder)
        {
            builder.HasKey(apt => apt.Id);

            builder.Property(apt => apt.Name)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
} 