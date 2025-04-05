using APB.AccessControl.Application.Services.Interfaces;
using APB.AccessControl.Domain.Entities;
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
    public class AccessGroupsController : ControllerBase
    {
        private readonly IAccessGroupService _accessGroupService;
        private readonly ILogger<AccessGroupsController> _logger;

        public AccessGroupsController(IAccessGroupService accessGroupService, ILogger<AccessGroupsController> logger)
        {
            _accessGroupService = accessGroupService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<Result<IEnumerable<AccessGroupDto>>>> GetAll(CancellationToken cancellationToken = default)
        {
            var accessGroups = await _accessGroupService.GetAllAsync(cancellationToken);
            return Ok(Result.Success(accessGroups));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Result<AccessGroupDto>>> GetById(int id, CancellationToken cancellationToken = default)
        {
            var accessGroup = await _accessGroupService.GetByIdAsync(id, cancellationToken);
            return Ok(Result.Success(accessGroup));
        }

        [HttpGet("{groupId}/employees")]
        public async Task<ActionResult<Result<IEnumerable<EmployeeDto>>>> GetEmployeesInGroup(int groupId, CancellationToken cancellationToken = default)
        {
            var employees = await _accessGroupService.GetEmployeesInGroupAsync(groupId, cancellationToken);
            return Ok(Result.Success(employees));
        }

        [HttpGet("employee/{employeeId}")]
        public async Task<ActionResult<Result<IEnumerable<AccessGroupDto>>>> GetGroupsByEmployeeId(int employeeId, CancellationToken cancellationToken = default)
        {
            var groupIds = await _accessGroupService.GetByEmployeeIdAsync(employeeId, cancellationToken);
            return Ok(Result.Success(groupIds));
        }

        [HttpPost]
        public async Task<ActionResult<Result<AccessGroupDto>>> Create([FromBody] CreateGroupReq request, CancellationToken cancellationToken = default)
        {
            var accessGroup = await _accessGroupService.CreateAsync(request, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id = accessGroup.Id }, Result.Success(accessGroup));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Result>> Update(int id, [FromBody] UpdateGroupReq request, CancellationToken cancellationToken = default)
        {
            if (id != request.Id)
            {
                var error = new Error("ID в URL не соответствует ID в теле запроса");
                return BadRequest(Result.Failure(error));
            }

            await _accessGroupService.UpdateAsync(request, cancellationToken);
            return Ok(Result.Success());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Result>> Delete(int id, CancellationToken cancellationToken = default)
        {
            await _accessGroupService.DeleteAsync(id, cancellationToken);
            return Ok(Result.Success());
        }

        [HttpPost("{AccessGroupId}/employees/{EmployeeId}")]
        public async Task<ActionResult<Result>> AddEmployeeToGroup(int AccessGroupId, int EmployeeId, CancellationToken cancellationToken = default)
        {
            var request = new AddEmployeeToGroupReq
            {
                AccessGroupId = AccessGroupId,
                EmployeeId = EmployeeId
            };

            await _accessGroupService.AddEmployeeToGroupAsync(request, cancellationToken);
            return Ok(Result.Success());
        }

        [HttpDelete("{AccessGroupId}/employees/{EmployeeId}")]
        public async Task<ActionResult<Result>> RemoveEmployeeFromGroup(int AccessGroupId, int EmployeeId, CancellationToken cancellationToken = default)
        {
            var request = new RemoveEmployeeFromGroupReq
            {
                AccessGroupId = AccessGroupId,
                EmployeeId = EmployeeId
            };

            await _accessGroupService.RemoveEmployeeFromGroupAsync(request, cancellationToken);
            return Ok(Result.Success());
        }
    }
} 