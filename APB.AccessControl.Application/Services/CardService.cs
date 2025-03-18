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

namespace APB.AccessControl.Application.Services
{
    public class CardService: ICardService
    {
        private readonly ICardRepository _cardRepository;
        private readonly IMapper _mapper;

        public CardService(ICardRepository cardRepository, IMapper mapper)
        {
            _cardRepository = cardRepository;
            _mapper = mapper;
        }

        public async Task<CardDto> CreateAsync(CreateCardReq request, CancellationToken cancellationToken = default)
        {
            try
            {
                var repReq = _mapper.Map<Card>(request);

                var repRes = await _cardRepository.AddAsync(repReq, cancellationToken);
                var response = _mapper.Map<CardDto>(repRes);

                return response;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            try
            {
                //check for already existing
                if (!await _cardRepository.ExistsAsync(id, cancellationToken))
                    throw new NotFoundException(nameof(Card), nameof(Card.Id), id);

                await _cardRepository.DeleteAsync(id, cancellationToken);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<CardDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var repRes = await _cardRepository.GetAllAsync(cancellationToken);
                var response = _mapper.Map<IEnumerable<CardDto>>(repRes);

                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<CardDto>> GetCardsByEmployeeAsync(int employeeId, CancellationToken cancellationToken = default)
        {
            try
            {
                var repRes = await _cardRepository.GetAllByEmployeeId(employeeId, cancellationToken)
                    ?? throw new NotFoundException(nameof(Card), nameof(Card.EmployeeId), employeeId);

                var response = _mapper.Map<IEnumerable<CardDto>>(repRes);

                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task UpdateAsync(UpdateCardReq request, CancellationToken cancellationToken = default)
        {
            try
            {
                if (!await _cardRepository.ExistsAsync(request.Id, cancellationToken))
                    throw new NotFoundException(nameof(Card), nameof(Card.Id), request.Id);

                var repReq = _mapper.Map<Card>(request);
                await _cardRepository.UpdateAsync(repReq, cancellationToken);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
