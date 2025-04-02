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
    public class AccessGroupRepository : IAccessGroupRepository
    {
        private readonly AccessControlDbContext _context;
        private readonly ILogger<AccessGroupRepository> _logger;

        public AccessGroupRepository(AccessControlDbContext context, ILogger<AccessGroupRepository> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<AccessGroup> AddAsync(AccessGroup entity, CancellationToken cancellationToken = default)
        {
            return await _logger.HandleRepositoryExceptionAsync(async () =>
            {
                await _context.AccessGroups.AddAsync(entity, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return entity;
            }, nameof(AddAsync), entity);
        }

        public async Task DeleteAsync(AccessGroup entity, CancellationToken cancellationToken = default)
        {
            await _logger.HandleRepositoryExceptionAsync(async () =>
            {
                _context.AccessGroups.Remove(entity);
                await _context.SaveChangesAsync(cancellationToken);
            }, nameof(DeleteAsync), entity);
        }

        public async Task<bool> ExistsAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _logger.HandleRepositoryExceptionAsync(async () =>
            {
                return await _context.AccessGroups.AnyAsync(g => g.Id == id, cancellationToken);
            }, nameof(ExistsAsync), id);
        }

        public async Task<IEnumerable<AccessGroup>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _logger.HandleRepositoryExceptionAsync(async () =>
            {
                return await _context.AccessGroups.ToListAsync(cancellationToken);
            }, nameof(GetAllAsync));
        }

        public async Task<AccessGroup?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _logger.HandleRepositoryExceptionAsync(async () =>
            {
                return await _context.AccessGroups.FindAsync(new object[] { id }, cancellationToken);
            }, nameof(GetByIdAsync), id);
        }

        public async Task UpdateAsync(AccessGroup entity, CancellationToken cancellationToken = default)
        {
            await _logger.HandleRepositoryExceptionAsync(async () =>
            {
                _context.AccessGroups.Update(entity);
                await _context.SaveChangesAsync(cancellationToken);
            }, nameof(UpdateAsync), entity);
        }
    } 
}