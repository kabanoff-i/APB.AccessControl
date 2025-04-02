using APB.AccessControl.Application.Interfaces;
using APB.AccessControl.Application.Services;
using APB.AccessControl.Domain.Entities;
using APB.AccessControl.Domain.Exceptions;
using APB.AccessControl.Shared.Models.DTOs;
using APB.AccessControl.Shared.Models.Requests;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace APB.AccessControl.Application.Tests.Services
{
    public class AccessPointServiceTests
    {
        private readonly Mock<IAccessPointRepository> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<ILogger<AccessPointService>> _mockLogger;
        private readonly AccessPointService _service;

        public AccessPointServiceTests()
        {
            _mockRepository = new Mock<IAccessPointRepository>();
            _mockMapper = new Mock<IMapper>();
            _mockLogger = new Mock<ILogger<AccessPointService>>();
            
            _service = new AccessPointService(
                _mockRepository.Object,
                _mockMapper.Object,
                _mockLogger.Object);
        }

        [Fact]
        public async Task CreateAsync_ShouldReturnMappedAccessPoint_WhenCreationSucceeds()
        {
            // Arrange
            var createRequest = new CreateAccessPointReq 
            { 
                Name = "Главный вход", 
                AccessPointTypeId = 1,
                IpAddress = "192.168.1.100",
                Location = "Первый этаж"
            };
            
            var accessPoint = new AccessPoint
            { 
                Id = 1,
                Name = "Главный вход", 
                AccessPointTypeId = 1,
                IpAddress = "192.168.1.100",
                Location = "Первый этаж",
                IsActive = true
            };
            
            var accessPointDto = new AccessPointDto
            {
                Id = 1,
                Name = "Главный вход", 
                AccessPointTypeId = 1,
                IpAddress = "192.168.1.100",
                Location = "Первый этаж",
                IsActive = true
            };

            _mockMapper.Setup(m => m.Map<AccessPoint>(createRequest)).Returns(accessPoint);
            _mockRepository.Setup(r => r.AddAsync(accessPoint, It.IsAny<CancellationToken>())).ReturnsAsync(accessPoint);
            _mockMapper.Setup(m => m.Map<AccessPointDto>(accessPoint)).Returns(accessPointDto);

            // Act
            var result = await _service.CreateAsync(createRequest);

            // Assert
            Assert.Equal(accessPointDto, result);
            _mockRepository.Verify(r => r.AddAsync(accessPoint, It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_ShouldCallRepositoryUpdateAsync_WhenAccessPointExists()
        {
            // Arrange
            var updateRequest = new UpdateAccessPointReq 
            { 
                Id = 1, 
                Name = "Обновленный вход", 
                AccessPointTypeId = 1,
                IpAddress = "192.168.1.101",
                Location = "Первый этаж"
            };
            
            var accessPoint = new AccessPoint 
            { 
                Id = 1, 
                Name = "Обновленный вход", 
                AccessPointTypeId = 1,
                IpAddress = "192.168.1.101",
                Location = "Первый этаж",
                IsActive = true
            };

            _mockRepository.Setup(r => r.ExistsAsync(1, It.IsAny<CancellationToken>())).ReturnsAsync(true);
            _mockMapper.Setup(m => m.Map<AccessPoint>(updateRequest)).Returns(accessPoint);

            // Act
            await _service.UpdateAsync(updateRequest);

            // Assert
            _mockRepository.Verify(r => r.UpdateAsync(accessPoint, It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_ShouldThrowNotFoundException_WhenAccessPointDoesNotExist()
        {
            // Arrange
            var updateRequest = new UpdateAccessPointReq { Id = 999 };
            
            _mockRepository.Setup(r => r.ExistsAsync(999, It.IsAny<CancellationToken>())).ReturnsAsync(false);

            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _service.UpdateAsync(updateRequest));
            _mockRepository.Verify(r => r.UpdateAsync(It.IsAny<AccessPoint>(), It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact]
        public async Task DeleteAsync_ShouldCallRepositoryDeleteAsync_WhenAccessPointExists()
        {
            // Arrange
            var accessPoint = new AccessPoint { Id = 1, Name = "Главный вход", AccessPointTypeId = 1, IsActive = true };
            
            _mockRepository.Setup(r => r.GetByIdAsync(accessPoint.Id, It.IsAny<CancellationToken>())).ReturnsAsync(accessPoint);

            // Act
            await _service.DeleteAsync(accessPoint.Id);

            // Assert
            _mockRepository.Verify(r => r.DeleteAsync(accessPoint, It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_ShouldThrowNotFoundException_WhenAccessPointDoesNotExist()
        {
            // Arrange
            var accessPoint = new AccessPoint { Id = 999, Name = "Главный вход", AccessPointTypeId = 1, IsActive = true };
            
            _mockRepository.Setup(r => r.GetByIdAsync(accessPoint.Id, It.IsAny<CancellationToken>())).ReturnsAsync((AccessPoint)null);

            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _service.DeleteAsync(accessPoint.Id));
            _mockRepository.Verify(r => r.DeleteAsync(accessPoint, It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnMappedAccessPoints()
        {
            // Arrange
            var accessPoints = new List<AccessPoint>
            {
                new AccessPoint { Id = 1, Name = "Главный вход", AccessPointTypeId = 1, IsActive = true },
                new AccessPoint { Id = 2, Name = "Служебный вход", AccessPointTypeId = 1, IsActive = true }
            };
            
            var accessPointDtos = new List<AccessPointDto>
            {
                new AccessPointDto { Id = 1, Name = "Главный вход", AccessPointTypeId = 1, IsActive = true },
                new AccessPointDto { Id = 2, Name = "Служебный вход", AccessPointTypeId = 1, IsActive = true }
            };

            _mockRepository.Setup(r => r.GetAllAsync(It.IsAny<CancellationToken>())).ReturnsAsync(accessPoints);
            _mockMapper.Setup(m => m.Map<IEnumerable<AccessPointDto>>(accessPoints)).Returns(accessPointDtos);

            // Act
            var result = await _service.GetAllAsync();

            // Assert
            Assert.Equal(accessPointDtos, result);
            _mockRepository.Verify(r => r.GetAllAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnMappedAccessPoint_WhenAccessPointExists()
        {
            // Arrange
            int accessPointId = 1;
            var accessPoint = new AccessPoint 
            { 
                Id = accessPointId, 
                Name = "Главный вход", 
                AccessPointTypeId = 1, 
                IsActive = true 
            };
            
            var accessPointDto = new AccessPointDto 
            { 
                Id = accessPointId, 
                Name = "Главный вход", 
                AccessPointTypeId = 1, 
                IsActive = true 
            };

            _mockRepository.Setup(r => r.GetByIdAsync(accessPointId, It.IsAny<CancellationToken>())).ReturnsAsync(accessPoint);
            _mockMapper.Setup(m => m.Map<AccessPointDto>(accessPoint)).Returns(accessPointDto);

            // Act
            var result = await _service.GetByIdAsync(accessPointId);

            // Assert
            Assert.Equal(accessPointDto, result);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldThrowNotFoundException_WhenAccessPointDoesNotExist()
        {
            // Arrange
            int accessPointId = 999;
            
            _mockRepository.Setup(r => r.GetByIdAsync(accessPointId, It.IsAny<CancellationToken>())).ReturnsAsync((AccessPoint)null);

            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _service.GetByIdAsync(accessPointId));
        }
    }
} 