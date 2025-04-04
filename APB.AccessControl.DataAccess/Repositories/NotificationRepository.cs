using APB.AccessControl.Domain.Entities;
using APB.AccessControl.Domain.Exceptions;
using APB.AccessControl.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using static APB.AccessControl.Application.Common.Extensions;
using APB.AccessControl.Shared.Models.Common;

namespace APB.AccessControl.DataAccess.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly AccessControlDbContext _context;
        private readonly ILogger<NotificationRepository> _logger;

        public NotificationRepository(AccessControlDbContext context, ILogger<NotificationRepository> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Notification?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _logger.HandleRepositoryOperationAsync(async () =>
            {
                return await _context.Notifications
                    .Include(n => n.Employee)
                    .Include(n => n.AccessPoint)
                    .FirstOrDefaultAsync(n => n.Id == id, cancellationToken);
            }, nameof(GetByIdAsync), id);
        }

        public async Task<IEnumerable<Notification>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _logger.HandleRepositoryOperationAsync(async () =>
            {
                return await _context.Notifications
                    .Include(n => n.Employee)
                    .Include(n => n.AccessPoint)
                    .OrderByDescending(n => n.CreatedAt)
                    .ToListAsync(cancellationToken);
            }, nameof(GetAllAsync));
        }

        public async Task<Notification?> AddAsync(Notification entity, CancellationToken cancellationToken = default)
        {
            return await _logger.HandleRepositoryOperationAsync(async () =>
            {
                await _context.Notifications.AddAsync(entity, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return entity;
            }, nameof(AddAsync), entity);
        }

        public async Task UpdateAsync(Notification entity, CancellationToken cancellationToken = default)
        {
            await _logger.HandleRepositoryExceptionAsync(async () =>
            {
                _context.Notifications.Update(entity);
                await _context.SaveChangesAsync(cancellationToken);
            }, nameof(UpdateAsync), entity);
        }

        public async Task DeleteAsync(Notification entity, CancellationToken cancellationToken = default)
        {
            await _logger.HandleRepositoryExceptionAsync(async () =>
            {
                _context.Notifications.Remove(entity);
                await _context.SaveChangesAsync(cancellationToken);
            }, nameof(DeleteAsync), entity);
        }

        public async Task<bool> ExistsAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _logger.HandleRepositoryOperationAsync(async () =>
            {
                return await _context.Notifications.AnyAsync(n => n.Id == id, cancellationToken);
            }, nameof(ExistsAsync), id);
        }

        public async Task<IEnumerable<Notification>> GetByFilter(IFilter<Notification> filter, CancellationToken cancellationToken = default)
        {
            return await _logger.HandleRepositoryOperationAsync(async () =>
            {
                var query = _context.Notifications.AsQueryable();
                query = query.Where(filter.GetExpression());
                return await query.ToListAsync(cancellationToken);
            }, nameof(GetByFilter), filter);
        }
    }
} 