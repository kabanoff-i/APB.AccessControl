using APB.AccessControl.Application.Services.Interfaces;
using APB.AccessControl.Shared.Models.Common;
using APB.AccessControl.Shared.Models.DTOs;
using APB.AccessControl.Shared.Models.Requests;
using APB.AccessControl.WebApi.Validators;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APB.AccessControl.WebApi.Controllers
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class AccessRulesController : ControllerBase
    {
        private readonly IAccessRuleService _accessRuleService;
        private readonly ILogger<AccessRulesController> _logger;
        private readonly CreateAccessRuleReqValidator _createValidator;
        private readonly UpdateAccessRuleReqValidator _updateValidator;
        private readonly HeartbeatReqValidator _heartbeatValidator;

        public AccessRulesController(
            IAccessRuleService accessRuleService, 
            ILogger<AccessRulesController> logger,
            CreateAccessRuleReqValidator createValidator,
            UpdateAccessRuleReqValidator updateValidator,
            HeartbeatReqValidator heartbeatValidator)
        {
            _accessRuleService = accessRuleService ?? throw new ArgumentNullException(nameof(accessRuleService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _createValidator = createValidator ?? throw new ArgumentNullException(nameof(createValidator));
            _updateValidator = updateValidator ?? throw new ArgumentNullException(nameof(updateValidator));
            _heartbeatValidator = heartbeatValidator ?? throw new ArgumentNullException(nameof(heartbeatValidator));
        }

        [HttpGet]
        public async Task<ActionResult<Result<IEnumerable<AccessRuleDto>>>> GetAll(CancellationToken cancellationToken = default)
        {
            var accessRules = await _accessRuleService.GetAllAsync(cancellationToken);
            return Ok(Result.Success(accessRules));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Result<AccessRuleDto>>> GetById(int id, CancellationToken cancellationToken = default)
        {
            var accessRule = await _accessRuleService.GetByIdAsync(id, cancellationToken);
            return Ok(Result.Success(accessRule));
        }

        [HttpPost]
        public async Task<ActionResult<Result<AccessRuleDto>>> Create([FromBody] CreateAccessRuleReq request, CancellationToken cancellationToken = default)
        {
            ValidationResult validationResult = await _createValidator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.ConvertAll(error => new Error(error.ErrorMessage));
                return BadRequest(Result.Failure(errors));
            }

            var accessRule = await _accessRuleService.CreateAsync(request, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id = accessRule.Id }, Result.Success(accessRule));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Result>> Update(int id, [FromBody] UpdateAccessRuleReq request, CancellationToken cancellationToken = default)
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

            await _accessRuleService.UpdateAsync(request, cancellationToken);
            return Ok(Result.Success());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Result>> Delete(int id, CancellationToken cancellationToken = default)
        {
            await _accessRuleService.DeleteAsync(id, cancellationToken);
            return Ok(Result.Success());
        }
    }
} 