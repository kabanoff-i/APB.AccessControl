using APB.AccessControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using APB.AccessControl.Domain.Primitives;

namespace APB.AccessControl.DataAccess.Configurations
{
    public class AccessLogConfiguration : IEntityTypeConfiguration<AccessLog>
    {
        public void Configure(EntityTypeBuilder<AccessLog> builder)
        {
            builder.HasKey(al => al.Id);

            builder.Property(al => al.CardHash)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(al => al.EmployeeId);

            builder.Property(al => al.AccessPointId);

            builder.Property(al => al.AccessResult)
                .HasConversion(
                    v => v.ToString(),      // При сохранении в БД будет строкой
                    v => (AccessResult)Enum.Parse(typeof(AccessResult), v) // При чтении из БД
                )
                .IsRequired();


            builder.Property(al => al.DateAccess)
                .IsRequired();

            builder.Property(al => al.Message)
                .HasMaxLength(500);

            builder.Property(al => al.CreatedAt)
                .IsRequired();

            builder.Property(al => al.UpdatedAt)
                .IsRequired();

            builder.HasOne(al => al.Card)
                .WithMany(c => c.AccessLogs)
                .HasForeignKey(al => al.CardId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(al => al.Employee)
                .WithMany(e => e.AccessLogs)
                .HasForeignKey(al => al.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(al => al.AccessPoint)
                .WithMany(ap => ap.AccessLogs)
                .HasForeignKey(al => al.AccessPointId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
} 