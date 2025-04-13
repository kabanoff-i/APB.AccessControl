using APB.AccessControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using APB.AccessControl.DataAccess.Configurations;
using APB.AccessControl.Domain.Abstractions;
using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using APB.AccessControl.DataAccess.Identity;
using Microsoft.AspNetCore.Identity;

namespace APB.AccessControl.DataAccess
{
    public class AccessControlDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<AccessPoint> AccessPoints { get; set; }
        public DbSet<AccessLog> AccessLogs { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Trigger> Triggers { get; set; }
        public DbSet<AccessTriggerLog> AccessTriggerLogs { get; set; }
        public DbSet<AccessGroup> AccessGroups { get; set; }
        public DbSet<AccessRule> AccessRules { get; set; }
        public DbSet<AccessGrid> AccessGrids { get; set; }
        public DbSet<AccessPointType> AccessPointTypes { get; set; }

        public AccessControlDbContext(DbContextOptions<AccessControlDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=AccessControlDb;Username=postgres;Password=mysecretpassword");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            //modelBuilder.ApplyConfiguration(new CardConfiguration());
            //modelBuilder.ApplyConfiguration(new AccessPointConfiguration());
            //modelBuilder.ApplyConfiguration(new AccessLogConfiguration());
            //modelBuilder.ApplyConfiguration(new NotificationConfiguration());
            //modelBuilder.ApplyConfiguration(new TriggerConfiguration());
            //modelBuilder.ApplyConfiguration(new AccessTriggerLogConfiguration());
            //modelBuilder.ApplyConfiguration(new AccessPointTypeConfiguration());
            //modelBuilder.ApplyConfiguration(new AccessGroupConfiguration());
            //modelBuilder.ApplyConfiguration(new AccessRuleConfiguration());
            //modelBuilder.ApplyConfiguration(new AccessGridConfiguration());

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AccessControlDbContext).Assembly);
        }

        public override int SaveChanges()
        {
            OnSavingChanges();

            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            OnSavingChanges();

            return base.SaveChangesAsync(cancellationToken);
        }

        private void OnSavingChanges()
        {
            ConvertDateTimesToUtc();

            var modifiedEntities = ChangeTracker.Entries<AuditedEntity>()
                .Where(e => e.State == EntityState.Modified);

            var addedEntities = ChangeTracker.Entries<AuditedEntity>()
                .Where(e => e.State == EntityState.Added);

            foreach (var entity in modifiedEntities)
            {
                entity.Entity.UpdatedAt = DateTime.UtcNow;
            }

            foreach (var entity in addedEntities)
            {
                entity.Entity.CreatedAt = DateTime.UtcNow;
                entity.Entity.UpdatedAt = DateTime.UtcNow;
            }
        }

        private void ConvertDateTimesToUtc()
        {
            var entries = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (var entry in entries)
            {
                foreach (var property in entry.Properties)
                {
                    if (property.CurrentValue is DateTime dateTime)
                    {
                        if (dateTime.Kind == DateTimeKind.Unspecified || dateTime.Kind == DateTimeKind.Local)
                        {
                            property.CurrentValue = dateTime.ToUniversalTime();
                        }
                    }
                    else if (property.CurrentValue is DateTimeOffset dateTimeOffset)
                    {
                        property.CurrentValue = dateTimeOffset.ToUniversalTime();
                    }
                }
            }
        }
    }
}
