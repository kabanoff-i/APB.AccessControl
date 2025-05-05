using APB.AccessControl.Application.Filters;
using APB.AccessControl.Application.Services.Interfaces;
using APB.AccessControl.Shared.Models.Common;
using APB.AccessControl.Shared.Models.DTOs;
using APB.AccessControl.Shared.Models.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace APB.AccessControl.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AccessLogsController : ControllerBase
    {
        private readonly IAccessLogService _accessLogService;
        private readonly ILogger<AccessLogsController> _logger;

        public AccessLogsController(IAccessLogService accessLogService, ILogger<AccessLogsController> logger)
        {
            _accessLogService = accessLogService;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Result<AccessLogDto>>> GetById(Guid id, CancellationToken cancellationToken = default)
        {
            var log = await _accessLogService.GetByIdAsync(id, cancellationToken);
            return Ok(Result.Success(log));
        }

        [HttpPost("filter")]
        public async Task<ActionResult<Result<IEnumerable<AccessLogDto>>>> GetByFilter([FromBody] AccessLogFilter filter, CancellationToken cancellationToken = default)
        {
            var logs = await _accessLogService.GetLogsByFilterAsync(filter, cancellationToken);
            return Ok(Result.Success(logs));
        }

        [HttpPost]
        public async Task<ActionResult<Result<AccessLogDto>>> Create([FromBody] CreateAccessLogReq request, CancellationToken cancellationToken = default)
        {
            var log = await _accessLogService.LogAccessAttemptAsync(request, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id = log.Id }, Result.Success(log));
        }
    }
} 