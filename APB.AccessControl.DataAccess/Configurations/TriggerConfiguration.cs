using APB.AccessControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using APB.AccessControl.Domain.Primitives;

namespace APB.AccessControl.DataAccess.Configurations
{
    public class TriggerConfiguration : IEntityTypeConfiguration<Trigger>
    {
        public void Configure(EntityTypeBuilder<Trigger> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.AccessPointId)
                .IsRequired();

            builder.Property(t => t.AccessResult)
                .HasConversion(
                    v => v.ToString(),      // При сохранении в БД будет строкой
                    v => (AccessResult)Enum.Parse(typeof(AccessResult), v) // При чтении из БД
                )
                .IsRequired();

            builder.Property(t => t.ActionType)
                .HasConversion(
                    v => v.ToString(),      // При сохранении в БД будет строкой
                    v => (ActionType)Enum.Parse(typeof(ActionType), v) // При чтении из БД
                )   
                .IsRequired();

            builder.Property(t => t.ActionValue)
                .HasMaxLength(500);

            builder.Property(t => t.IsActive)
                .IsRequired();

            builder.Property(t => t.CreatedAt)
                .IsRequired();

            builder.Property(t => t.UpdatedAt)
                .IsRequired();

            builder.HasOne(t => t.AccessPoint)
                .WithMany(ap => ap.Triggers)
                .HasForeignKey(t => t.AccessPointId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(t => t.AccessTriggerLogs)
                .WithOne(tl => tl.Trigger)
                .HasForeignKey(tl => tl.TriggerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
} 