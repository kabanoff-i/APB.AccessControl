using APB.AccessControl.Domain.Entities;
using APB.AccessControl.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using APB.AccessControl.Domain.Exceptions;
using Microsoft.Extensions.Logging;
using static APB.AccessControl.Application.Common.Extensions;

namespace APB.AccessControl.DataAccess.Repositories
{
    public class AccessGridRepository : IAccessGridRepository
    {
        private readonly AccessControlDbContext _context;
        private readonly ILogger<AccessGridRepository> _logger;

        public AccessGridRepository(AccessControlDbContext context, ILogger<AccessGridRepository> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<AccessGrid> AddAsync(AccessGrid entity, CancellationToken cancellationToken = default)
        {
            return await _logger.HandleRepositoryExceptionAsync(async () =>
            {
                await _context.AccessGrids.AddAsync(entity, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return entity;
            }, nameof(AddAsync), entity);
        }

        public async Task DeleteAsync(AccessGrid entity, CancellationToken cancellationToken = default)
        {
            await _logger.HandleRepositoryExceptionAsync(async () =>
            {
                _context.AccessGrids.Remove(entity);
                await _context.SaveChangesAsync(cancellationToken);
            }, nameof(DeleteAsync), entity);
        }

        public async Task<bool> ExistsAsync(int employeeId, int accessGroupId, CancellationToken cancellationToken = default)
        {
            return await _logger.HandleRepositoryExceptionAsync(async () =>
            {
                return await _context.AccessGrids.AnyAsync(x => x.EmployeeId == employeeId && x.AccessGroupId == accessGroupId, cancellationToken);
            }, nameof(ExistsAsync), new {employeeId, accessGroupId});
        }

        public async Task<IEnumerable<AccessGrid>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _logger.HandleRepositoryExceptionAsync(async () =>
            {
                return await _context.AccessGrids
                    .Include(x => x.Employee)
                    .Include(x => x.AccessGroup)
                    .ToListAsync(cancellationToken);
            }, nameof(GetAllAsync));
        }

        public async Task<AccessGrid?> GetByIdAsync(int employeeId, int accessGroupId, CancellationToken cancellationToken = default)
        {
            return await _logger.HandleRepositoryExceptionAsync(async () =>
            {
                return await _context.AccessGrids
                    .Include(x => x.Employee)
                    .Include(x => x.AccessGroup)
                    .FirstOrDefaultAsync(x => x.EmployeeId == employeeId && x.AccessGroupId == accessGroupId, cancellationToken);
            }, nameof(GetByIdAsync), new {employeeId, accessGroupId});
        }

        public async Task<IEnumerable<AccessGrid>> GetByEmployeeIdAsync(int employeeId, CancellationToken cancellationToken = default)
        {
            return await _logger.HandleRepositoryExceptionAsync(async () =>
            {
                return await _context.AccessGrids
                    .Include(x => x.Employee)
                    .Include(x => x.AccessGroup)
                    .Where(x => x.EmployeeId == employeeId)
                    .ToListAsync(cancellationToken);
            }, nameof(GetByEmployeeIdAsync), employeeId);
        }

        public async Task<IEnumerable<AccessGrid>> GetByAccessGroupIdAsync(int accessGroupId, CancellationToken cancellationToken = default)
        {
            return await _logger.HandleRepositoryExceptionAsync(async () =>
            {
                return await _context.AccessGrids
                    .Include(x => x.Employee)
                    .Include(x => x.AccessGroup)
                    .Where(x => x.AccessGroupId == accessGroupId)
                    .ToListAsync(cancellationToken);
            }, nameof(GetByAccessGroupIdAsync), accessGroupId);
        }

        public async Task UpdateAsync(AccessGrid entity, CancellationToken cancellationToken = default)
        {
            await _logger.HandleRepositoryExceptionAsync(async () =>
            {
                _context.AccessGrids.Update(entity);
                await _context.SaveChangesAsync(cancellationToken);
            }, nameof(UpdateAsync), entity);
        }
    }
}