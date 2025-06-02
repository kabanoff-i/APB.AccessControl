using APB.AccessControl.Application.Services.Interfaces;
using APB.AccessControl.Shared.Models.Common;
using APB.AccessControl.Shared.Models.DTOs;
using APB.AccessControl.Shared.Models.Requests;
using APB.AccessControl.Shared.Models.Responses;
using APB.AccessControl.WebApi.Validators;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APB.AccessControl.WebApi.Controllers
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class AccessPointsController : ControllerBase
    {
        private readonly IAccessPointService _accessPointService;
        private readonly ILogger<AccessPointsController> _logger;
        private readonly CreateAccessPointReqValidator _createValidator;
        private readonly UpdateAccessPointReqValidator _updateValidator;
        private readonly HeartbeatReqValidator _heartbeatValidator;

        public AccessPointsController(
            IAccessPointService accessPointService, 
            ILogger<AccessPointsController> logger,
            CreateAccessPointReqValidator createValidator,
            UpdateAccessPointReqValidator updateValidator,
            HeartbeatReqValidator heartbeatValidator)
        {
            _accessPointService = accessPointService ?? throw new ArgumentNullException(nameof(accessPointService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _createValidator = createValidator ?? throw new ArgumentNullException(nameof(createValidator));
            _updateValidator = updateValidator ?? throw new ArgumentNullException(nameof(updateValidator));
            _heartbeatValidator = heartbeatValidator ?? throw new ArgumentNullException(nameof(heartbeatValidator));
        }

        [HttpGet]
        public async Task<ActionResult<Result<IEnumerable<AccessPointDto>>>> GetAll(CancellationToken cancellationToken = default)
        {
            var accessPoints = await _accessPointService.GetAllAsync(cancellationToken);
            return Ok(Result.Success(accessPoints));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Result<AccessPointDto>>> GetById(int id, CancellationToken cancellationToken = default)
        {
            var accessPoint = await _accessPointService.GetByIdAsync(id, cancellationToken);
            return Ok(Result.Success(accessPoint));
        }

        [HttpPost]
        public async Task<ActionResult<Result<AccessPointDto>>> Create([FromBody] CreateAccessPointReq request, CancellationToken cancellationToken = default)
        {
            ValidationResult validationResult = await _createValidator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.ConvertAll(error => new Error(error.ErrorMessage));
                return BadRequest(Result.Failure(errors));
            }

            var accessPoint = await _accessPointService.CreateAsync(request, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id = accessPoint.Id }, Result.Success(accessPoint));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Result>> Update(int id, [FromBody] UpdateAccessPointReq request, CancellationToken cancellationToken = default)
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

            await _accessPointService.UpdateAsync(request, cancellationToken);
            return Ok(Result.Success());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Result>> Delete(int id, CancellationToken cancellationToken = default)
        {
            await _accessPointService.DeleteAsync(id, cancellationToken);
            return Ok(Result.Success(true));
        }
        
        [HttpPost("heartbeat")]
        public async Task<ActionResult<HeartbeatResponse>> UpdateHeartbeat([FromBody] HeartbeatReq request, CancellationToken cancellationToken = default)
        {
            ValidationResult validationResult = await _heartbeatValidator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.ConvertAll(error => new Error(error.ErrorMessage));
                return BadRequest(Result.Failure(errors));
            }

            var result = await _accessPointService.UpdateHeartbeatAsync(request, cancellationToken);
            if (!result.Success)
            {
                var error = new Error($"Точка доступа с ID {request.AccessPointId} не найдена");
                return NotFound(Result.Failure([error]));
            }
            
            return Ok(Result.Success(result));
        }
    }
} 