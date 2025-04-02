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
    public class CardRepository : ICardRepository
    {
        private readonly AccessControlDbContext _context;
        private readonly ILogger<CardRepository> _logger;

        public CardRepository(AccessControlDbContext context, ILogger<CardRepository> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Card?> GetByHashAsync(string cardHash, CancellationToken cancellationToken = default)
        {
            return await _logger.HandleRepositoryExceptionAsync(async () =>
            {
                return await _context.Cards
                    .FirstOrDefaultAsync(c => c.Hash == cardHash, cancellationToken);
            }, nameof(GetByHashAsync), cardHash);
        }

        public async Task<Card?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _logger.HandleRepositoryExceptionAsync(async () =>
            {
                return await _context.Cards
                    .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
            }, nameof(GetByIdAsync), id);
        }

        public async Task<IEnumerable<Card>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _logger.HandleRepositoryExceptionAsync(async () =>
            {
                return await _context.Cards.ToListAsync(cancellationToken);
            }, nameof(GetAllAsync));
        }

        public async Task<Card?> AddAsync(Card entity, CancellationToken cancellationToken = default)
        {
            return await _logger.HandleRepositoryExceptionAsync(async () =>
            {
                await _context.Cards.AddAsync(entity, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return entity;
            }, nameof(AddAsync), entity);
        }

        public async Task UpdateAsync(Card entity, CancellationToken cancellationToken = default)
        {
            await _logger.HandleRepositoryExceptionAsync(async () =>
            {
                _context.Cards.Update(entity);
                await _context.SaveChangesAsync(cancellationToken);
            }, nameof(UpdateAsync), entity);
        }

        public async Task DeleteAsync(Card entity, CancellationToken cancellationToken = default)
        {
            await _logger.HandleRepositoryExceptionAsync(async () =>
            {
                _context.Cards.Remove(entity);
                await _context.SaveChangesAsync(cancellationToken);
            }, nameof(DeleteAsync), entity);
        }

        public async Task<bool> ExistsAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _logger.HandleRepositoryExceptionAsync(async () =>
            {
                return await _context.Cards.AnyAsync(c => c.Id == id, cancellationToken);
            }, nameof(ExistsAsync), id);
        }

        public async Task<IEnumerable<Card>> GetAllByEmployeeIdAsync(int employeeId, CancellationToken cancellationToken = default)
        {
            return await _logger.HandleRepositoryExceptionAsync(async () =>
            {
                return await _context.Cards
                    .Where(c => c.EmployeeId == employeeId)
                    .ToListAsync(cancellationToken);
            }, nameof(GetAllByEmployeeIdAsync), employeeId);
        }
    }
}