using APB.AccessControl.Application.Services.Interfaces;
using APB.AccessControl.Shared.Models.Common;
using APB.AccessControl.Shared.Models.DTOs;
using APB.AccessControl.Shared.Models.Filters;
using APB.AccessControl.Shared.Models.Requests;
using APB.AccessControl.WebApi.Validators;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APB.AccessControl.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AccessLogsController : ControllerBase
    {
        private readonly IAccessLogService _accessLogService;
        private readonly ILogger<AccessLogsController> _logger;
        private readonly CreateAccessLogReqValidator _createValidator;

        public AccessLogsController(
            IAccessLogService accessLogService, 
            ILogger<AccessLogsController> logger,
            CreateAccessLogReqValidator createValidator)
        {
            _accessLogService = accessLogService ?? throw new ArgumentNullException(nameof(accessLogService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _createValidator = createValidator ?? throw new ArgumentNullException(nameof(createValidator));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Result<AccessLogDto>>> GetById(Guid id, CancellationToken cancellationToken = default)
        {
            var log = await _accessLogService.GetByIdAsync(id, cancellationToken);
            return Ok(Result.Success(log));
        }

        [HttpPost("filter")]
        public async Task<ActionResult<Result<IEnumerable<AccessLogDto>>>> GetByFilter([FromBody] AccessLogFilterDto filter, CancellationToken cancellationToken = default)
        {
            var logs = await _accessLogService.GetLogsByFilterAsync(filter, cancellationToken);
            return Ok(Result.Success(logs));
        }

        [HttpPost]
        public async Task<ActionResult<Result<AccessLogDto>>> Create([FromBody] CreateAccessLogReq request, CancellationToken cancellationToken = default)
        {
            ValidationResult validationResult = await _createValidator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.ConvertAll(error => new Error(error.ErrorMessage));
                return BadRequest(Result.Failure(errors));
            }

            var log = await _accessLogService.LogAccessAttemptAsync(request, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id = log.Id }, Result.Success(log));
        }
    }
} 