using APB.AccessControl.Application.Interfaces;
using APB.AccessControl.Application.Services.Interfaces;
using APB.AccessControl.Domain.Entities;
using APB.AccessControl.Domain.Exceptions;
using APB.AccessControl.Shared.Models.DTOs;
using AutoMapper;
using Microsoft.Extensions.Logging;
using APB.AccessControl.Application.Common;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace APB.AccessControl.Application.Services
{
    public class TriggerLogService : IAccessTriggerLogService
    {
        private readonly ITriggerLogRepository _triggerLogRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<TriggerLogService> _logger;

        public TriggerLogService(
            ITriggerLogRepository triggerLogRepository,
            IMapper mapper, 
            ILogger<TriggerLogService> logger)
        {
            _triggerLogRepository = triggerLogRepository 
                ?? throw new ArgumentNullException(nameof(triggerLogRepository));
            _mapper = mapper 
                ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger;
        }

        
    }
}
