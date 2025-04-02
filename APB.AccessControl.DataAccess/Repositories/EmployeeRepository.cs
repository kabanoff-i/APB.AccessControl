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
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AccessControlDbContext _context;
        private readonly ILogger<EmployeeRepository> _logger;

        public EmployeeRepository(AccessControlDbContext context, ILogger<EmployeeRepository> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Employee?> GetByCardIdAsync(int cardId, CancellationToken cancellationToken = default)
        {
            return await _logger.HandleRepositoryExceptionAsync(async () => 
            {
                return await _context.Employees
                    .FirstOrDefaultAsync(e => e.Cards.Any(c => c.Id == cardId), cancellationToken);
            }, nameof(GetByCardIdAsync), cardId);
        }

        public async Task<IEnumerable<Employee>> GetByFilterAsync(IFilter<Employee> filter, CancellationToken cancellationToken = default)
        {
            return await _logger.HandleRepositoryExceptionAsync(async () => 
            {
                var query = _context.Employees.AsQueryable();
                query = query.Where(filter.GetExpression());
                return await query.ToListAsync(cancellationToken);
            }, nameof(GetByFilterAsync), filter);
        }

        public async Task<Employee?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _logger.HandleRepositoryExceptionAsync(async () => 
            {
                return await _context.Employees
                    .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
            }, nameof(GetByIdAsync), id);
        }

        public async Task<IEnumerable<Employee>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _logger.HandleRepositoryExceptionAsync(async () => 
            {
                return await _context.Employees.ToListAsync(cancellationToken);
            }, nameof(GetAllAsync));
        }

        public async Task<Employee?> AddAsync(Employee entity, CancellationToken cancellationToken = default)
        {
            return await _logger.HandleRepositoryExceptionAsync(async () => 
            {
                await _context.Employees.AddAsync(entity, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return entity;
            }, nameof(AddAsync), entity);
        }

        public async Task UpdateAsync(Employee entity, CancellationToken cancellationToken = default)
        {
            await _logger.HandleRepositoryExceptionAsync(async () => 
            {
                _context.Employees.Update(entity);
                await _context.SaveChangesAsync(cancellationToken);
            }, nameof(UpdateAsync), entity);
        }

        public async Task DeleteAsync(Employee entity, CancellationToken cancellationToken = default)
        {
            await _logger.HandleRepositoryExceptionAsync(async () => 
            {
                _context.Employees.Remove(entity);
                await _context.SaveChangesAsync(cancellationToken);
            }, nameof(DeleteAsync), entity);
        }

        public async Task<bool> ExistsAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _logger.HandleRepositoryExceptionAsync(async () => 
            {
                return await _context.Employees.AnyAsync(e => e.Id == id, cancellationToken);
            }, nameof(ExistsAsync), id);
        }
    }
}