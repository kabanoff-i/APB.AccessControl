using APB.AccessControl.Domain.Entities;
using APB.AccessControl.Domain.Exceptions;
using APB.AccessControl.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using static APB.AccessControl.Application.Common.Extensions;

namespace APB.AccessControl.DataAccess.Repositories
{
    public class AccessPointTypeRepository : IAccessPointTypeRepository
    {
        private readonly AccessControlDbContext _context;
        private readonly ILogger<AccessPointTypeRepository> _logger;

        public AccessPointTypeRepository(AccessControlDbContext context, ILogger<AccessPointTypeRepository> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<AccessPointType?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _logger.HandleRepositoryOperationAsync(async () =>
            {
                return await _context.AccessPointTypes
                    .FirstOrDefaultAsync(apt => apt.Id == id, cancellationToken);
            }, nameof(GetByIdAsync), id);
        }

        public async Task<IEnumerable<AccessPointType>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _logger.HandleRepositoryOperationAsync(async () =>
            {
                return await _context.AccessPointTypes
                    .ToListAsync(cancellationToken);
            }, nameof(GetAllAsync));
        }

        public async Task<AccessPointType?> AddAsync(AccessPointType entity, CancellationToken cancellationToken = default)
        {
            return await _logger.HandleRepositoryOperationAsync(async () =>
            {
                await _context.AccessPointTypes.AddAsync(entity, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return entity;
            }, nameof(AddAsync), entity);
        }

        public async Task UpdateAsync(AccessPointType entity, CancellationToken cancellationToken = default)
        {
            await _logger.HandleRepositoryOperationAsync(async () =>
            {
                _context.AccessPointTypes.Update(entity);
                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }, nameof(UpdateAsync), entity);
        }

        public async Task<bool> ExistsAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _logger.HandleRepositoryOperationAsync(async () =>
            {
                return await _context.AccessPointTypes.AnyAsync(apt => apt.Id == id, cancellationToken);
            }, nameof(ExistsAsync), id);
        }

        public async Task DeleteAsync(AccessPointType entity, CancellationToken cancellationToken = default)
        {
            await _logger.HandleRepositoryExceptionAsync(async () =>
            {
                _context.AccessPointTypes.Remove(entity);
                await _context.SaveChangesAsync(cancellationToken);
            }, nameof(DeleteAsync), entity);
        }
    }
} 