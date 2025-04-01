using APB.AccessControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APB.AccessControl.DataAccess.Configurations
{
    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.HasKey(n => n.Id);

            builder.Property(n => n.AccessPointId)
                .IsRequired();

            builder.Property(n => n.ShowOnPass)
                .IsRequired();

            builder.Property(n => n.EmployeeId);

            builder.Property(n => n.ExpirationDate);

            builder.Property(n => n.Message)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(n => n.IsRead)
                .IsRequired();

            builder.Property(n => n.CreatedAt)
                .IsRequired();

            builder.Property(n => n.UpdatedAt)
                .IsRequired();

            builder.HasOne(n => n.Employee)
                .WithMany(e => e.Notifications)
                .HasForeignKey(n => n.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(n => n.AccessPoint)
                .WithMany(ap => ap.Notifications)
                .HasForeignKey(n => n.AccessPointId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
} 