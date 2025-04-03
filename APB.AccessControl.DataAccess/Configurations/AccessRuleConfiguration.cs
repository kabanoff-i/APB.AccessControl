using APB.AccessControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using APB.AccessControl.DataAccess.Common;

namespace APB.AccessControl.DataAccess.Configurations
{
    public class AccessRuleConfiguration : IEntityTypeConfiguration<AccessRule>
    {
        public void Configure(EntityTypeBuilder<AccessRule> builder)
        {
            builder.HasKey(ar => ar.Id);

            builder.Property(ar => ar.AccessGroupId);

            builder.Property(ar => ar.AccessPointId);

            builder.Property(ar => ar.AllowedTimeStart)
                .IsRequired();

            builder.Property(ar => ar.AllowedTimeEnd)
                .IsRequired();

            builder.Property(ar => ar.DaysOfWeek)
                .IsRequired()
                //.HasConversion(new BitArrayToLongConverter())
                .HasColumnType("bit(7)");

            builder.Property(ar => ar.SpecificDates)
                .HasColumnType("jsonb");

            builder.Property(ar => ar.IsActive)
                .IsRequired();

            builder.Property(ar => ar.CreatedAt)
                .IsRequired();

            builder.Property(ar => ar.UpdatedAt)
                .IsRequired();

            builder.HasOne(ar => ar.AccessGroup)
                .WithMany(ag => ag.AccessRules)
                .HasForeignKey(ar => ar.AccessGroupId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ar => ar.AccessPoint)
                .WithMany(ap => ap.AccessRules)
                .HasForeignKey(ar => ar.AccessPointId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
} 