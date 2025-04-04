using APB.AccessControl.Domain.Abstractions;
using APB.AccessControl.Domain.Entities; 
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APB.AccessControl.Domain.Exceptions;
using APB.AccessControl.Application.Interfaces;
using APB.AccessControl.Shared.Models.Common;
using Microsoft.Extensions.Logging;
using static APB.AccessControl.Application.Common.Extensions;

namespace APB.AccessControl.DataAccess.Repositories
{
    public class AccessRuleRepository : IAccessRuleRepository
    {
        private readonly AccessControlDbContext _context;
        private readonly ILogger<AccessRuleRepository> _logger;

        public AccessRuleRepository(AccessControlDbContext context, ILogger<AccessRuleRepository> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<AccessRule?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _logger.HandleRepositoryOperationAsync(async () =>
            {
                return await _context.AccessRules
                    .Include(ar => ar.AccessGroup)
                    .Include(ar => ar.AccessPoint)
                    .FirstOrDefaultAsync(ar => ar.Id == id, cancellationToken);
            }, nameof(GetByIdAsync), id);
        }

        public async Task<IEnumerable<AccessRule>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _logger.HandleRepositoryOperationAsync(async () =>
            {
                return await _context.AccessRules
                    .Include(ar => ar.AccessGroup)
                    .Include(ar => ar.AccessPoint)
                    .ToListAsync(cancellationToken);
            }, nameof(GetAllAsync));
        }

        public async Task<AccessRule?> AddAsync(AccessRule entity, CancellationToken cancellationToken = default)
        {
            return await _logger.HandleRepositoryOperationAsync(async () =>
            {
                await _context.AccessRules.AddAsync(entity, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return entity;
            }, nameof(AddAsync), entity);
        }

        public async Task UpdateAsync(AccessRule entity, CancellationToken cancellationToken = default)
        {
            await _logger.HandleRepositoryExceptionAsync(async () =>
            {
                _context.AccessRules.Update(entity);
                await _context.SaveChangesAsync(cancellationToken);
            }, nameof(UpdateAsync), entity);
        }

        public async Task DeleteAsync(AccessRule entity, CancellationToken cancellationToken = default)
        {
            await _logger.HandleRepositoryExceptionAsync(async () =>
            {
                _context.AccessRules.Remove(entity);
                await _context.SaveChangesAsync(cancellationToken);
            }, nameof(DeleteAsync), entity);
        }

        public async Task<bool> ExistsAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _logger.HandleRepositoryOperationAsync(async () =>
            {
                return await _context.AccessRules.AnyAsync(ar => ar.Id == id, cancellationToken);
            }, nameof(ExistsAsync), id);
        }

        public async Task<IEnumerable<AccessRule>> GetByFilterAsync(IFilter<AccessRule> filter, CancellationToken cancellationToken = default)
        {
            return await _logger.HandleRepositoryOperationAsync(async () =>
            {
                var query = _context.AccessRules.AsQueryable();

                query = query.Where(filter.GetExpression());    

                return await query.ToListAsync(cancellationToken);
            }, nameof(GetByFilterAsync), filter);
        }
    }
}