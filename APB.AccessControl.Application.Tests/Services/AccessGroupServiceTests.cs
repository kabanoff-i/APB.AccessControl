using APB.AccessControl.Application.Interfaces;
using APB.AccessControl.Application.Services;
using APB.AccessControl.Application.Validators;
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
using Xunit;

namespace APB.AccessControl.Application.Tests.Services
{
    public class AccessGroupServiceTests
    {
        private readonly Mock<IAccessGroupRepository> _mockAccessGroupRepository;
        private readonly Mock<IEmployeeRepository> _mockEmployeeRepository;
        private readonly Mock<IAccessGridRepository> _mockAccessGridRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<ILogger<AccessGroupService>> _mockLogger;
        private readonly AccessGroupValidator _validator;
        private readonly AccessGroupService _service;

        public AccessGroupServiceTests()
        {
            _mockAccessGroupRepository = new Mock<IAccessGroupRepository>();
            _mockEmployeeRepository = new Mock<IEmployeeRepository>();
            _mockAccessGridRepository = new Mock<IAccessGridRepository>();
            _mockMapper = new Mock<IMapper>();
            _mockLogger = new Mock<ILogger<AccessGroupService>>();
            _validator = new AccessGroupValidator();
            
            _service = new AccessGroupService(
                _mockAccessGroupRepository.Object,
                _mockMapper.Object,
                _mockEmployeeRepository.Object,
                _mockAccessGridRepository.Object,
                _mockLogger.Object,
                _validator);
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
                Id = 1,
                Name = "Администраторы",
                IsActive = true
            };

            _mockMapper.Setup(m => m.Map<AccessGroup>(createRequest)).Returns(accessGroup);
            _mockAccessGroupRepository.Setup(r => r.AddAsync(accessGroup, It.IsAny<CancellationToken>())).ReturnsAsync(accessGroup);
            _mockMapper.Setup(m => m.Map<AccessGroupDto>(accessGroup)).Returns(accessGroupDto);

            // Act
            var result = await _service.CreateAsync(createRequest);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(accessGroupDto.Id, result.Id);
            Assert.Equal(accessGroupDto.Name, result.Name);
            Assert.Equal(accessGroupDto.IsActive, result.IsActive);
            _mockAccessGroupRepository.Verify(r => r.AddAsync(accessGroup, It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task CreateAsync_ShouldThrowException_WhenRepositoryThrowsException()
        {
            // Arrange
            var createRequest = new CreateGroupReq { Name = "Администраторы" };
            var accessGroup = new AccessGroup { Name = "Администраторы" };

            _mockMapper.Setup(m => m.Map<AccessGroup>(createRequest)).Returns(accessGroup);
            _mockAccessGroupRepository.Setup(r => r.AddAsync(accessGroup, It.IsAny<CancellationToken>()))
                .ThrowsAsync(new System.Exception("Database error"));

            // Act & Assert
            await Assert.ThrowsAsync<System.Exception>(() => _service.CreateAsync(createRequest));
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
            _mockAccessGroupRepository.Verify(r => r.UpdateAsync(It.Is<AccessGroup>(ag => 
                ag.Id == accessGroup.Id && 
                ag.Name == accessGroup.Name && 
                ag.IsActive == accessGroup.IsActive), 
                It.IsAny<CancellationToken>()), 
                Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_ShouldThrowNotFoundException_WhenAccessGroupDoesNotExist()
        {
            // Arrange
            var updateRequest = new UpdateGroupReq { Id = 999 };
            
            _mockAccessGroupRepository.Setup(r => r.ExistsAsync(999, It.IsAny<CancellationToken>())).ReturnsAsync(false);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<NotFoundException>(() => _service.UpdateAsync(updateRequest));
            Assert.Contains("999", exception.Message);
            _mockAccessGroupRepository.Verify(r => r.UpdateAsync(It.IsAny<AccessGroup>(), It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact]
        public async Task DeleteAsync_ShouldCallRepositoryDeleteAsync_WhenAccessGroupExists()
        {
            // Arrange
            int groupId = 1;
            var group = new AccessGroup { Id = groupId };
            
            _mockAccessGroupRepository.Setup(r => r.GetByIdAsync(groupId, It.IsAny<CancellationToken>())).ReturnsAsync(group);

            // Act
            await _service.DeleteAsync(groupId);

            // Assert
            _mockAccessGroupRepository.Verify(r => r.DeleteAsync(It.Is<AccessGroup>(g => g.Id == groupId), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_ShouldThrowNotFoundException_WhenAccessGroupDoesNotExist()
        {
            // Arrange
            int groupId = 999;
            
            _mockAccessGroupRepository.Setup(r => r.GetByIdAsync(groupId, It.IsAny<CancellationToken>())).ReturnsAsync((AccessGroup)null);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<NotFoundException>(() => _service.DeleteAsync(groupId));
            Assert.Contains("999", exception.Message);
            _mockAccessGroupRepository.Verify(r => r.DeleteAsync(It.IsAny<AccessGroup>(), It.IsAny<CancellationToken>()), Times.Never);
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
                new AccessGroupDto { Id = 1, Name = "Администраторы", IsActive = true },
                new AccessGroupDto { Id = 2, Name = "Пользователи", IsActive = true }
            };

            _mockAccessGroupRepository.Setup(r => r.GetAllAsync(It.IsAny<CancellationToken>())).ReturnsAsync(accessGroups);
            _mockMapper.Setup(m => m.Map<IEnumerable<AccessGroupDto>>(accessGroups)).Returns(accessGroupDtos);

            // Act
            var result = await _service.GetAllAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            Assert.Equal(accessGroupDtos.First().Id, result.First().Id);
            Assert.Equal(accessGroupDtos.Last().Id, result.Last().Id);
            _mockAccessGroupRepository.Verify(r => r.GetAllAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task AddEmployeeToGroupAsync_ShouldCallRepositoryAssignEmployeeToGroupAsync_WhenBothExist()
        {
            // Arrange
            var request = new AddEmployeeToGroupReq { EmployeeId = 1, AccessGroupId = 1 };
            
            _mockAccessGroupRepository.Setup(r => r.ExistsAsync(1, It.IsAny<CancellationToken>())).ReturnsAsync(true);
            _mockEmployeeRepository.Setup(r => r.ExistsAsync(1, It.IsAny<CancellationToken>())).ReturnsAsync(true);
            
            var accessGrid = new AccessGrid { 
                EmployeeId = request.EmployeeId, 
                AccessGroupId = request.AccessGroupId, 
                IsActive = true 
            };

            _mockAccessGridRepository
                .Setup(r => r.AddAsync(
                    It.Is<AccessGrid>(ag => 
                        ag.EmployeeId == request.EmployeeId && 
                        ag.AccessGroupId == request.AccessGroupId && 
                        ag.IsActive == true),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(accessGrid);

            // Act
            await _service.AddEmployeeToGroupAsync(request);

            // Assert
            _mockAccessGridRepository.Verify(r => r.AddAsync(
                It.Is<AccessGrid>(ag => 
                    ag.EmployeeId == request.EmployeeId && 
                    ag.AccessGroupId == request.AccessGroupId && 
                    ag.IsActive == true),
                It.IsAny<CancellationToken>()), 
                Times.Once);
        }

        [Fact]
        public async Task AddEmployeeToGroupAsync_ShouldThrowNotFoundException_WhenGroupDoesNotExist()
        {
            // Arrange
            var request = new AddEmployeeToGroupReq { EmployeeId = 1, AccessGroupId = 999 };
            
            _mockAccessGroupRepository.Setup(r => r.ExistsAsync(999, It.IsAny<CancellationToken>())).ReturnsAsync(false);
            _mockEmployeeRepository.Setup(r => r.ExistsAsync(1, It.IsAny<CancellationToken>())).ReturnsAsync(true);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<NotFoundException>(() => _service.AddEmployeeToGroupAsync(request));
            Assert.Contains("999", exception.Message);
            _mockAccessGridRepository.Verify(r => r.AddAsync(It.IsAny<AccessGrid>(), It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact]
        public async Task AddEmployeeToGroupAsync_ShouldThrowNotFoundException_WhenEmployeeDoesNotExist()
        {
            // Arrange
            var request = new AddEmployeeToGroupReq { EmployeeId = 999, AccessGroupId = 1 };
            
            _mockAccessGroupRepository.Setup(r => r.ExistsAsync(1, It.IsAny<CancellationToken>())).ReturnsAsync(true);
            _mockEmployeeRepository.Setup(r => r.ExistsAsync(999, It.IsAny<CancellationToken>())).ReturnsAsync(false);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<NotFoundException>(() => _service.AddEmployeeToGroupAsync(request));
            Assert.Contains("999", exception.Message);
            _mockAccessGridRepository.Verify(r => r.AddAsync(It.IsAny<AccessGrid>(), It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact]
        public async Task GetEmployeesInGroupAsync_ShouldReturnMappedEmployees_WhenGroupExists()
        {
            // Arrange
            int groupId = 1;
            var accessGrids = new List<AccessGrid>
            {
                new AccessGrid { EmployeeId = 1, AccessGroupId = groupId, IsActive = true },
                new AccessGrid { EmployeeId = 2, AccessGroupId = groupId, IsActive = true }
            };
            
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
            _mockAccessGridRepository.Setup(r => r.GetByAccessGroupIdAsync(groupId, It.IsAny<CancellationToken>())).ReturnsAsync(accessGrids);
            _mockEmployeeRepository.Setup(r => r.GetByIdAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((int id, CancellationToken token) => employees.FirstOrDefault(e => e.Id == id));
            _mockMapper.Setup(m => m.Map<EmployeeDto>(It.IsAny<Employee>()))
                .Returns((Employee e) => employeeDtos.FirstOrDefault(dto => dto.Id == e.Id));

            // Act
            var result = await _service.GetEmployeesInGroupAsync(groupId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            Assert.Equal(employeeDtos.First().Id, result.First().Id);
            Assert.Equal(employeeDtos.Last().Id, result.Last().Id);
            _mockAccessGridRepository.Verify(r => r.GetByAccessGroupIdAsync(groupId, It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task GetEmployeesInGroupAsync_ShouldThrowNotFoundException_WhenGroupDoesNotExist()
        {
            // Arrange
            int groupId = 999;
            
            _mockAccessGroupRepository.Setup(r => r.ExistsAsync(groupId, It.IsAny<CancellationToken>())).ReturnsAsync(false);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<NotFoundException>(() => _service.GetEmployeesInGroupAsync(groupId));
            Assert.Contains("999", exception.Message);
            _mockAccessGridRepository.Verify(r => r.GetByAccessGroupIdAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact]
        public async Task RemoveEmployeeFromGroupAsync_ShouldCallRepositoryRemoveEmployeeFromGroupAsync_WhenBothExist()
        {
            // Arrange
            var request = new RemoveEmployeeFromGroupReq { EmployeeId = 1, AccessGroupId = 1 };
            
            _mockAccessGroupRepository.Setup(r => r.ExistsAsync(1, It.IsAny<CancellationToken>())).ReturnsAsync(true);
            _mockEmployeeRepository.Setup(r => r.ExistsAsync(1, It.IsAny<CancellationToken>())).ReturnsAsync(true);
            
            var accessGrid = new AccessGrid { 
                EmployeeId = request.EmployeeId, 
                AccessGroupId = request.AccessGroupId, 
                IsActive = true 
            };

            _mockAccessGridRepository
                .Setup(r => r.GetByIdAsync(
                    request.EmployeeId,
                    request.AccessGroupId,
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(accessGrid);

            // Act
            await _service.RemoveEmployeeFromGroupAsync(request);

            // Assert
            _mockAccessGridRepository.Verify(r => r.DeleteAsync(
                It.Is<AccessGrid>(ag => 
                    ag.EmployeeId == request.EmployeeId && 
                    ag.AccessGroupId == request.AccessGroupId),
                It.IsAny<CancellationToken>()), 
                Times.Once);
        }

        [Fact]
        public async Task RemoveEmployeeFromGroupAsync_ShouldThrowNotFoundException_WhenGroupDoesNotExist()
        {
            // Arrange
            var request = new RemoveEmployeeFromGroupReq { EmployeeId = 1, AccessGroupId = 999 };
            
            _mockAccessGroupRepository.Setup(r => r.ExistsAsync(999, It.IsAny<CancellationToken>())).ReturnsAsync(false);
            _mockEmployeeRepository.Setup(r => r.ExistsAsync(1, It.IsAny<CancellationToken>())).ReturnsAsync(true);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<NotFoundException>(() => _service.RemoveEmployeeFromGroupAsync(request));
            Assert.Contains("999", exception.Message);
            _mockAccessGridRepository.Verify(r => r.DeleteAsync(It.IsAny<AccessGrid>(), It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact]
        public async Task RemoveEmployeeFromGroupAsync_ShouldThrowNotFoundException_WhenEmployeeDoesNotExist()
        {
            // Arrange
            var request = new RemoveEmployeeFromGroupReq { EmployeeId = 999, AccessGroupId = 1 };
            
            _mockAccessGroupRepository.Setup(r => r.ExistsAsync(1, It.IsAny<CancellationToken>())).ReturnsAsync(true);
            _mockEmployeeRepository.Setup(r => r.ExistsAsync(999, It.IsAny<CancellationToken>())).ReturnsAsync(false);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<NotFoundException>(() => _service.RemoveEmployeeFromGroupAsync(request));
            Assert.Contains("999", exception.Message);
            _mockAccessGridRepository.Verify(r => r.DeleteAsync(It.IsAny<AccessGrid>(), It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact]
        public async Task GetByEmployeeIdAsync_ShouldReturnGroups_WhenEmployeeExists()
        {
            // Arrange
            int employeeId = 1;
            var accessGrids = new List<AccessGrid>
            {
                new AccessGrid { EmployeeId = employeeId, AccessGroupId = 1, IsActive = true },
                new AccessGrid { EmployeeId = employeeId, AccessGroupId = 2, IsActive = true }
            };
            
            var accessGroups = new List<AccessGroup>
            {
                new AccessGroup { Id = 1, Name = "Администраторы", IsActive = true },
                new AccessGroup { Id = 2, Name = "Пользователи", IsActive = true }
            };

            var accessGroupDtos = new List<AccessGroupDto>
            {
                new AccessGroupDto { Id = 1, Name = "Администраторы", IsActive = true },
                new AccessGroupDto { Id = 2, Name = "Пользователи", IsActive = true }
            };

            _mockEmployeeRepository.Setup(r => r.ExistsAsync(employeeId, It.IsAny<CancellationToken>())).ReturnsAsync(true);
            _mockAccessGridRepository.Setup(r => r.GetByEmployeeIdAsync(employeeId, It.IsAny<CancellationToken>())).ReturnsAsync(accessGrids);
            _mockAccessGroupRepository.Setup(r => r.GetByIdAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((int id, CancellationToken token) => accessGroups.FirstOrDefault(g => g.Id == id));
            _mockMapper.Setup(m => m.Map<AccessGroupDto>(It.IsAny<AccessGroup>()))
                .Returns((AccessGroup g) => accessGroupDtos.FirstOrDefault(dto => dto.Id == g.Id));

            // Act
            var result = await _service.GetByEmployeeIdAsync(employeeId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            Assert.Equal(accessGroupDtos.First().Id, result.First().Id);
            Assert.Equal(accessGroupDtos.Last().Id, result.Last().Id);
            _mockAccessGridRepository.Verify(r => r.GetByEmployeeIdAsync(employeeId, It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task GetByEmployeeIdAsync_ShouldThrowNotFoundException_WhenEmployeeDoesNotExist()
        {
            // Arrange
            int employeeId = 999;
            
            _mockEmployeeRepository.Setup(r => r.ExistsAsync(employeeId, It.IsAny<CancellationToken>())).ReturnsAsync(false);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<NotFoundException>(() => _service.GetByEmployeeIdAsync(employeeId));
            Assert.Contains("999", exception.Message);
            _mockAccessGridRepository.Verify(r => r.GetByEmployeeIdAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()), Times.Never);
        }
    }
} 