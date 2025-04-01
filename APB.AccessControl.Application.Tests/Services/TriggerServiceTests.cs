using APB.AccessControl.Application.Interfaces;
using APB.AccessControl.Application.Services;
using APB.AccessControl.Application.Services.Interfaces;
using APB.AccessControl.Domain.Entities;
using APB.AccessControl.Domain.Exceptions;
using APB.AccessControl.Domain.Primitives;
using APB.AccessControl.Shared.Models.DTOs;
using APB.AccessControl.Shared.Models.Requests;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;


namespace APB.AccessControl.Application.Tests.Services
{
    public class TriggerServiceTests
    {
        private readonly Mock<ITriggerRepository> _mockTriggerRepository;
        private readonly Mock<IAccessLogRepository> _mockAccessLogRepository;
        private readonly Mock<IAccessTriggerLogService> _mockAccessTriggerLogService;
        private readonly Mock<ITriggerExecuter> _mockTriggerExecuter;
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<ILogger<TriggerService>> _mockLogger;
        private readonly TriggerService _service;

        public TriggerServiceTests()
        {
            _mockTriggerRepository = new Mock<ITriggerRepository>();
            _mockAccessLogRepository = new Mock<IAccessLogRepository>();
            _mockAccessTriggerLogService = new Mock<IAccessTriggerLogService>();
            _mockTriggerExecuter = new Mock<ITriggerExecuter>();
            _mockMapper = new Mock<IMapper>();
            _mockLogger = new Mock<ILogger<TriggerService>>();
            
            _service = new TriggerService(
                _mockTriggerRepository.Object,
                _mockAccessLogRepository.Object,
                _mockAccessTriggerLogService.Object,
                _mockTriggerExecuter.Object,
                _mockMapper.Object,
                _mockLogger.Object);
        }

        [Fact]
        public async Task CreateAsync_ShouldReturnMappedTrigger_WhenCreationSucceeds()
        {
            // Arrange
            var createRequest = new CreateTriggerReq 
            { 
                AccessPointId = 1,
                AccessResult = (int)AccessResult.Granted,
                ActionType = 1,
                ActionValue = "SomeAction"
            };
            
            var trigger = new Trigger
            { 
                Id = 1,
                AccessPointId = 1,
                AccessResult = AccessResult.Granted,
                ActionType = (ActionType)1,
                ActionValue = "SomeAction",
                IsActive = true
            };
            
            var triggerDto = new TriggerDto
            {
                Id = 1,
                AccessPointId = 1,
                AccessResult = (int)AccessResult.Granted,
                ActionType = 1,
                ActionValue = "SomeAction",
                IsActive = true
            };

            _mockMapper.Setup(m => m.Map<Trigger>(createRequest)).Returns(trigger);
            _mockTriggerRepository.Setup(r => r.AddAsync(trigger, It.IsAny<CancellationToken>())).ReturnsAsync(trigger);
            _mockMapper.Setup(m => m.Map<TriggerDto>(trigger)).Returns(triggerDto);

            // Act
            var result = await _service.CreateAsync(createRequest);

            // Assert
            Assert.Equal(triggerDto, result);
            _mockTriggerRepository.Verify(r => r.AddAsync(trigger, It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_ShouldCallRepositoryUpdateAsync_WhenTriggerExists()
        {
            // Arrange
            var updateRequest = new UpdateTriggerReq 
            { 
                Id = 1,
                AccessPointId = 1,
                AccessResult = (int)AccessResult.Denied,
                ActionType = 2,
                ActionValue = "UpdatedAction",
                IsActive = true
            };
            
            var existingTrigger = new Trigger
            { 
                Id = 1,
                AccessPointId = 1,
                AccessResult = AccessResult.Granted,
                ActionType = (ActionType)1,
                ActionValue = "SomeAction",
                IsActive = true
            };
            
            var updatedTrigger = new Trigger
            { 
                Id = 1,
                AccessPointId = 1,
                AccessResult = AccessResult.Denied,
                ActionType = (ActionType)2,
                ActionValue = "UpdatedAction",
                IsActive = true
            };

            _mockTriggerRepository.Setup(r => r.GetByIdAsync(1, It.IsAny<CancellationToken>())).ReturnsAsync(existingTrigger);
            _mockMapper.Setup(m => m.Map(updateRequest, existingTrigger)).Callback((Action)(() => {
                existingTrigger.AccessResult = AccessResult.Denied;
                existingTrigger.ActionType = (ActionType)2;
                existingTrigger.ActionValue = "UpdatedAction";
            }));

            // Act
            await _service.UpdateAsync(updateRequest);

            // Assert
            _mockTriggerRepository.Verify(r => r.UpdateAsync(existingTrigger, It.IsAny<CancellationToken>()), Times.Once);
            Assert.Equal(AccessResult.Denied, existingTrigger.AccessResult);
            Assert.Equal(2, (int)existingTrigger.ActionType);
            Assert.Equal("UpdatedAction", existingTrigger.ActionValue);
        }

        [Fact]
        public async Task UpdateAsync_ShouldThrowNotFoundException_WhenTriggerDoesNotExist()
        {
            // Arrange
            var updateRequest = new UpdateTriggerReq { Id = 999 };
            
            _mockTriggerRepository.Setup(r => r.GetByIdAsync(999, It.IsAny<CancellationToken>())).ReturnsAsync((Trigger)null);

            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _service.UpdateAsync(updateRequest));
            _mockTriggerRepository.Verify(r => r.UpdateAsync(It.IsAny<Trigger>(), It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact]
        public async Task DeleteAsync_ShouldCallRepositoryDeleteAsync_WhenTriggerExists()
        {
            // Arrange
            int triggerId = 1;
            
            _mockTriggerRepository.Setup(r => r.ExistsAsync(triggerId, It.IsAny<CancellationToken>())).ReturnsAsync(true);

            // Act
            await _service.DeleteAsync(triggerId);

            // Assert
            _mockTriggerRepository.Verify(r => r.DeleteAsync(triggerId, It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_ShouldThrowNotFoundException_WhenTriggerDoesNotExist()
        {
            // Arrange
            int triggerId = 999;
            
            _mockTriggerRepository.Setup(r => r.ExistsAsync(triggerId, It.IsAny<CancellationToken>())).ReturnsAsync(false);

            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _service.DeleteAsync(triggerId));
            _mockTriggerRepository.Verify(r => r.DeleteAsync(triggerId, It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnMappedTriggers()
        {
            // Arrange
            var triggers = new List<Trigger>
            {
                new Trigger { Id = 1, AccessPointId = 1, AccessResult = AccessResult.Granted, IsActive = true },
                new Trigger { Id = 2, AccessPointId = 2, AccessResult = AccessResult.Denied, IsActive = true }
            };
            
            var triggerDtos = new List<TriggerDto>
            {
                new TriggerDto { Id = 1, AccessPointId = 1, AccessResult = (int)AccessResult.Granted, IsActive = true },
                new TriggerDto { Id = 2, AccessPointId = 2, AccessResult = (int)AccessResult.Denied, IsActive = true }
            };

            _mockTriggerRepository.Setup(r => r.GetAllAsync(It.IsAny<CancellationToken>())).ReturnsAsync(triggers);
            _mockMapper.Setup(m => m.Map<IEnumerable<TriggerDto>>(triggers)).Returns(triggerDtos);

            // Act
            var result = await _service.GetAllAsync();

            // Assert
            Assert.Equal(triggerDtos, result);
            _mockTriggerRepository.Verify(r => r.GetAllAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task ExecuteTriggersAsync_ShouldExecuteTriggersAndLogExecution_WhenAccessLogExists()
        {
            // Arrange
            var accessLogId = Guid.NewGuid();
            var accessPointId = 1;
            
            var accessLog = new AccessLog
            {
                Id = accessLogId,
                AccessPointId = accessPointId,
                AccessResult = AccessResult.Granted
            };
            
            var triggers = new List<Trigger>
            {
                new Trigger { Id = 1, AccessPointId = accessPointId, AccessResult = AccessResult.Granted, IsActive = true },
                new Trigger { Id = 2, AccessPointId = accessPointId, AccessResult = AccessResult.Granted, IsActive = true }
            };

            _mockAccessLogRepository.Setup(r => r.GetByIdAsync(accessLogId, It.IsAny<CancellationToken>())).ReturnsAsync(accessLog);
            _mockTriggerRepository.Setup(r => r.GetTriggersForAccessPointAsync(accessPointId, It.IsAny<CancellationToken>())).ReturnsAsync(triggers);
            
            _mockTriggerExecuter.Setup(e => e.ExecuteAsync(It.IsAny<Trigger>(), It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);
            _mockAccessTriggerLogService.Setup(s => s.LogAccessTriggerExecutionAsync(It.IsAny<CreateAccessTriggerLogReq>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(new AccessTriggerLogDto()));

            // Act
            await _service.ExecuteTriggersAsync(accessLogId);

            // Assert
            _mockAccessLogRepository.Verify(r => r.GetByIdAsync(accessLogId, It.IsAny<CancellationToken>()), Times.Once);
            _mockTriggerRepository.Verify(r => r.GetTriggersForAccessPointAsync(accessPointId, It.IsAny<CancellationToken>()), Times.Once);
            
            // Verify each trigger was executed and logged
            _mockTriggerExecuter.Verify(e => e.ExecuteAsync(It.IsAny<Trigger>(), It.IsAny<CancellationToken>()), Times.Exactly(triggers.Count));
            _mockAccessTriggerLogService.Verify(s => s.LogAccessTriggerExecutionAsync(
                It.Is<CreateAccessTriggerLogReq>(req => req.AccessLogId == accessLogId), 
                It.IsAny<CancellationToken>()), 
                Times.Exactly(triggers.Count));
        }

        [Fact]
        public async Task ExecuteTriggersAsync_ShouldThrowNotFoundException_WhenAccessLogDoesNotExist()
        {
            // Arrange
            var accessLogId = Guid.NewGuid();
            
            _mockAccessLogRepository.Setup(r => r.GetByIdAsync(accessLogId, It.IsAny<CancellationToken>())).ReturnsAsync((AccessLog)null);

            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _service.ExecuteTriggersAsync(accessLogId));
            
            _mockTriggerRepository.Verify(r => r.GetTriggersForAccessPointAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()), Times.Never);
            _mockTriggerExecuter.Verify(e => e.ExecuteAsync(It.IsAny<Trigger>(), It.IsAny<CancellationToken>()), Times.Never);
            _mockAccessTriggerLogService.Verify(s => s.LogAccessTriggerExecutionAsync(It.IsAny<CreateAccessTriggerLogReq>(), It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact]
        public async Task ExecuteTriggersAsync_ShouldNotExecuteTriggers_WhenNoTriggersExistForAccessPoint()
        {
            // Arrange
            var accessLogId = Guid.NewGuid();
            var accessPointId = 1;
            
            var accessLog = new AccessLog
            {
                Id = accessLogId,
                AccessPointId = accessPointId,
                AccessResult = AccessResult.Granted
            };
            
            var emptyTriggers = new List<Trigger>();

            _mockAccessLogRepository.Setup(r => r.GetByIdAsync(accessLogId, It.IsAny<CancellationToken>())).ReturnsAsync(accessLog);
            _mockTriggerRepository.Setup(r => r.GetTriggersForAccessPointAsync(accessPointId, It.IsAny<CancellationToken>())).ReturnsAsync(emptyTriggers);

            // Act
            await _service.ExecuteTriggersAsync(accessLogId);

            // Assert
            _mockAccessLogRepository.Verify(r => r.GetByIdAsync(accessLogId, It.IsAny<CancellationToken>()), Times.Once);
            _mockTriggerRepository.Verify(r => r.GetTriggersForAccessPointAsync(accessPointId, It.IsAny<CancellationToken>()), Times.Once);
            
            // Verify no triggers were executed or logged
            _mockTriggerExecuter.Verify(e => e.ExecuteAsync(It.IsAny<Trigger>(), It.IsAny<CancellationToken>()), Times.Never);
            _mockAccessTriggerLogService.Verify(s => s.LogAccessTriggerExecutionAsync(It.IsAny<CreateAccessTriggerLogReq>(), It.IsAny<CancellationToken>()), Times.Never);
        }
    }
} 