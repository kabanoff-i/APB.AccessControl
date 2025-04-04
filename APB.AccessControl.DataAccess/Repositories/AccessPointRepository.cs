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
    public class AccessPointRepository : IAccessPointRepository
    {
        private readonly AccessControlDbContext _context;
        private readonly ILogger<AccessPointRepository> _logger;

        public AccessPointRepository(AccessControlDbContext context, ILogger<AccessPointRepository> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<AccessPoint?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _logger.HandleRepositoryOperationAsync(async () =>
            {
                return await _context.AccessPoints
                    .Include(ap => ap.AccessPointType)
                    .FirstOrDefaultAsync(ap => ap.Id == id, cancellationToken);
            }, nameof(GetByIdAsync), id);
        }

        public async Task<IEnumerable<AccessPoint>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _logger.HandleRepositoryOperationAsync(async () =>
            {
                return await _context.AccessPoints
                    .Include(ap => ap.AccessPointType)
                    .ToListAsync(cancellationToken);
            }, nameof(GetAllAsync));
        }

        public async Task<AccessPoint?> AddAsync(AccessPoint entity, CancellationToken cancellationToken = default)
        {
            return await _logger.HandleRepositoryOperationAsync(async () =>
            {
                await _context.AccessPoints.AddAsync(entity, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return entity;
            }, nameof(AddAsync), entity);
        }

        public async Task UpdateAsync(AccessPoint entity, CancellationToken cancellationToken = default)
        {
            await _logger.HandleRepositoryExceptionAsync(async () =>
            {
                _context.AccessPoints.Update(entity);
                await _context.SaveChangesAsync(cancellationToken);
            }, nameof(UpdateAsync), entity);
        }

        public async Task DeleteAsync(AccessPoint entity, CancellationToken cancellationToken = default)
        {
            await _logger.HandleRepositoryExceptionAsync(async () =>
            {
                _context.AccessPoints.Remove(entity);
                await _context.SaveChangesAsync(cancellationToken);
            }, nameof(DeleteAsync), entity);
        }

        public async Task<bool> ExistsAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _logger.HandleRepositoryOperationAsync(async () =>
            {
                return await _context.AccessPoints.AnyAsync(ap => ap.Id == id, cancellationToken);
            }, nameof(ExistsAsync), id);
        }
    }
}