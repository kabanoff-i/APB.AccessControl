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
    public class AccessGroupsController : ControllerBase
    {
        private readonly IAccessGroupService _accessGroupService;
        private readonly ILogger<AccessGroupsController> _logger;
        private readonly CreateGroupReqValidator _createValidator;
        private readonly UpdateGroupReqValidator _updateValidator;
        private readonly AddEmployeeToGroupReqValidator _addEmployeeValidator;
        private readonly RemoveEmployeeFromGroupReqValidator _removeEmployeeValidator;

        public AccessGroupsController(
            IAccessGroupService accessGroupService, 
            ILogger<AccessGroupsController> logger,
            CreateGroupReqValidator createValidator,
            UpdateGroupReqValidator updateValidator,
            AddEmployeeToGroupReqValidator addEmployeeValidator,
            RemoveEmployeeFromGroupReqValidator removeEmployeeValidator)
        {
            _accessGroupService = accessGroupService ?? throw new ArgumentNullException(nameof(accessGroupService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _createValidator = createValidator ?? throw new ArgumentNullException(nameof(createValidator));
            _updateValidator = updateValidator ?? throw new ArgumentNullException(nameof(updateValidator));
            _addEmployeeValidator = addEmployeeValidator ?? throw new ArgumentNullException(nameof(addEmployeeValidator));
            _removeEmployeeValidator = removeEmployeeValidator ?? throw new ArgumentNullException(nameof(removeEmployeeValidator));
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
            ValidationResult validationResult = await _createValidator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.ConvertAll(error => new Error(error.ErrorMessage));
                return BadRequest(Result.Failure(errors));
            }

            var accessGroup = await _accessGroupService.CreateAsync(request, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id = accessGroup.Id }, Result.Success(accessGroup));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Result>> Update(int id, [FromBody] UpdateGroupReq request, CancellationToken cancellationToken = default)
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

            ValidationResult validationResult = await _addEmployeeValidator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.ConvertAll(error => new Error(error.ErrorMessage));
                return BadRequest(Result.Failure(errors));
            }

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

            ValidationResult validationResult = await _removeEmployeeValidator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.ConvertAll(error => new Error(error.ErrorMessage));
                return BadRequest(Result.Failure(errors));
            }

            await _accessGroupService.RemoveEmployeeFromGroupAsync(request, cancellationToken);
            return Ok(Result.Success());
        }
    }
} 