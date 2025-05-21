using APB.AccessControl.Application.Services.Interfaces;
using APB.AccessControl.Shared.Models.Common;
using APB.AccessControl.Shared.Models.DTOs;
using APB.AccessControl.Shared.Models.Requests;
using APB.AccessControl.WebApi.Validators;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace APB.AccessControl.WebApi.Controllers
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        private readonly ILogger<NotificationsController> _logger;
        private readonly CreateNotificationReqValidator _createValidator;
        private readonly UpdateNotificationReqValidator _updateValidator;

        public NotificationsController(
            INotificationService notificationService, 
            ILogger<NotificationsController> logger,
            CreateNotificationReqValidator createValidator,
            UpdateNotificationReqValidator updateValidator)
        {
            _notificationService = notificationService ?? throw new ArgumentNullException(nameof(notificationService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _createValidator = createValidator ?? throw new ArgumentNullException(nameof(createValidator));
            _updateValidator = updateValidator ?? throw new ArgumentNullException(nameof(updateValidator));
        }

        [HttpGet]
        public async Task<ActionResult<Result<IEnumerable<NotificationDto>>>> GetAll(CancellationToken cancellationToken = default)
        {
            var notifications = await _notificationService.GetAllAsync(cancellationToken);
            return Ok(Result.Success(notifications));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Result<NotificationDto>>> GetById(int id, CancellationToken cancellationToken = default)
        {
            var notification = await _notificationService.GetByIdAsync(id, cancellationToken);
            return Ok(Result.Success(notification));
        }

        [HttpGet("employee/{employeeId}")]
        public async Task<ActionResult<Result<IEnumerable<NotificationDto>>>> GetByEmployeeId(int employeeId, CancellationToken cancellationToken = default)
        {
            var notifications = await _notificationService.GetNotificationsByEmployeeAsync(employeeId, cancellationToken);
            return Ok(Result.Success(notifications));
        }

        [HttpGet("accesspoint/{accessPointId}")]
        public async Task<ActionResult<Result<IEnumerable<NotificationDto>>>> GetByAccessPointId(int accessPointId, CancellationToken cancellationToken = default)
        {
            var notifications = await _notificationService.GetNotificationsByAccessPointAsync(accessPointId, cancellationToken);
            return Ok(Result.Success(notifications));
        }

        [HttpPost]
        public async Task<ActionResult<Result<NotificationDto>>> Create([FromBody] CreateNotificationReq request, CancellationToken cancellationToken = default)
        {
            ValidationResult validationResult = await _createValidator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.ConvertAll(error => new Error(error.ErrorMessage));
                return BadRequest(Result.Failure(errors));
            }

            var notification = await _notificationService.CreateAsync(request, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id = notification.Id }, Result<NotificationDto>.Success(notification));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Result>> Update(int id, [FromBody] UpdateNotificationReq request, CancellationToken cancellationToken = default)
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

            await _notificationService.UpdateAsync(request, cancellationToken);
            return Ok(Result.Success());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Result>> Delete(int id, CancellationToken cancellationToken = default)
        {
            await _notificationService.DeleteAsync(id, cancellationToken);
            return Ok(Result.Success());
        }

        [HttpPost("{id}/process")]
        public async Task<ActionResult<Result>> ProcessNotification(int id, CancellationToken cancellationToken = default)
        {
            await _notificationService.ProcessNotificationAsync(id, cancellationToken);
            return Ok(Result.Success());
        }
    }
} 