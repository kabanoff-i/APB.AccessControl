using APB.AccessControl.Application.Filters;
using APB.AccessControl.Application.Services;
using APB.AccessControl.Application.Services.Interfaces;
using APB.AccessControl.Domain.Entities;
using APB.AccessControl.Domain.Exceptions;
using APB.AccessControl.Domain.Primitives;
using APB.AccessControl.Shared.Models.DTOs;
using APB.AccessControl.Shared.Models.Requests;
using APB.AccessControl.Shared.Models.Responses;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace APB.AccessControl.Application.Tests.Services
{
    public class AccessCheckServiceTests
    {
        private readonly Mock<ICardService> _mockCardService;
        private readonly Mock<IAccessRuleService> _mockAccessRuleService;
        private readonly Mock<IAccessGroupService> _mockAccessGroupService;
        private readonly Mock<IAccessLogService> _mockAccessLogService;
        private readonly Mock<IEmployeeService> _mockEmployeeService;
        
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<ILogger<AccessCheckService>> _mockLogger;
        private readonly AccessCheckService _service;

        public AccessCheckServiceTests()
        {
            _mockCardService = new Mock<ICardService>();
            _mockAccessRuleService = new Mock<IAccessRuleService>();
            _mockAccessGroupService = new Mock<IAccessGroupService>();
            _mockAccessLogService = new Mock<IAccessLogService>();
            _mockEmployeeService = new Mock<IEmployeeService>();
            _mockMapper = new Mock<IMapper>();
            _mockLogger = new Mock<ILogger<AccessCheckService>>();
            
            _service = new AccessCheckService(
                _mockAccessRuleService.Object,
                _mockCardService.Object,
                _mockAccessGroupService.Object,
                _mockAccessLogService.Object,
                _mockEmployeeService.Object,
                _mockMapper.Object,
                _mockLogger.Object);
        }

        [Fact]
        public async Task CheckAccessAsync_ShouldDenyAccess_WhenCardNotFound()
        {
            // Arrange
            var request = new CheckAccessReq
            {
                CardHash = "NonExistentHash",
                AcсessPointId = 1,
                DateAccess = DateTime.UtcNow
            };

            _mockCardService.Setup(s => s.GetCardByHashAsync(request.CardHash, It.IsAny<CancellationToken>())).ThrowsAsync(new NotFoundException(nameof(Card), nameof(Card.Id), request.CardHash));
            _mockAccessLogService.Setup(s => s.LogAccessAttemptAsync(It.IsAny<CreateAccessLogReq>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new AccessLogDto());

            // Act
            var result = await _service.CheckAccessAsync(request);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Contains("Карта", result.Message);
            Assert.Contains("не найдена", result.Message);
            _mockAccessLogService.Verify(s => s.LogAccessAttemptAsync(
                It.Is<CreateAccessLogReq>(req => 
                    req.CardHash == request.CardHash && 
                    req.AccessPointId == request.AcсessPointId && 
                    req.AccessResult == (int)AccessResult.Denied), 
                It.IsAny<CancellationToken>()), 
                Times.Once);
        }

        [Fact]
        public async Task CheckAccessAsync_ShouldDenyAccess_WhenCardDeactivated()
        {
            // Arrange
            var request = new CheckAccessReq
            {
                CardHash = "ValidHash",
                AcсessPointId = 1,
                DateAccess = DateTime.UtcNow
            };

            var card = new CardDto
            {
                Id = 1,
                EmployeeId = 1,
                IsActive = false
            };

            var employee = new EmployeeDto
            {
                Id = 1,
                FirstName = "Иван",
                LastName = "Иванов",
                PassportNumber = "1234567",
                Photo = new byte[] { 1, 2, 3 }
            };

            _mockCardService.Setup(s => s.GetCardByHashAsync(request.CardHash, It.IsAny<CancellationToken>())).ReturnsAsync(card);
            _mockEmployeeService.Setup(s => s.GetEmployeeByIdAsync(card.EmployeeId, It.IsAny<CancellationToken>())).ReturnsAsync(employee);
            _mockAccessLogService.Setup(s => s.LogAccessAttemptAsync(It.IsAny<CreateAccessLogReq>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new AccessLogDto());

            // Act
            var result = await _service.CheckAccessAsync(request);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal("Карта деактивирована", result.Message);
            
            _mockAccessLogService.Verify(s => s.LogAccessAttemptAsync(
                It.Is<CreateAccessLogReq>(req => 
                    req.CardId == card.Id && 
                    req.EmployeeId == employee.Id && 
                    req.AccessPointId == request.AcсessPointId && 
                    req.AccessResult == (int)AccessResult.Denied), 
                It.IsAny<CancellationToken>()), 
                Times.Once);
        }

        [Fact]
        public async Task CheckAccessAsync_ShouldDenyAccess_WhenNoAccessGroups()
        {
            // Arrange
            var request = new CheckAccessReq
            {
                CardHash = "ValidHash",
                AcсessPointId = 1,
                DateAccess = DateTime.UtcNow
            };

            var card = new CardDto
            {
                Id = 1,
                EmployeeId = 1,
                IsActive = true
            };

            var employee = new EmployeeDto
            {
                Id = 1,
                FirstName = "Иван",
                LastName = "Иванов",
                PassportNumber = "1234567",
                Photo = new byte[] { 1, 2, 3 }
            };

            var emptyGroups = new List<AccessGroupDto>();

            _mockCardService.Setup(s => s.GetCardByHashAsync(request.CardHash, It.IsAny<CancellationToken>())).ReturnsAsync(card);
            _mockEmployeeService.Setup(s => s.GetEmployeeByIdAsync(card.EmployeeId, It.IsAny<CancellationToken>())).ReturnsAsync(employee);
            _mockAccessGroupService.Setup(s => s.GetByEmployeeIdAsync(card.EmployeeId, It.IsAny<CancellationToken>())).ReturnsAsync(emptyGroups);
            _mockAccessLogService.Setup(s => s.LogAccessAttemptAsync(It.IsAny<CreateAccessLogReq>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new AccessLogDto());

            // Act
            var result = await _service.CheckAccessAsync(request);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Contains("группы доступа", result.Message);
            
            _mockAccessLogService.Verify(s => s.LogAccessAttemptAsync(
                It.Is<CreateAccessLogReq>(req => 
                    req.CardId == card.Id && 
                    req.EmployeeId == employee.Id && 
                    req.AccessPointId == request.AcсessPointId && 
                    req.AccessResult == (int)AccessResult.Denied), 
                It.IsAny<CancellationToken>()), 
                Times.Once);
        }

        [Fact]
        public async Task CheckAccessAsync_ShouldDenyAccess_WhenNoAccessRules()
        {
            // Arrange
            var request = new CheckAccessReq
            {
                CardHash = "ValidHash",
                AcсessPointId = 1,
                DateAccess = DateTime.UtcNow
            };

            var card = new CardDto
            {
                Id = 1,
                EmployeeId = 1,
                IsActive = true
            };

            var employee = new EmployeeDto
            {
                Id = 1,
                FirstName = "Иван",
                LastName = "Иванов",
                PassportNumber = "1234567",
                Photo = new byte[] { 1, 2, 3 }
            };

            var groups = new List<AccessGroupDto> { new AccessGroupDto { Id = 1 }, new AccessGroupDto { Id = 2 } };

            _mockCardService.Setup(s => s.GetCardByHashAsync(request.CardHash, It.IsAny<CancellationToken>())).ReturnsAsync(card);
            _mockEmployeeService.Setup(s => s.GetEmployeeByIdAsync(card.EmployeeId, It.IsAny<CancellationToken>())).ReturnsAsync(employee);
            _mockAccessGroupService.Setup(s => s.GetByEmployeeIdAsync(card.EmployeeId, It.IsAny<CancellationToken>())).ReturnsAsync(groups);

            // Создать правило доступа, которое соответствует требованиям IsAccessRuleMatch
            var validRule = new AccessRuleDto 
            {
                Id = 1,
                AccessGroupId = 1,
                AccessPointId = request.AcсessPointId,
                IsActive = true,
                StartDate = request.DateAccess.AddDays(-1),
                EndDate = request.DateAccess.AddDays(1),
                AllowedTimeStart = new TimeSpan(0, 0, 0),
                AllowedTimeEnd = new TimeSpan(23, 59, 59),
                DaysOfWeek = new System.Collections.BitArray(7, true)
            };

            var rules = new List<AccessRuleDto> { validRule };

            _mockAccessRuleService.Setup(s => s.GetByFilterAsync(
                It.Is<AccessRuleFilter>(f => f.AccessPointId == request.AcсessPointId && f.AccessGroupId == 1), 
                It.IsAny<CancellationToken>())).ReturnsAsync(rules);

            _mockAccessLogService.Setup(s => s.LogAccessAttemptAsync(It.IsAny<CreateAccessLogReq>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new AccessLogDto());

            // Act
            var result = await _service.CheckAccessAsync(request);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Contains("Нет прав доступа", result.Message);
            
            _mockAccessLogService.Verify(s => s.LogAccessAttemptAsync(
                It.Is<CreateAccessLogReq>(req => 
                    req.CardId == card.Id && 
                    req.EmployeeId == employee.Id && 
                    req.AccessPointId == request.AcсessPointId && 
                    req.AccessResult == (int)AccessResult.Denied), 
                It.IsAny<CancellationToken>()), 
                Times.Once);
        }

        [Fact]
        public async Task CheckAccessAsync_ShouldGrantAccess_WhenAllConditionsMet()
        {
            // Arrange
            var request = new CheckAccessReq
            {
                CardHash = "ValidHash",
                AcсessPointId = 1,
                DateAccess = DateTime.UtcNow
            };

            var card = new CardDto
            {
                Id = 1,
                EmployeeId = 1,
                IsActive = true
            };

            var employee = new EmployeeDto
            {
                Id = 1,
                FirstName = "Иван",
                LastName = "Иванов",
                IsActive = true,
                PassportNumber = "1234567",
                Photo = new byte[] { 1, 2, 3 }
            };

            var groups = new List<AccessGroupDto> { new AccessGroupDto { Id = 1 }, new AccessGroupDto { Id = 2 } };

            // Создать правило доступа, которое соответствует требованиям IsAccessRuleMatch
            var validRule = new AccessRuleDto 
            {
                Id = 1,
                AccessGroupId = 1,
                AccessPointId = request.AcсessPointId,
                IsActive = true,
                StartDate = request.DateAccess.AddDays(-1),
                EndDate = request.DateAccess.AddDays(1),
                AllowedTimeStart = new TimeSpan(0, 0, 0),
                AllowedTimeEnd = new TimeSpan(23, 59, 59),
                DaysOfWeek = new System.Collections.BitArray(7, true)
            };

            var rules = new List<AccessRuleDto> { validRule };

            _mockCardService.Setup(s => s.GetCardByHashAsync(request.CardHash, It.IsAny<CancellationToken>())).ReturnsAsync(card);
            _mockEmployeeService.Setup(s => s.GetEmployeeByIdAsync(card.EmployeeId, It.IsAny<CancellationToken>())).ReturnsAsync(employee);
            _mockAccessGroupService.Setup(s => s.GetByEmployeeIdAsync(card.EmployeeId, It.IsAny<CancellationToken>())).ReturnsAsync(groups);
            _mockAccessRuleService.Setup(s => s.GetByFilterAsync(
                It.Is<AccessRuleFilter>(f => f.AccessPointId == request.AcсessPointId && f.AccessGroupId == 1), 
                It.IsAny<CancellationToken>())).ReturnsAsync(rules);
            _mockAccessLogService.Setup(s => s.LogAccessAttemptAsync(It.IsAny<CreateAccessLogReq>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new AccessLogDto());

            // Act
            var result = await _service.CheckAccessAsync(request);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal("Доступ разрешен", result.Message);
            
            _mockAccessLogService.Verify(s => s.LogAccessAttemptAsync(
                It.Is<CreateAccessLogReq>(req => 
                    req.CardId == card.Id && 
                    req.EmployeeId == employee.Id && 
                    req.AccessPointId == request.AcсessPointId && 
                    req.AccessResult == (int)AccessResult.Granted), 
                It.IsAny<CancellationToken>()), 
                Times.Once);
        }
    }
} 