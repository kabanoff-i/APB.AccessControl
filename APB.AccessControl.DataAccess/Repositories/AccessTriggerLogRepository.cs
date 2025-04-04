using APB.AccessControl.Domain.Entities;
using APB.AccessControl.Domain.Exceptions;
using APB.AccessControl.Application.Interfaces;
using APB.AccessControl.Shared.Models.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using static APB.AccessControl.Application.Common.Extensions;

namespace APB.AccessControl.DataAccess.Repositories
{
    public class AccessTriggerLogRepository : IAccessTriggerLogRepository
    {
        private readonly AccessControlDbContext _context;
        private readonly ILogger<AccessTriggerLogRepository> _logger;

        public AccessTriggerLogRepository(AccessControlDbContext context, ILogger<AccessTriggerLogRepository> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<AccessTriggerLog>> GetByFilterAsync(IFilter<AccessTriggerLog> filter, CancellationToken cancellationToken = default)
        {
            return await _logger.HandleRepositoryOperationAsync(async () =>
            {
                var query = _context.AccessTriggerLogs.AsQueryable();
                
                query = query.Where(filter.GetExpression());
                
                query = query.Include(tl => tl.Trigger)
                            .Include(tl => tl.AccessLog);
                
                query = query.OrderByDescending(tl => tl.ExecutedAt);
                
                return await query.ToListAsync(cancellationToken);
            }, nameof(GetByFilterAsync), filter);
        }

        public async Task<AccessTriggerLog?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _logger.HandleRepositoryOperationAsync(async () =>
            {
                return await _context.AccessTriggerLogs
                    .Include(tl => tl.Trigger)
                    .Include(tl => tl.AccessLog)
                    .FirstOrDefaultAsync(tl => tl.Id == id, cancellationToken);
            }, nameof(GetByIdAsync), id);
        }

        public async Task<IEnumerable<AccessTriggerLog>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _logger.HandleRepositoryOperationAsync(async () =>
            {
                return await _context.AccessTriggerLogs
                    .Include(tl => tl.Trigger)
                    .Include(tl => tl.AccessLog)
                    .OrderByDescending(tl => tl.ExecutedAt)
                    .ToListAsync(cancellationToken);
            }, nameof(GetAllAsync));
        }

        public async Task<AccessTriggerLog?> AddAsync(AccessTriggerLog entity, CancellationToken cancellationToken = default)
        {
            return await _logger.HandleRepositoryOperationAsync(async () =>
            {
                await _context.AccessTriggerLogs.AddAsync(entity, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return entity;
            }, nameof(AddAsync), entity);
        }

        public async Task UpdateAsync(AccessTriggerLog entity, CancellationToken cancellationToken = default)
        {
            await _logger.HandleRepositoryExceptionAsync(async () =>
            {
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync(cancellationToken);
            }, nameof(UpdateAsync), entity);
        }

        public async Task DeleteAsync(AccessTriggerLog entity, CancellationToken cancellationToken = default)
        {
            await _logger.HandleRepositoryExceptionAsync(async () =>
            {
                _context.AccessTriggerLogs.Remove(entity);
                await _context.SaveChangesAsync(cancellationToken);
            }, nameof(DeleteAsync), entity);
        }

        public async Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _logger.HandleRepositoryOperationAsync(async () =>
            {
                return await _context.AccessTriggerLogs.AnyAsync(tl => tl.Id == id, cancellationToken);
            }, nameof(ExistsAsync), id);
        }
    }
} 