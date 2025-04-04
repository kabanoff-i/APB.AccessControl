using APB.AccessControl.Application.Services.Interfaces;
using APB.AccessControl.Shared.Models.Common;
using APB.AccessControl.Shared.Models.DTOs;
using APB.AccessControl.Shared.Models.Requests;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AccessControl.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccessRulesController : ControllerBase
    {
        private readonly IAccessRuleService _accessRuleService;
        private readonly ILogger<AccessRulesController> _logger;

        public AccessRulesController(IAccessRuleService accessRuleService, ILogger<AccessRulesController> logger)
        {
            _accessRuleService = accessRuleService;
            _logger = logger;
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
            var accessRule = await _accessRuleService.CreateAsync(request, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id = accessRule.Id }, Result.Success(accessRule));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Result>> Update(int id, [FromBody] UpdateAccessRuleReq request, CancellationToken cancellationToken = default)
        {
            if (id != request.Id)
            {
                var error = new Error("ID в URL не соответствует ID в теле запроса");
                return BadRequest(Result.Failure(error));
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