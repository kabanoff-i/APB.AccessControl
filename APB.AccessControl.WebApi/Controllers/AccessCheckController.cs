using APB.AccessControl.Application.Services.Interfaces;
using APB.AccessControl.Shared.Models.Common;
using APB.AccessControl.Shared.Models.Requests;
using APB.AccessControl.Shared.Models.Responses;
using APB.AccessControl.WebApi.Validators;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace APB.AccessControl.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AccessCheckController : ControllerBase
    {
        private readonly IAccessCheckService _accessCheckService;
        private readonly CheckAccessReqValidator _validator;
        private readonly ILogger<AccessCheckController> _logger;

        public AccessCheckController(
            IAccessCheckService accessCheckService,
            CheckAccessReqValidator validator,
            ILogger<AccessCheckController> logger)
        {
            _accessCheckService = accessCheckService ?? throw new ArgumentNullException(nameof(accessCheckService));
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpPost("check")]
        public async Task<ActionResult<Result<AccessCheckResponse>>> CheckAccess([FromBody] CheckAccessReq request, CancellationToken cancellationToken = default)
        {
            ValidationResult validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.ConvertAll(error => new Error(error.ErrorMessage));
                return BadRequest(Result.Failure(errors));
            }

            var result = await _accessCheckService.CheckAccessAsync(request, cancellationToken);
            return Ok(Result.Success(result));
        }
    }
} 