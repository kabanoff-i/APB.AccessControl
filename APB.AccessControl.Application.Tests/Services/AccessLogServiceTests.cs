using APB.AccessControl.Application.Filters;
using APB.AccessControl.Application.Interfaces;
using APB.AccessControl.Application.Services;
using APB.AccessControl.Domain.Entities;
using APB.AccessControl.Domain.Primitives;
using APB.AccessControl.Shared.Models.DTOs;
using APB.AccessControl.Shared.Models.Requests;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace APB.AccessControl.Application.Tests.Services
{
    public class AccessLogServiceTests
    {
        private readonly Mock<IAccessLogRepository> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<ILogger<AccessLogService>> _mockLogger;
        private readonly AccessLogService _service;

        public AccessLogServiceTests()
        {
            _mockRepository = new Mock<IAccessLogRepository>();
            _mockMapper = new Mock<IMapper>();
            _mockLogger = new Mock<ILogger<AccessLogService>>();
            
            _service = new AccessLogService(
                _mockRepository.Object,
                _mockMapper.Object,
                _mockLogger.Object);
        }

        [Fact]
        public async Task LogAccessAttemptAsync_ShouldReturnMappedAccessLog_WhenRequestIsValid()
        {
            // Arrange
            var createRequest = new CreateAccessLogReq 
            { 
                CardId = 1,
                EmployeeId = 1,
                AccessPointId = 1,
                AccessTime = DateTime.UtcNow,
                AccessResult = (int)AccessResult.Allowed 
            };
            
            var accessLog = new AccessLog
            { 
                Id = Guid.NewGuid(),
                CardId = 1,
                EmployeeId = 1,
                AccessPointId = 1,
                AccessTime = DateTime.UtcNow,
                AccessResult = AccessResult.Allowed
            };
            
            var accessLogDto = new AccessLogDto
            {
                Id = accessLog.Id,
                CardId = 1,
                EmployeeId = 1,
                AccessPointId = 1,
                AccessTime = accessLog.AccessTime,
                AccessResult = (int)AccessResult.Allowed
            };

            _mockMapper.Setup(m => m.Map<AccessLog>(createRequest)).Returns(accessLog);
            _mockRepository.Setup(r => r.AddAsync(accessLog, It.IsAny<CancellationToken>())).ReturnsAsync(accessLog);
            _mockMapper.Setup(m => m.Map<AccessLogDto>(accessLog)).Returns(accessLogDto);

            // Act
            var result = await _service.LogAccessAttemptAsync(createRequest);

            // Assert
            Assert.Equal(accessLogDto, result);
            _mockRepository.Verify(r => r.AddAsync(accessLog, It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task LogAccessAttemptAsync_ShouldThrowArgumentNullException_WhenRequestIsNull()
        {
            // Arrange
            CreateAccessLogReq request = null;

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _service.LogAccessAttemptAsync(request));
            _mockRepository.Verify(r => r.AddAsync(It.IsAny<AccessLog>(), It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact]
        public async Task GetLogsByFilterAsync_ShouldReturnMappedAccessLogs_WhenLogsExist()
        {
            // Arrange
            var filter = new AccessLogFilter { EmployeeId = 1 };
            
            var accessLogs = new List<AccessLog>
            {
                new AccessLog 
                { 
                    Id = Guid.NewGuid(), 
                    EmployeeId = 1, 
                    AccessPointId = 1,
                    AccessTime = DateTime.UtcNow,
                    AccessResult = AccessResult.Allowed
                },
                new AccessLog 
                { 
                    Id = Guid.NewGuid(), 
                    EmployeeId = 1, 
                    AccessPointId = 2,
                    AccessTime = DateTime.UtcNow.AddDays(-1),
                    AccessResult = AccessResult.Denied
                }
            };
            
            var accessLogDtos = new List<AccessLogDto>
            {
                new AccessLogDto 
                { 
                    Id = accessLogs[0].Id, 
                    EmployeeId = 1, 
                    AccessPointId = 1,
                    AccessTime = accessLogs[0].AccessTime,
                    AccessResult = (int)AccessResult.Allowed
                },
                new AccessLogDto 
                { 
                    Id = accessLogs[1].Id, 
                    EmployeeId = 1, 
                    AccessPointId = 2,
                    AccessTime = accessLogs[1].AccessTime,
                    AccessResult = (int)AccessResult.Denied
                }
            };

            _mockRepository.Setup(r => r.GetLogsByFilterAsync(filter, It.IsAny<CancellationToken>())).ReturnsAsync(accessLogs);
            _mockMapper.Setup(m => m.Map<IEnumerable<AccessLogDto>>(accessLogs)).Returns(accessLogDtos);

            // Act
            var result = await _service.GetLogsByFilterAsync(filter);

            // Assert
            Assert.Equal(accessLogDtos, result);
            _mockRepository.Verify(r => r.GetLogsByFilterAsync(filter, It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task GetLogsByFilterAsync_ShouldReturnEmptyList_WhenNoLogsMatch()
        {
            // Arrange
            var filter = new AccessLogFilter { EmployeeId = 999 };
            var emptyList = new List<AccessLog>();
            var emptyDtoList = new List<AccessLogDto>();

            _mockRepository.Setup(r => r.GetLogsByFilterAsync(filter, It.IsAny<CancellationToken>())).ReturnsAsync(emptyList);
            _mockMapper.Setup(m => m.Map<IEnumerable<AccessLogDto>>(emptyList)).Returns(emptyDtoList);

            // Act
            var result = await _service.GetLogsByFilterAsync(filter);

            // Assert
            Assert.Empty(result);
            _mockRepository.Verify(r => r.GetLogsByFilterAsync(filter, It.IsAny<CancellationToken>()), Times.Once);
        }
    }
} 