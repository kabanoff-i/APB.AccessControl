using APB.AccessControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APB.AccessControl.DataAccess.Configurations
{
    public class CardConfiguration : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Hash)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.IsActive)
                .IsRequired();

            builder.Property(c => c.CreatedAt)
                .IsRequired();

            builder.Property(c => c.UpdatedAt)
                .IsRequired();

            builder.HasIndex(c => c.Hash)
                .IsUnique();

            builder.HasOne(c => c.Employee)
                .WithMany(e => e.Cards)
                .HasForeignKey(c => c.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.AccessLogs)
                .WithOne(al => al.Card)
                .HasForeignKey(al => al.CardId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
} 