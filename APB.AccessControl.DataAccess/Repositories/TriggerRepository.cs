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
using APB.AccessControl.Domain.Primitives;

namespace APB.AccessControl.DataAccess.Repositories
{
    public class TriggerRepository : ITriggerRepository
    {
        private readonly AccessControlDbContext _context;
        private readonly ILogger<TriggerRepository> _logger;

        public TriggerRepository(AccessControlDbContext context, ILogger<TriggerRepository> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<Trigger>> GetByAccessPointAsync(int accessPointId, CancellationToken cancellationToken = default)
        {
            return await _logger.HandleRepositoryOperationAsync(async () =>
            {
                return await _context.Triggers
                    .Where(t => t.AccessPointId == accessPointId)
                    .Include(t => t.ActionType)
                    .ToListAsync(cancellationToken);
            }, nameof(GetByAccessPointAsync), accessPointId);
        }

        public async Task<IEnumerable<Trigger>> GetByActionTypeAsync(int actionTypeId, CancellationToken cancellationToken = default)
        {
            return await _logger.HandleRepositoryOperationAsync(async () =>
            {
                return await _context.Triggers
                    .Where(t => t.ActionType == (ActionType)actionTypeId)
                    .Include(t => t.AccessPoint)
                    .ToListAsync(cancellationToken);
            }, nameof(GetByActionTypeAsync), actionTypeId);
        }

        public async Task<Trigger?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _logger.HandleRepositoryOperationAsync(async () =>
            {
                return await _context.Triggers
                    .Include(t => t.AccessPoint)
                    .Include(t => t.ActionType)
                    .FirstOrDefaultAsync(t => t.Id == id, cancellationToken);
            }, nameof(GetByIdAsync), id);
        }

        public async Task<IEnumerable<Trigger>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _logger.HandleRepositoryOperationAsync(async () =>
            {
                return await _context.Triggers
                    .Include(t => t.AccessPoint)
                    .Include(t => t.ActionType)
                    .ToListAsync(cancellationToken);
            }, nameof(GetAllAsync));
        }

        public async Task<Trigger?> AddAsync(Trigger entity, CancellationToken cancellationToken = default)
        {
            return await _logger.HandleRepositoryOperationAsync(async () =>
            {
                await _context.Triggers.AddAsync(entity, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return entity;
            }, nameof(AddAsync), entity);
        }

        public async Task UpdateAsync(Trigger entity, CancellationToken cancellationToken = default)
        {
            await _logger.HandleRepositoryExceptionAsync(async () =>
            {
                _context.Triggers.Update(entity);
                await _context.SaveChangesAsync(cancellationToken);
            }, nameof(UpdateAsync), entity);
        }

        public async Task DeleteAsync(Trigger entity, CancellationToken cancellationToken = default)
        {
            await _logger.HandleRepositoryExceptionAsync(async () =>
            {
                _context.Triggers.Remove(entity);
                await _context.SaveChangesAsync(cancellationToken);
            }, nameof(DeleteAsync), entity);
        }

        public async Task<bool> ExistsAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _logger.HandleRepositoryOperationAsync(async () =>
            {
                return await _context.Triggers.AnyAsync(t => t.Id == id, cancellationToken);
            }, nameof(ExistsAsync), id);
        }
    }
} 