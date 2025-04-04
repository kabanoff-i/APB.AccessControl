using APB.AccessControl.Application.Services.Interfaces;
using APB.AccessControl.Shared.Models.Common;
using APB.AccessControl.Shared.Models.Requests;
using APB.AccessControl.Shared.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace AccessControl.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccessCheckController : ControllerBase
    {
        private readonly IAccessCheckService _accessCheckService;

        public AccessCheckController(IAccessCheckService accessCheckService)
        {
            _accessCheckService = accessCheckService;
        }

        [HttpPost("check")]
        public async Task<ActionResult<Result<AccessCheckResponse>>> CheckAccess([FromBody] CheckAccessReq request, CancellationToken cancellationToken = default)
        {
            var result = await _accessCheckService.CheckAccessAsync(request, cancellationToken);
            return Ok(Result.Success(result));
        }
    }
} 