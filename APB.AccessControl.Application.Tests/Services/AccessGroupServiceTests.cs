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
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace APB.AccessControl.Application.Tests.Services
{
    public class AccessGroupServiceTests
    {
        private readonly Mock<IAccessGroupRepository> _mockAccessGroupRepository;
        private readonly Mock<IEmployeeRepository> _mockEmployeeRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<ILogger<AccessGroupService>> _mockLogger;
        private readonly AccessGroupService _service;

        public AccessGroupServiceTests()
        {
            _mockAccessGroupRepository = new Mock<IAccessGroupRepository>();
            _mockEmployeeRepository = new Mock<IEmployeeRepository>();
            _mockMapper = new Mock<IMapper>();
            _mockLogger = new Mock<ILogger<AccessGroupService>>();
            
            _service = new AccessGroupService(
                _mockAccessGroupRepository.Object,
                _mockMapper.Object,
                _mockEmployeeRepository.Object,
                _mockLogger.Object);
        }

        [Fact]
        public async Task CreateAsync_ShouldReturnMappedAccessGroup_WhenCreationSucceeds()
        {
            // Arrange
            var createRequest = new CreateGroupReq { Name = "Администраторы" };
            
            var accessGroup = new AccessGroup
            { 
                Id = 1,
                Name = "Администраторы",
                IsActive = true
            };
            
            var accessGroupDto = new AccessGroupDto
            {
                Id = "1",
                Name = "Администраторы",
                IsActive = true
            };

            _mockMapper.Setup(m => m.Map<AccessGroup>(createRequest)).Returns(accessGroup);
            _mockAccessGroupRepository.Setup(r => r.AddAsync(accessGroup, It.IsAny<CancellationToken>())).ReturnsAsync(accessGroup);
            _mockMapper.Setup(m => m.Map<AccessGroupDto>(accessGroup)).Returns(accessGroupDto);

            // Act
            var result = await _service.CreateAsync(createRequest);

            // Assert
            Assert.Equal(accessGroupDto, result);
            _mockAccessGroupRepository.Verify(r => r.AddAsync(accessGroup, It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_ShouldCallRepositoryUpdateAsync_WhenAccessGroupExists()
        {
            // Arrange
            var updateRequest = new UpdateGroupReq
            { 
                Id = 1, 
                Name = "Обновленная группа",
                IsActive = true
            };
            
            var accessGroup = new AccessGroup
            { 
                Id = 1, 
                Name = "Обновленная группа",
                IsActive = true
            };

            _mockAccessGroupRepository.Setup(r => r.ExistsAsync(1, It.IsAny<CancellationToken>())).ReturnsAsync(true);
            _mockMapper.Setup(m => m.Map<AccessGroup>(updateRequest)).Returns(accessGroup);

            // Act
            await _service.UpdateAsync(updateRequest);

            // Assert
            _mockAccessGroupRepository.Verify(r => r.UpdateAsync(accessGroup, It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_ShouldThrowNotFoundException_WhenAccessGroupDoesNotExist()
        {
            // Arrange
            var updateRequest = new UpdateGroupReq { Id = 999 };
            
            _mockAccessGroupRepository.Setup(r => r.ExistsAsync(999, It.IsAny<CancellationToken>())).ReturnsAsync(false);

            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _service.UpdateAsync(updateRequest));
            _mockAccessGroupRepository.Verify(r => r.UpdateAsync(It.IsAny<AccessGroup>(), It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact]
        public async Task DeleteAsync_ShouldCallRepositoryDeleteAsync_WhenAccessGroupExists()
        {
            // Arrange
            int groupId = 1;
            
            _mockAccessGroupRepository.Setup(r => r.ExistsAsync(groupId, It.IsAny<CancellationToken>())).ReturnsAsync(true);

            // Act
            await _service.DeleteAsync(groupId);

            // Assert
            _mockAccessGroupRepository.Verify(r => r.DeleteAsync(groupId, It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_ShouldThrowNotFoundException_WhenAccessGroupDoesNotExist()
        {
            // Arrange
            int groupId = 999;
            
            _mockAccessGroupRepository.Setup(r => r.ExistsAsync(groupId, It.IsAny<CancellationToken>())).ReturnsAsync(false);

            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _service.DeleteAsync(groupId));
            _mockAccessGroupRepository.Verify(r => r.DeleteAsync(groupId, It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnMappedAccessGroups()
        {
            // Arrange
            var accessGroups = new List<AccessGroup>
            {
                new AccessGroup { Id = 1, Name = "Администраторы", IsActive = true },
                new AccessGroup { Id = 2, Name = "Пользователи", IsActive = true }
            };
            
            var accessGroupDtos = new List<AccessGroupDto>
            {
                new AccessGroupDto { Id = "1", Name = "Администраторы", IsActive = true },
                new AccessGroupDto { Id = "2", Name = "Пользователи", IsActive = true }
            };

            _mockAccessGroupRepository.Setup(r => r.GetAllAsync(It.IsAny<CancellationToken>())).ReturnsAsync(accessGroups);
            _mockMapper.Setup(m => m.Map<IEnumerable<AccessGroupDto>>(accessGroups)).Returns(accessGroupDtos);

            // Act
            var result = await _service.GetAllAsync();

            // Assert
            Assert.Equal(accessGroupDtos, result);
            _mockAccessGroupRepository.Verify(r => r.GetAllAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task AddEmployeeToGroupAsync_ShouldCallRepositoryAssignEmployeeToGroupAsync_WhenBothExist()
        {
            // Arrange
            var request = new AddEmployeeToGroupReq { EmployeeId = 1, GroupId = 1 };
            
            _mockAccessGroupRepository.Setup(r => r.ExistsAsync(1, It.IsAny<CancellationToken>())).ReturnsAsync(true);
            _mockEmployeeRepository.Setup(r => r.ExistsAsync(1, It.IsAny<CancellationToken>())).ReturnsAsync(true);

            // Act
            await _service.AddEmployeeToGroupAsync(request);

            // Assert
            _mockAccessGroupRepository.Verify(r => r.AssignEmployeeToGroupAsync(
                request.EmployeeId, request.GroupId, It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task AddEmployeeToGroupAsync_ShouldThrowNotFoundException_WhenGroupDoesNotExist()
        {
            // Arrange
            var request = new AddEmployeeToGroupReq { EmployeeId = 1, GroupId = 999 };
            
            _mockAccessGroupRepository.Setup(r => r.ExistsAsync(999, It.IsAny<CancellationToken>())).ReturnsAsync(false);
            _mockEmployeeRepository.Setup(r => r.ExistsAsync(1, It.IsAny<CancellationToken>())).ReturnsAsync(true);

            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _service.AddEmployeeToGroupAsync(request));
            _mockAccessGroupRepository.Verify(r => r.AssignEmployeeToGroupAsync(
                It.IsAny<int>(), It.IsAny<int>(), It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact]
        public async Task AddEmployeeToGroupAsync_ShouldThrowNotFoundException_WhenEmployeeDoesNotExist()
        {
            // Arrange
            var request = new AddEmployeeToGroupReq { EmployeeId = 999, GroupId = 1 };
            
            _mockAccessGroupRepository.Setup(r => r.ExistsAsync(1, It.IsAny<CancellationToken>())).ReturnsAsync(true);
            _mockEmployeeRepository.Setup(r => r.ExistsAsync(999, It.IsAny<CancellationToken>())).ReturnsAsync(false);

            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _service.AddEmployeeToGroupAsync(request));
            _mockAccessGroupRepository.Verify(r => r.AssignEmployeeToGroupAsync(
                It.IsAny<int>(), It.IsAny<int>(), It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact]
        public async Task GetEmployeesInGroupAsync_ShouldReturnMappedEmployees_WhenGroupExists()
        {
            // Arrange
            int groupId = 1;
            var employees = new List<Employee>
            {
                new Employee { Id = 1, FirstName = "Иван", LastName = "Иванов" },
                new Employee { Id = 2, FirstName = "Петр", LastName = "Петров" }
            };
            
            var employeeDtos = new List<EmployeeDto>
            {
                new EmployeeDto { Id = 1, FirstName = "Иван", LastName = "Иванов" },
                new EmployeeDto { Id = 2, FirstName = "Петр", LastName = "Петров" }
            };

            _mockAccessGroupRepository.Setup(r => r.ExistsAsync(groupId, It.IsAny<CancellationToken>())).ReturnsAsync(true);
            _mockAccessGroupRepository.Setup(r => r.GetEmployeesByGroupIdAsync(groupId, It.IsAny<CancellationToken>())).ReturnsAsync(employees);
            _mockMapper.Setup(m => m.Map<IEnumerable<EmployeeDto>>(employees)).Returns(employeeDtos);

            // Act
            var result = await _service.GetEmployeesInGroupAsync(groupId);

            // Assert
            Assert.Equal(employeeDtos, result);
            _mockAccessGroupRepository.Verify(r => r.GetEmployeesByGroupIdAsync(groupId, It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task GetEmployeesInGroupAsync_ShouldThrowNotFoundException_WhenGroupDoesNotExist()
        {
            // Arrange
            int groupId = 999;
            
            _mockAccessGroupRepository.Setup(r => r.ExistsAsync(groupId, It.IsAny<CancellationToken>())).ReturnsAsync(false);

            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _service.GetEmployeesInGroupAsync(groupId));
            _mockAccessGroupRepository.Verify(r => r.GetEmployeesByGroupIdAsync(groupId, It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact]
        public async Task RemoveEmployeeFromGroupAsync_ShouldCallRepositoryRemoveEmployeeFromGroupAsync_WhenBothExist()
        {
            // Arrange
            var request = new RemoveEmployeeFromGroupReq { EmployeeId = 1, GroupId = 1 };
            
            _mockAccessGroupRepository.Setup(r => r.ExistsAsync(1, It.IsAny<CancellationToken>())).ReturnsAsync(true);
            _mockEmployeeRepository.Setup(r => r.ExistsAsync(1, It.IsAny<CancellationToken>())).ReturnsAsync(true);

            // Act
            await _service.RemoveEmployeeFromGroupAsync(request);

            // Assert
            _mockAccessGroupRepository.Verify(r => r.RemoveEmployeeFromGroupAsync(
                request.EmployeeId, request.GroupId, It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task RemoveEmployeeFromGroupAsync_ShouldThrowNotFoundException_WhenGroupDoesNotExist()
        {
            // Arrange
            var request = new RemoveEmployeeFromGroupReq { EmployeeId = 1, GroupId = 999 };
            
            _mockAccessGroupRepository.Setup(r => r.ExistsAsync(999, It.IsAny<CancellationToken>())).ReturnsAsync(false);
            _mockEmployeeRepository.Setup(r => r.ExistsAsync(1, It.IsAny<CancellationToken>())).ReturnsAsync(true);

            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _service.RemoveEmployeeFromGroupAsync(request));
            _mockAccessGroupRepository.Verify(r => r.RemoveEmployeeFromGroupAsync(
                It.IsAny<int>(), It.IsAny<int>(), It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact]
        public async Task RemoveEmployeeFromGroupAsync_ShouldThrowNotFoundException_WhenEmployeeDoesNotExist()
        {
            // Arrange
            var request = new RemoveEmployeeFromGroupReq { EmployeeId = 999, GroupId = 1 };
            
            _mockAccessGroupRepository.Setup(r => r.ExistsAsync(1, It.IsAny<CancellationToken>())).ReturnsAsync(true);
            _mockEmployeeRepository.Setup(r => r.ExistsAsync(999, It.IsAny<CancellationToken>())).ReturnsAsync(false);

            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _service.RemoveEmployeeFromGroupAsync(request));
            _mockAccessGroupRepository.Verify(r => r.RemoveEmployeeFromGroupAsync(
                It.IsAny<int>(), It.IsAny<int>(), It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact]
        public async Task GetGroupIdByEmployeeIdAsync_ShouldReturnGroupIds_WhenEmployeeExists()
        {
            // Arrange
            int employeeId = 1;
            var groups = new List<AccessGroup>
            {
                new AccessGroup { Id = 1, Name = "Администраторы", IsActive = true },
                new AccessGroup { Id = 2, Name = "Пользователи", IsActive = true }
            };
            
            var expectedIds = new List<int> { 1, 2 };

            _mockEmployeeRepository.Setup(r => r.ExistsAsync(employeeId, It.IsAny<CancellationToken>())).ReturnsAsync(true);
            _mockAccessGroupRepository.Setup(r => r.GetGroupsByEmployeeIdAsync(employeeId, It.IsAny<CancellationToken>())).ReturnsAsync(groups);

            // Act
            var result = await _service.GetGroupIdByEmployeeIdAsync(employeeId);

            // Assert
            Assert.Equal(expectedIds, result);
            _mockAccessGroupRepository.Verify(r => r.GetGroupsByEmployeeIdAsync(employeeId, It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task GetGroupIdByEmployeeIdAsync_ShouldThrowNotFoundException_WhenEmployeeDoesNotExist()
        {
            // Arrange
            int employeeId = 999;
            
            _mockEmployeeRepository.Setup(r => r.ExistsAsync(employeeId, It.IsAny<CancellationToken>())).ReturnsAsync(false);

            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _service.GetGroupIdByEmployeeIdAsync(employeeId));
            _mockAccessGroupRepository.Verify(r => r.GetGroupsByEmployeeIdAsync(employeeId, It.IsAny<CancellationToken>()), Times.Never);
        }
    }
} 