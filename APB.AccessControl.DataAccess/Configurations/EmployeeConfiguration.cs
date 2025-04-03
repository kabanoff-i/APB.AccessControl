using APB.AccessControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APB.AccessControl.DataAccess.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.FirstName)
                .IsRequired();

            builder.Property(e => e.LastName)
                .IsRequired();
            
            builder.Property(e => e.PatronymicName);

            builder.Property(e => e.PassportNumber)
                .IsRequired();

            builder.Property(e => e.Photo)
                .IsRequired();

            builder.Property(e => e.Department);

            builder.Property(e => e.Position);

            builder.Property(e => e.IsActive)
                .IsRequired();

            builder.Property(e => e.CreatedAt)
                .IsRequired();

            builder.Property(e => e.UpdatedAt)
                .IsRequired();

            builder.HasIndex(e => e.PassportNumber)
                .IsUnique();

            builder.HasMany(e => e.Cards)
                .WithOne(c => c.Employee)
                .HasForeignKey(c => c.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.AccessLogs)
                .WithOne(al => al.Employee)
                .HasForeignKey(al => al.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.Notifications)
                .WithOne(n => n.Employee)
                .HasForeignKey(n => n.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
