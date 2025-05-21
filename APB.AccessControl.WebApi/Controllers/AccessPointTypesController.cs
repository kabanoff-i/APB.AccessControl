using APB.AccessControl.Application.Services.Interfaces;
using APB.AccessControl.Shared.Models.Common;
using APB.AccessControl.Shared.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace APB.AccessControl.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccessPointTypesController : ControllerBase
    {
        private readonly IAccessPointTypeService _accessPointTypeService;
        private readonly ILogger<AccessPointTypesController> _logger;

        public AccessPointTypesController(
            IAccessPointTypeService accessPointTypeService,
            ILogger<AccessPointTypesController> logger)
        {
            _accessPointTypeService = accessPointTypeService ?? throw new ArgumentNullException(nameof(accessPointTypeService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Получить все типы точек доступа
        /// </summary>
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<Result<IEnumerable<AccessPointTypeDto>>>> GetAll(CancellationToken cancellationToken = default)
        {
            var accessPointTypes = await _accessPointTypeService.GetAllAsync(cancellationToken);
            return Ok(Result.Success(accessPointTypes));
        }

        /// <summary>
        /// Получить тип точки доступа по идентификатору
        /// </summary>
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Result<AccessPointTypeDto>>> GetById(int id, CancellationToken cancellationToken = default)
        {
            var accessPointType = await _accessPointTypeService.GetByIdAsync(id, cancellationToken);
            return Ok(Result.Success(accessPointType));
        }
    }
} 