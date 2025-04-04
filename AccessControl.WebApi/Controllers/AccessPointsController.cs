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
    public class AccessPointsController : ControllerBase
    {
        private readonly IAccessPointService _accessPointService;
        private readonly ILogger<AccessPointsController> _logger;

        public AccessPointsController(IAccessPointService accessPointService, ILogger<AccessPointsController> logger)
        {
            _accessPointService = accessPointService;
            _logger = logger;
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
            var accessPoint = await _accessPointService.CreateAsync(request, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id = accessPoint.Id }, Result.Success(accessPoint));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Result>> Update(int id, [FromBody] UpdateAccessPointReq request, CancellationToken cancellationToken = default)
        {
            if (id != request.Id)
            {
                var error = new Error("ID в URL не соответствует ID в теле запроса");
                return BadRequest(Result.Failure(error));
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
    }
} 