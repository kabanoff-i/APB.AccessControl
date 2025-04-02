using APB.AccessControl.Domain.Abstractions;
using APB.AccessControl.Domain.Entities; 
using Microsoft.EntityFrameworkCore;
using APB.AccessControl.Domain.Exceptions;
using APB.AccessControl.Application.Interfaces;
using APB.AccessControl.Shared.Models.Common;
using APB.AccessControl.Application.Filters;
using Microsoft.Extensions.Logging;
using static APB.AccessControl.Application.Common.Extensions;

namespace APB.AccessControl.DataAccess.Repositories
{
    public class AccessLogRepository : IAccessLogRepository
    {
        private readonly AccessControlDbContext _context;
        private readonly ILogger<AccessLogRepository> _logger;

        public AccessLogRepository(AccessControlDbContext context, ILogger<AccessLogRepository> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<AccessLog>> GetByEmployeeIdAsync(int employeeId, CancellationToken cancellationToken = default)
        {
            return await _logger.HandleRepositoryExceptionAsync(async () =>
            {
                return await _context.AccessLogs
                    .Where(al => al.EmployeeId == employeeId)
                    .Include(al => al.AccessPoint)
                    .Include(al => al.Card)
                    .OrderByDescending(al => al.DateAccess)
                    .ToListAsync(cancellationToken);
            }, nameof(GetByEmployeeIdAsync), employeeId);
        }

        public async Task<IEnumerable<AccessLog>> GetByAccessPointIdAsync(int accessPointId, CancellationToken cancellationToken = default)
        {
            return await _logger.HandleRepositoryExceptionAsync(async () =>
            {
                return await _context.AccessLogs
                    .Where(al => al.AccessPointId == accessPointId)
                    .Include(al => al.Employee)
                    .Include(al => al.Card)
                    .OrderByDescending(al => al.DateAccess)
                    .ToListAsync(cancellationToken);
            }, nameof(GetByAccessPointIdAsync), accessPointId);
        }

        public async Task<IEnumerable<AccessLog>> GetByFilterAsync(IFilter<AccessLog> filter, CancellationToken cancellationToken = default)
        {
            return await _logger.HandleRepositoryExceptionAsync(async () =>
            {
                var query = _context.AccessLogs.AsQueryable();

                query = query.Where(filter.GetExpression());

                query = query.Include(al => al.Employee)
                           .Include(al => al.Card)
                           .Include(al => al.AccessPoint)
                           .OrderByDescending(al => al.DateAccess);

                return await query.ToListAsync(cancellationToken);
            }, nameof(GetByFilterAsync), filter);
        }

        public async Task<AccessLog?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _logger.HandleRepositoryExceptionAsync(async () =>
            {
                return await _context.AccessLogs
                    .Include(al => al.Employee)
                    .Include(al => al.Card)
                    .Include(al => al.AccessPoint)
                    .FirstOrDefaultAsync(al => al.Id == id, cancellationToken);
            }, nameof(GetByIdAsync), id);
        }

        public async Task<IEnumerable<AccessLog>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _logger.HandleRepositoryExceptionAsync(async () =>
            {
                return await _context.AccessLogs
                    .Include(al => al.Employee)
                    .Include(al => al.Card)
                    .Include(al => al.AccessPoint)
                    .OrderByDescending(al => al.DateAccess)
                    .ToListAsync(cancellationToken);
            }, nameof(GetAllAsync));
        }

        public async Task<AccessLog?> AddAsync(AccessLog entity, CancellationToken cancellationToken = default)
        {
            return await _logger.HandleRepositoryExceptionAsync(async () =>
            {
                await _context.AccessLogs.AddAsync(entity, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return entity;
            }, nameof(AddAsync), entity);
        }

        public async Task UpdateAsync(AccessLog entity, CancellationToken cancellationToken = default)
        {
            await _logger.HandleRepositoryExceptionAsync(async () =>
            {
                _context.AccessLogs.Update(entity);
                await _context.SaveChangesAsync(cancellationToken);
            }, nameof(UpdateAsync), entity);
        }

        public async Task DeleteAsync(AccessLog entity, CancellationToken cancellationToken = default)
        {
            await _logger.HandleRepositoryExceptionAsync(async () =>
            {
                _context.AccessLogs.Remove(entity);
                await _context.SaveChangesAsync(cancellationToken);
            }, nameof(DeleteAsync), entity);
        }

        public async Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _logger.HandleRepositoryExceptionAsync(async () =>
            {
                return await _context.AccessLogs.AnyAsync(al => al.Id == id, cancellationToken);
            }, nameof(ExistsAsync), id);
        }
    }
}