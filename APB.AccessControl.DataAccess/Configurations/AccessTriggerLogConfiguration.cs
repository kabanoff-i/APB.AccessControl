using APB.AccessControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APB.AccessControl.DataAccess.Configurations
{
    public class AccessTriggerLogConfiguration : IEntityTypeConfiguration<AccessTriggerLog>
    {
        public void Configure(EntityTypeBuilder<AccessTriggerLog> builder)
        {
            builder.HasKey(tl => tl.Id);

            builder.Property(tl => tl.TriggerId)
                .IsRequired();

            builder.Property(tl => tl.AccessLogId)
                .IsRequired();

            builder.Property(tl => tl.ExecutionResult)
                .IsRequired();

            builder.Property(tl => tl.ExecutedAt)
                .IsRequired();

            builder.Property(tl => tl.ErrorMessage)
                .HasColumnType("clob");

            builder.HasOne(tl => tl.Trigger)
                .WithMany(t => t.AccessTriggerLogs)
                .HasForeignKey(tl => tl.TriggerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(tl => tl.AccessLog)
                .WithMany()
                .HasForeignKey(tl => tl.AccessLogId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
} 