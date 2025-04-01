using APB.AccessControl.Application.Interfaces;
using APB.AccessControl.Application.Services;
using APB.AccessControl.Domain.Entities;
using APB.AccessControl.Domain.Exceptions;
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
    public class NotificationServiceTests
    {
        private readonly Mock<INotificationRepository> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<ILogger<NotificationService>> _mockLogger;
        private readonly NotificationService _service;

        public NotificationServiceTests()
        {
            _mockRepository = new Mock<INotificationRepository>();
            _mockMapper = new Mock<IMapper>();
            _mockLogger = new Mock<ILogger<NotificationService>>();
            
            _service = new NotificationService(
                _mockRepository.Object,
                _mockMapper.Object,
                _mockLogger.Object);
        }

        [Fact]
        public async Task CreateAsync_ShouldReturnMappedNotification_WhenCreationSucceeds()
        {
            // Arrange
            var createRequest = new CreateNotificationReq 
            { 
                AccessPointId = 1,
                Message = "Тестовое уведомление",
                ShowOnPass = true,
                EmployeeId = 1,
                ExpirationDate = DateTime.UtcNow.AddDays(1)
            };
            
            var notification = new Notification
            { 
                Id = 1,
                AccessPointId = 1,
                Message = "Тестовое уведомление",
                ShowOnPass = true,
                EmployeeId = 1,
                ExpirationDate = DateTime.UtcNow.AddDays(1),
                IsRead = false
            };
            
            var notificationDto = new NotificationDto
            {
                Id = notification.Id,
                AccessPointId = 1,
                Message = "Тестовое уведомление",
                ShowOnPass = true,
                EmployeeId = 1,
                ExpirationDate = notification.ExpirationDate,
                IsRead = false
            };

            _mockMapper.Setup(m => m.Map<Notification>(createRequest)).Returns(notification);
            _mockRepository.Setup(r => r.AddAsync(notification, It.IsAny<CancellationToken>())).ReturnsAsync(notification);
            _mockMapper.Setup(m => m.Map<NotificationDto>(notification)).Returns(notificationDto);

            // Act
            var result = await _service.CreateAsync(createRequest);

            // Assert
            Assert.Equal(notificationDto, result);
            _mockRepository.Verify(r => r.AddAsync(notification, It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_ShouldCallRepositoryUpdateAsync_WhenNotificationExists()
        {
            // Arrange
            var notificationId = 1;
            var updateRequest = new UpdateNotificationReq 
            { 
                Id = notificationId,
                AccessPointId = 1,
                Message = "Обновленное уведомление",
                ShowOnPass = true,
                EmployeeId = 1,
                ExpirationDate = DateTime.UtcNow.AddDays(2)
            };
            
            var notification = new Notification
            { 
                Id = notificationId,
                AccessPointId = 1,
                Message = "Обновленное уведомление",
                ShowOnPass = true,
                EmployeeId = 1,
                ExpirationDate = updateRequest.ExpirationDate,
                IsRead = false
            };

            _mockRepository.Setup(r => r.ExistsAsync(notificationId, It.IsAny<CancellationToken>())).ReturnsAsync(true);
            _mockMapper.Setup(m => m.Map<Notification>(updateRequest)).Returns(notification);

            // Act
            await _service.UpdateAsync(updateRequest);

            // Assert
            _mockRepository.Verify(r => r.UpdateAsync(notification, It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_ShouldThrowNotFoundException_WhenNotificationDoesNotExist()
        {
            // Arrange
            var notificationId = 1;
            var updateRequest = new UpdateNotificationReq { Id = notificationId };
            
            _mockRepository.Setup(r => r.ExistsAsync(notificationId, It.IsAny<CancellationToken>())).ReturnsAsync(false);

            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _service.UpdateAsync(updateRequest));
            _mockRepository.Verify(r => r.UpdateAsync(It.IsAny<Notification>(), It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact]
        public async Task DeleteAsync_ShouldCallRepositoryDeleteAsync_WhenNotificationExists()
        {
            // Arrange
            var notificationId = 1;
            
            _mockRepository.Setup(r => r.ExistsAsync(notificationId, It.IsAny<CancellationToken>())).ReturnsAsync(true);

            // Act
            await _service.DeleteAsync(notificationId);

            // Assert
            _mockRepository.Verify(r => r.DeleteAsync(notificationId, It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_ShouldThrowNotFoundException_WhenNotificationDoesNotExist()
        {
            // Arrange
            var notificationId = 1;
            
            _mockRepository.Setup(r => r.ExistsAsync(notificationId, It.IsAny<CancellationToken>())).ReturnsAsync(false);

            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _service.DeleteAsync(notificationId));
            _mockRepository.Verify(r => r.DeleteAsync(notificationId, It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnMappedNotifications()
        {
            // Arrange
            var notifications = new List<Notification>
            {
                new Notification 
                { 
                    Id = 1, 
                    AccessPointId = 1, 
                    Message = "Уведомление 1",
                    IsRead = false
                },
                new Notification 
                { 
                    Id = 2, 
                    AccessPointId = 2, 
                    Message = "Уведомление 2",
                    IsRead = true
                }
            };
            
            var notificationDtos = new List<NotificationDto>
            {
                new NotificationDto 
                { 
                    Id = notifications[0].Id, 
                    AccessPointId = 1, 
                    Message = "Уведомление 1",
                    IsRead = false
                },
                new NotificationDto 
                { 
                    Id = notifications[1].Id, 
                    AccessPointId = 2, 
                    Message = "Уведомление 2",
                    IsRead = true
                }
            };

            _mockRepository.Setup(r => r.GetAllAsync(It.IsAny<CancellationToken>())).ReturnsAsync(notifications);
            _mockMapper.Setup(m => m.Map<IEnumerable<NotificationDto>>(notifications)).Returns(notificationDtos);

            // Act
            var result = await _service.GetAllAsync();

            // Assert
            Assert.Equal(notificationDtos, result);
            _mockRepository.Verify(r => r.GetAllAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task GetNotificationsByAccessPointAsync_ShouldReturnMappedNotifications()
        {
            // Arrange
            int accessPointId = 1;
            var notifications = new List<Notification>
            {
                new Notification 
                { 
                    Id = 1, 
                    AccessPointId = accessPointId, 
                    Message = "Уведомление 1",
                    IsRead = false
                },
                new Notification 
                { 
                    Id = 2, 
                    AccessPointId = accessPointId, 
                    Message = "Уведомление 2",
                    IsRead = false
                }
            };
            
            var notificationDtos = new List<NotificationDto>
            {
                new NotificationDto 
                { 
                    Id = notifications[0].Id, 
                    AccessPointId = accessPointId, 
                    Message = "Уведомление 1",
                    IsRead = false
                },
                new NotificationDto 
                { 
                    Id = notifications[1].Id, 
                    AccessPointId = accessPointId, 
                    Message = "Уведомление 2",
                    IsRead = false
                }
            };

            _mockRepository.Setup(r => r.GetActiveNotificationsByAccessPointAsync(accessPointId, It.IsAny<CancellationToken>())).ReturnsAsync(notifications);
            _mockMapper.Setup(m => m.Map<IEnumerable<NotificationDto>>(notifications)).Returns(notificationDtos);

            // Act
            var result = await _service.GetNotificationsByAccessPointAsync(accessPointId);

            // Assert
            Assert.Equal(notificationDtos, result);
            _mockRepository.Verify(r => r.GetActiveNotificationsByAccessPointAsync(accessPointId, It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task GetNotificationsByEmployeeAsync_ShouldReturnMappedNotifications()
        {
            // Arrange
            int employeeId = 1;
            var notifications = new List<Notification>
            {
                new Notification 
                { 
                    Id = 1, 
                    EmployeeId = employeeId, 
                    Message = "Уведомление 1",
                    IsRead = false
                },
                new Notification 
                { 
                    Id = 2, 
                    EmployeeId = employeeId, 
                    Message = "Уведомление 2",
                    IsRead = false
                }
            };
            
            var notificationDtos = new List<NotificationDto>
            {
                new NotificationDto 
                { 
                    Id = notifications[0].Id, 
                    EmployeeId = employeeId, 
                    Message = "Уведомление 1",
                    IsRead = false
                },
                new NotificationDto 
                { 
                    Id = notifications[1].Id, 
                    EmployeeId = employeeId, 
                    Message = "Уведомление 2",
                    IsRead = false
                }
            };

            _mockRepository.Setup(r => r.GetActiveNotificationsByEmployeeAsync(employeeId, It.IsAny<CancellationToken>())).ReturnsAsync(notifications);
            _mockMapper.Setup(m => m.Map<IEnumerable<NotificationDto>>(notifications)).Returns(notificationDtos);

            // Act
            var result = await _service.GetNotificationsByEmployeeAsync(employeeId);

            // Assert
            Assert.Equal(notificationDtos, result);
            _mockRepository.Verify(r => r.GetActiveNotificationsByEmployeeAsync(employeeId, It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task ProcessNotificationAsync_ShouldMarkNotificationAsRead_WhenNotificationExists()
        {
            // Arrange
            var notificationId = 1;
            var notification = new Notification
            {
                Id = notificationId,
                AccessPointId = 1,
                Message = "Тестовое уведомление",
                IsRead = false
            };

            _mockRepository.Setup(r => r.GetByIdAsync(notificationId, It.IsAny<CancellationToken>())).ReturnsAsync(notification);

            // Act
            await _service.ProcessNotificationAsync(notificationId);

            // Assert
            Assert.True(notification.IsRead);
            _mockRepository.Verify(r => r.UpdateAsync(notification, It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task ProcessNotificationAsync_ShouldThrowNotFoundException_WhenNotificationDoesNotExist()
        {
            // Arrange
            var notificationId = 1;
            
            _mockRepository.Setup(r => r.GetByIdAsync(notificationId, It.IsAny<CancellationToken>())).ReturnsAsync((Notification)null);

            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _service.ProcessNotificationAsync(notificationId));
            _mockRepository.Verify(r => r.UpdateAsync(It.IsAny<Notification>(), It.IsAny<CancellationToken>()), Times.Never);
        }
    }
} 