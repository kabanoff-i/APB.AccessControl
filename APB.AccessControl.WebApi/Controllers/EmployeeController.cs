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


namespace APB.AccessControl.WebApi.Controllers
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(IEmployeeService employeeService, ILogger<EmployeeController> logger)
        {
            _employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
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
            var createdEmployee = await _employeeService.CreateAsync(request, cancellationToken);
            return CreatedAtAction(nameof(GetEmployee), new { id = createdEmployee.Id }, Result.Success(createdEmployee));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Result>> UpdateEmployee(int id, [FromBody] UpdateEmployeeReq request, CancellationToken cancellationToken = default)
        {
            if (id != request.Id)
            {
                var error = new Error("Идентификатор в URL не соответствует идентификатору в теле запроса");
                return BadRequest(Result.Failure(error));
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
