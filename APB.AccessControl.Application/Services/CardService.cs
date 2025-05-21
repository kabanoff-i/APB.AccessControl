using APB.AccessControl.Application.Interfaces;
using APB.AccessControl.Application.Services.Interfaces;
using APB.AccessControl.Shared.Models.DTOs;
using APB.AccessControl.Shared.Models.Requests;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System;
using APB.AccessControl.Domain.Entities;
using System.Net;
using AutoMapper;
using APB.AccessControl.Domain.Exceptions;
using System.Net.Http.Headers;
using Microsoft.Extensions.Logging;
using APB.AccessControl.Application.Common;
using FluentValidation;
using APB.AccessControl.Application.Validators;

namespace APB.AccessControl.Application.Services
{
    public class CardService: ICardService
    {
        private readonly ICardRepository _cardRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CardService> _logger;
        private readonly CardValidator _cardValidator;

        public CardService(
            ICardRepository cardRepository,
            IMapper mapper,
            ILogger<CardService> logger,
            CardValidator cardValidator)
        {
            _cardRepository = cardRepository
                ?? throw new ArgumentNullException(nameof(cardRepository));
            _mapper = mapper
                ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger
                ?? throw new ArgumentNullException(nameof(logger));
            _cardValidator = cardValidator
                ?? throw new ArgumentNullException(nameof(cardValidator));
        }

        public async Task<CardDto> CreateAsync(CreateCardReq request, CancellationToken cancellationToken = default)
        {
            return await _logger.HandleOperationAsync(async () =>
            {
                var existingCard = await _cardRepository.GetByHashAsync(request.Hash, cancellationToken);

                if (existingCard != null)
                    throw new AlreadyExistsException(nameof(Card), nameof(Card.Hash), request.Hash);

                var repReq = _mapper.Map<Card>(request);
                await _cardValidator.ValidateAndThrowAsync(repReq);

                var repResponse = await _cardRepository.AddAsync(repReq, cancellationToken);
                return _mapper.Map<CardDto>(repResponse);
            }, nameof(CreateAsync));
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            await _logger.HandleOperationAsync(async () =>
            {
                var card = await _cardRepository.GetByIdAsync(id, cancellationToken) 
                    ?? throw new NotFoundException(nameof(Card), nameof(Card.Id), id);

                await _cardRepository.DeleteAsync(card, cancellationToken);
            }, nameof(DeleteAsync));
        }

        public async Task<IEnumerable<CardDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _logger.HandleOperationAsync(async () =>
            {
                var repResponse = await _cardRepository.GetAllAsync(cancellationToken);
                return _mapper.Map<IEnumerable<CardDto>>(repResponse);
            }, nameof(GetAllAsync));
        }

        public async Task<CardDto> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _logger.HandleOperationAsync(async () =>
            {
                var repResponse = await _cardRepository.GetByIdAsync(id, cancellationToken)
                    ?? throw new NotFoundException(nameof(Card), nameof(Card.Id), id);

                return _mapper.Map<CardDto>(repResponse);
            }, nameof(GetByIdAsync));
        }

        public async Task UpdateAsync(UpdateCardReq request, CancellationToken cancellationToken = default)
        {
            await _logger.HandleOperationAsync(async () =>
            {
                var repReq = await _cardRepository.GetByIdAsync(request.Id, cancellationToken)
                    ?? throw new NotFoundException(nameof(Card));

                _mapper.Map(request, repReq);
                await _cardValidator.ValidateAndThrowAsync(repReq);

                await _cardRepository.UpdateAsync(repReq, cancellationToken);
            }, nameof(UpdateAsync));
        }

        public async Task<CardDto> GetByHashAsync(string hash, CancellationToken cancellationToken = default)
        {
            return await _logger.HandleOperationAsync(async () =>
            {
                var repResponse = await _cardRepository.GetByHashAsync(hash, cancellationToken)
                    ?? throw new NotFoundException(nameof(Card), "Hash", hash);

                return _mapper.Map<CardDto>(repResponse);
            }, nameof(GetByHashAsync));
        }

        public async Task<IEnumerable<CardDto>> GetByEmployeeIdAsync(int employeeId, CancellationToken cancellationToken = default)
        {
            return await _logger.HandleOperationAsync(async () =>
            {
                var repRes = await _cardRepository.GetAllByEmployeeIdAsync(employeeId, cancellationToken)
                    ?? throw new NotFoundException(nameof(Card), nameof(Card.EmployeeId), employeeId);

                var response = _mapper.Map<IEnumerable<CardDto>>(repRes);

                return response;
            }, nameof(GetByEmployeeIdAsync));
        }
    }
}
