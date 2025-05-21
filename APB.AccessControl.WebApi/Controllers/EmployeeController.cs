using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using APB.AccessControl.Application.Services.Interfaces;
using APB.AccessControl.Shared.Models.DTOs;
using APB.AccessControl.Shared.Models.Requests;
using APB.AccessControl.Shared.Models.Responses;
using APB.AccessControl.Shared.Models.Common;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using APB.AccessControl.WebApi.Validators;
using FluentValidation.Results;

namespace APB.AccessControl.WebApi.Controllers
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly ILogger<EmployeeController> _logger;
        private readonly CreateEmployeeReqValidator _createValidator;
        private readonly UpdateEmployeeReqValidator _updateValidator;

        public EmployeeController(
            IEmployeeService employeeService, 
            ILogger<EmployeeController> logger,
            CreateEmployeeReqValidator createValidator,
            UpdateEmployeeReqValidator updateValidator)
        {
            _employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _createValidator = createValidator ?? throw new ArgumentNullException(nameof(createValidator));
            _updateValidator = updateValidator ?? throw new ArgumentNullException(nameof(updateValidator));
        }

        [HttpGet]
        public async Task<ActionResult<Result<IEnumerable<EmployeeDto>>>> GetEmployees(CancellationToken cancellationToken = default)
        {
            var employees = await _employeeService.GetAllAsync(cancellationToken);
            return Ok(Result.Success(employees));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Result<EmployeeDto>>> GetEmployee(int id, CancellationToken cancellationToken = default)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id, cancellationToken);
            return Ok(Result.Success(employee));
        }

        [HttpPost]
        public async Task<ActionResult<Result<EmployeeDto>>> CreateEmployee([FromBody] CreateEmployeeReq request, CancellationToken cancellationToken = default)
        {
            ValidationResult validationResult = await _createValidator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.ConvertAll(error => new Error(error.ErrorMessage));
                return BadRequest(Result.Failure(errors));
            }

            var createdEmployee = await _employeeService.CreateAsync(request, cancellationToken);
            return CreatedAtAction(nameof(GetEmployee), new { id = createdEmployee.Id }, Result.Success(createdEmployee));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Result>> UpdateEmployee(int id, [FromBody] UpdateEmployeeReq request, CancellationToken cancellationToken = default)
        {
            if (id != request.Id)
            {
                var error = new Error("Идентификатор в URL не соответствует идентификатору в теле запроса");
                return BadRequest(Result.Failure([error]));
            }

            ValidationResult validationResult = await _updateValidator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.ConvertAll(error => new Error(error.ErrorMessage));
                return BadRequest(Result.Failure(errors));
            }

            await _employeeService.UpdateAsync(request, cancellationToken);
            return Ok(Result.Success());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Result>> DeleteEmployee(int id, CancellationToken cancellationToken = default)
        {
            await _employeeService.DeleteAsync(id, cancellationToken);
            return Ok(Result.Success());
        }
    }
}
