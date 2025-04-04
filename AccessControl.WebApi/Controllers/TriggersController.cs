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
    public class TriggersController : ControllerBase
    {
        private readonly ITriggerService _triggerService;
        private readonly ILogger<TriggersController> _logger;

        public TriggersController(ITriggerService triggerService, ILogger<TriggersController> logger)
        {
            _triggerService = triggerService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<Result<IEnumerable<TriggerDto>>>> GetAll(CancellationToken cancellationToken = default)
        {
            var triggers = await _triggerService.GetAllAsync(cancellationToken);
            return Ok(Result.Success(triggers));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Result<TriggerDto>>> GetById(int id, CancellationToken cancellationToken = default)
        {
            var trigger = await _triggerService.GetByIdAsync(id, cancellationToken);
            return Ok(Result.Success(trigger));
        }

        [HttpPost]
        public async Task<ActionResult<Result<TriggerDto>>> Create([FromBody] CreateTriggerReq request, CancellationToken cancellationToken = default)
        {
            var trigger = await _triggerService.CreateAsync(request, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id = trigger.Id }, Result.Success(trigger));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Result>> Update(int id, [FromBody] UpdateTriggerReq request, CancellationToken cancellationToken = default)
        {
            if (id != request.Id)
            {
                var error = new Error("ID в URL не соответствует ID в теле запроса");
                return BadRequest(Result.Failure(error));
            }

            await _triggerService.UpdateAsync(request, cancellationToken);
            return Ok(Result.Success());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Result>> Delete(int id, CancellationToken cancellationToken = default)
        {
            await _triggerService.DeleteAsync(id, cancellationToken);
            return Ok(Result.Success());
        }
    }
} 