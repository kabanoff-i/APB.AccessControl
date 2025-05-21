using APB.AccessControl.Application.Services.Interfaces;
using APB.AccessControl.Shared.Models.Common;
using APB.AccessControl.Shared.Models.DTOs;
using APB.AccessControl.Shared.Models.Requests;
using APB.AccessControl.WebApi.Validators;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace APB.AccessControl.WebApi.Controllers
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class CardsController : ControllerBase
    {
        private readonly ICardService _cardService;
        private readonly ILogger<CardsController> _logger;
        private readonly CreateCardReqValidator _createValidator;
        private readonly UpdateCardReqValidator _updateValidator;

        public CardsController(
            ICardService cardService, 
            ILogger<CardsController> logger,
            CreateCardReqValidator createValidator,
            UpdateCardReqValidator updateValidator)
        {
            _cardService = cardService ?? throw new ArgumentNullException(nameof(cardService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _createValidator = createValidator ?? throw new ArgumentNullException(nameof(createValidator));
            _updateValidator = updateValidator ?? throw new ArgumentNullException(nameof(updateValidator));
        }

        [HttpGet]
        public async Task<ActionResult<Result<IEnumerable<CardDto>>>> GetAll(CancellationToken cancellationToken = default)
        {
            var cards = await _cardService.GetAllAsync(cancellationToken);
            return Ok(Result.Success(cards));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Result<CardDto>>> GetById(int id, CancellationToken cancellationToken = default)
        {
            var card = await _cardService.GetByIdAsync(id, cancellationToken);
            return Ok(Result.Success(card));
        }

        [HttpGet("employee/{employeeId}")]
        public async Task<ActionResult<Result<IEnumerable<CardDto>>>> GetByEmployeeId(int employeeId, CancellationToken cancellationToken = default)
        {
            var cards = await _cardService.GetByEmployeeIdAsync(employeeId, cancellationToken);
            return Ok(Result.Success(cards));
        }

        [HttpGet("hash/{cardHash}")]
        public async Task<ActionResult<Result<CardDto>>> GetByCardHash(string cardHash, CancellationToken cancellationToken = default)
        {
            var card = await _cardService.GetByHashAsync(cardHash, cancellationToken);
            return Ok(Result.Success(card));
        }

        [HttpPost]
        public async Task<ActionResult<Result<CardDto>>> Create([FromBody] CreateCardReq request, CancellationToken cancellationToken = default)
        {
            ValidationResult validationResult = await _createValidator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.ConvertAll(error => new Error(error.ErrorMessage));
                return BadRequest(Result.Failure(errors));
            }

            var card = await _cardService.CreateAsync(request, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id = card.Id }, Result.Success(card));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Result<CardDto>>> Update(int id, [FromBody] UpdateCardReq request, CancellationToken cancellationToken = default)
        {
            if (id != request.Id)
            {
                var error = new Error("ID в URL не соответствует ID в теле запроса");
                return BadRequest(Result.Failure([error]));
            }

            ValidationResult validationResult = await _updateValidator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.ConvertAll(error => new Error(error.ErrorMessage));
                return BadRequest(Result.Failure(errors));
            }

            await _cardService.UpdateAsync(request, cancellationToken);
            var updatedCard = await _cardService.GetByIdAsync(id, cancellationToken);
            return Ok(Result.Success(updatedCard));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Result>> Delete(int id, CancellationToken cancellationToken = default)
        {
            await _cardService.DeleteAsync(id, cancellationToken);
            return Ok(Result.Success());
        }
    }
} 