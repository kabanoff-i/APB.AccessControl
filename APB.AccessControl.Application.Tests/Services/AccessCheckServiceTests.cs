using APB.AccessControl.Application.Filters;
using APB.AccessControl.Application.Interfaces;
using APB.AccessControl.Application.Services;
using APB.AccessControl.Application.Services.Interfaces;
using APB.AccessControl.Domain.Entities;
using APB.AccessControl.Domain.Primitives;
using APB.AccessControl.Shared.Models.Requests;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;

namespace APB.AccessControl.Application.Tests.Services
{
    public class AccessCheckServiceTests
    {
        private readonly Mock<ICardRepository> _mockCardRepository;
        private readonly Mock<IAccessGridRepository> _mockAccessGridRepository;
        private readonly Mock<IAccessLogService> _mockAccessLogService;
        private readonly Mock<IEmployeeRepository> _mockEmployeeRepository;
        private readonly Mock<IAccessRuleRepository> _mockAccessRuleRepository;
        private readonly Mock<IAccessGroupRepository> _mockAccessGroupRepository;
        private readonly Mock<ILogger<AccessCheckService>> _mockLogger;
        private readonly Mock<IMapper> _mockMapper;
        private readonly AccessCheckService _service;

        public AccessCheckServiceTests()
        {
            _mockCardRepository = new Mock<ICardRepository>();
            _mockAccessGridRepository = new Mock<IAccessGridRepository>();
            _mockAccessLogService = new Mock<IAccessLogService>();
            _mockEmployeeRepository = new Mock<IEmployeeRepository>();
            _mockAccessRuleRepository = new Mock<IAccessRuleRepository>();
            _mockAccessGroupRepository = new Mock<IAccessGroupRepository>();
            _mockLogger = new Mock<ILogger<AccessCheckService>>();
            _mockMapper = new Mock<IMapper>();

            _service = new AccessCheckService(
                _mockAccessRuleRepository.Object,
                _mockCardRepository.Object,
                _mockAccessGroupRepository.Object,
                _mockAccessGridRepository.Object,
                _mockAccessLogService.Object,
                _mockEmployeeRepository.Object,
                _mockMapper.Object,
                _mockLogger.Object
            );
        }

        [Fact]
        public async Task CheckAccessAsync_CardNotFound_ReturnsFalse()
        {
            // Arrange
            var request = new CheckAccessReq
            {
                CardHash = "nonexistentHash",
                AcсessPointId = 1,
                DateAccess = DateTime.Now
            };

            _mockCardRepository.Setup(repo => repo.GetByHashAsync(request.CardHash, It.IsAny<CancellationToken>()))
                .ReturnsAsync((Card)null);

            // Act
            var result = await _service.CheckAccessAsync(request);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Contains("не найдена", result.Message);
            
            _mockAccessLogService.Verify(service => service.LogAccessAttemptAsync(
                It.Is<CreateAccessLogReq>(req => 
                    req.CardHash == request.CardHash && 
                    req.AccessResult == (int)AccessResult.Denied),
                It.IsAny<CancellationToken>()
            ), Times.Once);
        }

        [Fact]
        public async Task CheckAccessAsync_EmployeeNotFound_ReturnsFalse()
        {
            // Arrange
            var request = new CheckAccessReq
            {
                CardHash = "validHash",
                AcсessPointId = 1,
                DateAccess = DateTime.Now
            };

            var card = new Card { Id = 1, EmployeeId = 100, Hash = "validHash" };

            _mockCardRepository.Setup(repo => repo.GetByHashAsync(request.CardHash, It.IsAny<CancellationToken>()))
                .ReturnsAsync(card);

            _mockEmployeeRepository.Setup(repo => repo.GetByIdAsync(card.EmployeeId, It.IsAny<CancellationToken>()))
                .ReturnsAsync((Employee)null);

            // Act
            var result = await _service.CheckAccessAsync(request);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Contains("Сотрудник не найден", result.Message);
            
            _mockAccessLogService.Verify(service => service.LogAccessAttemptAsync(
                It.Is<CreateAccessLogReq>(req => 
                    req.CardId == card.Id && 
                    req.AccessResult == (int)AccessResult.Denied),
                It.IsAny<CancellationToken>()
            ), Times.Once);
        }

        [Fact]
        public async Task CheckAccessAsync_InactiveEmployee_ReturnsFalse()
        {
            // Arrange
            var request = new CheckAccessReq
            {
                CardHash = "validHash",
                AcсessPointId = 1,
                DateAccess = DateTime.Now
            };

            var card = new Card { Id = 1, EmployeeId = 100, Hash = "validHash" };
            var employee = new Employee { Id = 100, IsActive = false };

            _mockCardRepository.Setup(repo => repo.GetByHashAsync(request.CardHash, It.IsAny<CancellationToken>()))
                .ReturnsAsync(card);

            _mockEmployeeRepository.Setup(repo => repo.GetByIdAsync(card.EmployeeId, It.IsAny<CancellationToken>()))
                .ReturnsAsync(employee);

            // Act
            var result = await _service.CheckAccessAsync(request);

            // Assert
            Assert.False(result.IsSuccess);
            
            _mockAccessLogService.Verify(service => service.LogAccessAttemptAsync(
                It.Is<CreateAccessLogReq>(req => 
                    req.CardId == card.Id && 
                    req.EmployeeId == employee.Id && 
                    req.AccessResult == (int)AccessResult.Denied),
                It.IsAny<CancellationToken>()
            ), Times.Once);
        }

        [Fact]
        public async Task IsAccessRuleMatch_InactiveRule_ReturnsFalse()
        {
            // Arrange
            var request = new CheckAccessReq
            {
                CardHash = "validHash",
                AcсessPointId = 1,
                DateAccess = DateTime.Now
            };

            var card = new Card { Id = 1, EmployeeId = 100, Hash = "validHash" };
            var employee = new Employee { Id = 100, IsActive = true };

            var accessGroup = new AccessGroup { Id = 1, IsActive = true };

            var accessGrid = new AccessGrid
            {
                EmployeeId = employee.Id,
                AccessGroupId = accessGroup.Id,
                IsActive = true
            };

            var rule = new AccessRule
            {
                IsActive = false,
                AccessPointId = 1,
                AccessGroupId = accessGroup.Id
            };

            _mockCardRepository.Setup(repo => repo.GetByHashAsync(request.CardHash, It.IsAny<CancellationToken>()))
                .ReturnsAsync(card);
            _mockEmployeeRepository.Setup(repo => repo.GetByIdAsync(card.EmployeeId, It.IsAny<CancellationToken>()))
                .ReturnsAsync(employee);

            _mockAccessGridRepository.Setup(repo => repo.GetByEmployeeIdAsync(employee.Id, It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<AccessGrid> { accessGrid });

            _mockAccessGroupRepository.Setup(repo => repo.GetByIdAsync(accessGrid.AccessGroupId, It.IsAny<CancellationToken>()))
                .ReturnsAsync(accessGroup);
            
            _mockAccessRuleRepository.Setup(repo => repo.GetByFilterAsync(new AccessRuleFilter
            {
                AccessGroupId = accessGroup.Id,
                AccessPointId = 1
            }, It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<AccessRule> { rule });

            // Act
            var result = await _service.CheckAccessAsync(request);

            // Assert
            Assert.False(result.IsSuccess);
        }

        [Fact]
        public async Task IsAccessRuleMatch_DifferentAccessPoint_ReturnsFalse()
        {
            // Arrange
            var request = new CheckAccessReq
            {
                CardHash = "validHash",
                AcсessPointId = 1,
                DateAccess = DateTime.Now
            };

            var card = new Card { Id = 1, EmployeeId = 100, Hash = "validHash" };
            var employee = new Employee { Id = 100, IsActive = true };

            var accessGroup = new AccessGroup { Id = 1, IsActive = true };

            var accessGrid = new AccessGrid
            {
                EmployeeId = employee.Id,
                AccessGroupId = accessGroup.Id,
                IsActive = true
            };

            var rule = new AccessRule
            {
                IsActive = true,
                AccessPointId = 2,
                StartDate = DateTime.Now.AddDays(-10),
                EndDate = DateTime.Now.AddDays(10),
                DaysOfWeek = new System.Collections.BitArray(new bool[] { true, true, true, true, true, true, true }),
                AllowedTimeStart = TimeSpan.Zero,
                AllowedTimeEnd = TimeSpan.FromHours(23).Add(TimeSpan.FromMinutes(59))
            };

            _mockCardRepository.Setup(repo => repo.GetByHashAsync(request.CardHash, It.IsAny<CancellationToken>()))
                .ReturnsAsync(card);
            _mockEmployeeRepository.Setup(repo => repo.GetByIdAsync(card.EmployeeId, It.IsAny<CancellationToken>()))
                .ReturnsAsync(employee);
            
            _mockAccessGridRepository.Setup(repo => repo.GetByEmployeeIdAsync(employee.Id, It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<AccessGrid> { accessGrid });

            _mockAccessGroupRepository.Setup(repo => repo.GetByIdAsync(accessGrid.AccessGroupId, It.IsAny<CancellationToken>()))
                .ReturnsAsync(accessGroup);

            _mockAccessRuleRepository.Setup(repo => repo.GetByFilterAsync(new AccessRuleFilter
            {
                AccessGroupId = accessGroup.Id,
                AccessPointId = 1
            }, It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<AccessRule>());

            // Act
            var result = await _service.CheckAccessAsync(request);

            // Assert
            Assert.False(result.IsSuccess);
        }

        [Fact]
        public async Task IsAccessRuleMatch_OutsideDateRange_ReturnsFalse()
        {
            // Arrange
            var now = DateTime.Now;
            var request = new CheckAccessReq
            {
                CardHash = "validHash",
                AcсessPointId = 1,
                DateAccess = now
            };

            var card = new Card { Id = 1, EmployeeId = 100, Hash = "validHash" };
            var employee = new Employee { Id = 100, IsActive = true };
            var rule = new AccessRule
            {
                IsActive = true,
                AccessPointId = 1,
                StartDate = now.AddDays(1),
                EndDate = now.AddDays(10),
                DaysOfWeek = new bool[] { true, true, true, true, true, true, true },
                AllowedTimeStart = TimeSpan.Zero,
                AllowedTimeEnd = TimeSpan.FromHours(23).Add(TimeSpan.FromMinutes(59))
            };

            _mockCardRepository.Setup(repo => repo.GetByHashAsync(request.CardHash, It.IsAny<CancellationToken>()))
                .ReturnsAsync(card);
            _mockEmployeeRepository.Setup(repo => repo.GetByIdAsync(card.EmployeeId, It.IsAny<CancellationToken>()))
                .ReturnsAsync(employee);
            _mockAccessRuleRepository.Setup(repo => repo.GetRulesForEmployeeAsync(employee.Id, It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<AccessRule> { rule });

            // Act
            var result = await _service.CheckAccessAsync(request);

            // Assert
            Assert.False(result.IsSuccess);
        }
    }
}
