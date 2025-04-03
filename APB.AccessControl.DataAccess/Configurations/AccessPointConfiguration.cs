using APB.AccessControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APB.AccessControl.DataAccess.Configurations
{
    public class AccessPointConfiguration : IEntityTypeConfiguration<AccessPoint>
    {
        public void Configure(EntityTypeBuilder<AccessPoint> builder)
        {
            builder.HasKey(ap => ap.Id);

            builder.Property(ap => ap.Name)
                .IsRequired();

            builder.Property(ap => ap.IpAddress);

            builder.Property(ap => ap.Location);

            builder.Property(ap => ap.IsActive)
                .IsRequired();

            builder.Property(ap => ap.AccessPointTypeId)
                .IsRequired();
                
            builder.Property(ap => ap.CreatedAt)
                .IsRequired();

            builder.Property(ap => ap.UpdatedAt)
                .IsRequired();

            builder.HasOne(ap => ap.AccessPointType)
                .WithMany()
                .HasForeignKey(ap => ap.AccessPointTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(ap => ap.AccessLogs)
                .WithOne(al => al.AccessPoint)
                .HasForeignKey(al => al.AccessPointId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(ap => ap.Notifications)
                .WithOne(n => n.AccessPoint)
                .HasForeignKey(n => n.AccessPointId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(ap => ap.Triggers)
                .WithOne(t => t.AccessPoint)
                .HasForeignKey(t => t.AccessPointId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
} 