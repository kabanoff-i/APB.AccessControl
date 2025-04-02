using APB.AccessControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using APB.AccessControl.DataAccess.Configurations;
using APB.AccessControl.Domain.Abstractions;

namespace APB.AccessControl.DataAccess
{
    public class AccessControlDbContext : DbContext
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

        public AccessControlDbContext(DbContextOptions<AccessControlDbContext> options) 
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new CardConfiguration());
            modelBuilder.ApplyConfiguration(new AccessPointConfiguration());
            modelBuilder.ApplyConfiguration(new AccessLogConfiguration());
            modelBuilder.ApplyConfiguration(new NotificationConfiguration());
            modelBuilder.ApplyConfiguration(new TriggerConfiguration());
            modelBuilder.ApplyConfiguration(new AccessTriggerLogConfiguration());
        }

        public override int SaveChanges()
        {
            var modifiedEntities = ChangeTracker.Entries<AuditedEntity>()
                .Where(e => e.State == EntityState.Modified);

            var addedEntities = ChangeTracker.Entries<AuditedEntity>()
                .Where(e => e.State == EntityState.Added);

            foreach (var entity in modifiedEntities)
            {
                entity.Entity.UpdatedAt = DateTime.Now;
            }

            foreach (var entity in addedEntities)
            {
                entity.Entity.CreatedAt = DateTime.Now;
                entity.Entity.UpdatedAt = DateTime.Now;
            }

            return base.SaveChanges();
        }
    }
}
