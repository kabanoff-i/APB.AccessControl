using APB.AccessControl.Application.Filters;
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
    public class EmployeeServiceTests
    {
        private readonly Mock<IEmployeeRepository> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<ILogger<EmployeeService>> _mockLogger;
        private readonly EmployeeService _service;

        public EmployeeServiceTests()
        {
            _mockRepository = new Mock<IEmployeeRepository>();
            _mockMapper = new Mock<IMapper>();
            _mockLogger = new Mock<ILogger<EmployeeService>>();
            
            _service = new EmployeeService(
                _mockRepository.Object,
                _mockMapper.Object,
                _mockLogger.Object);
        }

        [Fact]
        public async Task CreateAsync_ShouldReturnMappedEmployee_WhenCreationSucceeds()
        {
            // Arrange
            var createRequest = new CreateEmployeeReq 
            { 
                FirstName = "Иван", 
                LastName = "Иванов" 
            };
            
            var employee = new Employee 
            { 
                FirstName = "Иван", 
                LastName = "Иванов",
                Id = 1
            };
            
            var employeeDto = new EmployeeDto
            {
                Id = 1,
                FirstName = "Иван",
                LastName = "Иванов"
            };

            _mockMapper.Setup(m => m.Map<Employee>(createRequest)).Returns(employee);
            _mockRepository.Setup(r => r.AddAsync(employee, It.IsAny<CancellationToken>())).ReturnsAsync(employee);
            _mockMapper.Setup(m => m.Map<EmployeeDto>(employee)).Returns(employeeDto);

            // Act
            var result = await _service.CreateAsync(createRequest);

            // Assert
            Assert.Equal(employeeDto, result);
            _mockRepository.Verify(r => r.AddAsync(employee, It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_ShouldCallRepositoryUpdateAsync_WhenEmployeeExists()
        {
            // Arrange
            var updateRequest = new UpdateEmployeeReq 
            { 
                Id = 1, 
                FirstName = "Петр", 
                LastName = "Петров" 
            };
            
            var employee = new Employee 
            { 
                Id = 1, 
                FirstName = "Петр", 
                LastName = "Петров" 
            };

            _mockRepository.Setup(r => r.ExistsAsync(1, It.IsAny<CancellationToken>())).ReturnsAsync(true);
            _mockMapper.Setup(m => m.Map<Employee>(updateRequest)).Returns(employee);

            // Act
            await _service.UpdateAsync(updateRequest);

            // Assert
            _mockRepository.Verify(r => r.UpdateAsync(employee, It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_ShouldThrowNotFoundException_WhenEmployeeDoesNotExist()
        {
            // Arrange
            var updateRequest = new UpdateEmployeeReq { Id = 999 };
            
            _mockRepository.Setup(r => r.ExistsAsync(999, It.IsAny<CancellationToken>())).ReturnsAsync(false);

            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _service.UpdateAsync(updateRequest));
            _mockRepository.Verify(r => r.UpdateAsync(It.IsAny<Employee>(), It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact]
        public async Task DeleteAsync_ShouldCallRepositoryDeleteAsync_WhenEmployeeExists()
        {
            // Arrange
            int employeeId = 1;
            
            _mockRepository.Setup(r => r.ExistsAsync(employeeId, It.IsAny<CancellationToken>())).ReturnsAsync(true);

            // Act
            await _service.DeleteAsync(employeeId);

            // Assert
            _mockRepository.Verify(r => r.DeleteAsync(employeeId, It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_ShouldThrowNotFoundException_WhenEmployeeDoesNotExist()
        {
            // Arrange
            int employeeId = 999;
            
            _mockRepository.Setup(r => r.ExistsAsync(employeeId, It.IsAny<CancellationToken>())).ReturnsAsync(false);

            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _service.DeleteAsync(employeeId));
            _mockRepository.Verify(r => r.DeleteAsync(employeeId, It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnMappedEmployees()
        {
            // Arrange
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

            _mockRepository.Setup(r => r.GetAllAsync(It.IsAny<CancellationToken>())).ReturnsAsync(employees);
            _mockMapper.Setup(m => m.Map<IEnumerable<EmployeeDto>>(employees)).Returns(employeeDtos);

            // Act
            var result = await _service.GetAllAsync();

            // Assert
            Assert.Equal(employeeDtos, result);
            _mockRepository.Verify(r => r.GetAllAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task GetEmployeeByIdAsync_ShouldReturnMappedEmployee_WhenEmployeeExists()
        {
            // Arrange
            int employeeId = 1;
            var employee = new Employee { Id = employeeId, FirstName = "Иван", LastName = "Иванов" };
            var employeeDto = new EmployeeDto { Id = employeeId, FirstName = "Иван", LastName = "Иванов" };

            _mockRepository.Setup(r => r.GetByIdAsync(employeeId, It.IsAny<CancellationToken>())).ReturnsAsync(employee);
            _mockMapper.Setup(m => m.Map<EmployeeDto>(employee)).Returns(employeeDto);

            // Act
            var result = await _service.GetEmployeeByIdAsync(employeeId);

            // Assert
            Assert.Equal(employeeDto, result);
        }

        [Fact]
        public async Task GetEmployeeByIdAsync_ShouldThrowNotFoundException_WhenEmployeeDoesNotExist()
        {
            // Arrange
            int employeeId = 999;
            
            _mockRepository.Setup(r => r.GetByIdAsync(employeeId, It.IsAny<CancellationToken>())).ReturnsAsync((Employee)null);

            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _service.GetEmployeeByIdAsync(employeeId));
        }

        [Fact]
        public async Task GetEmployeesByFilterAsync_ShouldReturnMappedEmployees()
        {
            // Arrange
            var filter = new EmployeeFilter { Department = "IT" };
            var employees = new List<Employee>
            {
                new Employee { Id = 1, FirstName = "Иван", LastName = "Иванов", Department = "IT" }
            };
            
            var employeeDtos = new List<EmployeeDto>
            {
                new EmployeeDto { Id = 1, FirstName = "Иван", LastName = "Иванов" }
            };

            _mockRepository.Setup(r => r.GetByFilterAsync(filter, It.IsAny<CancellationToken>())).ReturnsAsync(employees);
            _mockMapper.Setup(m => m.Map<IEnumerable<EmployeeDto>>(employees)).Returns(employeeDtos);

            // Act
            var result = await _service.GetEmployeesByFilterAsync(filter);

            // Assert
            Assert.Equal(employeeDtos, result);
            _mockRepository.Verify(r => r.GetByFilterAsync(filter, It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task GetEmployeeByCardIdAsync_ShouldReturnMappedEmployee_WhenEmployeeExists()
        {
            // Arrange
            int cardId = 1;
            var employee = new Employee { Id = 1, FirstName = "Иван", LastName = "Иванов" };
            var employeeDto = new EmployeeDto { Id = 1, FirstName = "Иван", LastName = "Иванов" };

            _mockRepository.Setup(r => r.GetByCardIdAsync(cardId, It.IsAny<CancellationToken>())).ReturnsAsync(employee);
            _mockMapper.Setup(m => m.Map<EmployeeDto>(employee)).Returns(employeeDto);

            // Act
            var result = await _service.GetEmployeeByCardIdAsync(cardId);

            // Assert
            Assert.Equal(employeeDto, result);
        }

        [Fact]
        public async Task GetEmployeeByCardIdAsync_ShouldThrowNotFoundException_WhenEmployeeDoesNotExist()
        {
            // Arrange
            int cardId = 999;
            
            _mockRepository.Setup(r => r.GetByCardIdAsync(cardId, It.IsAny<CancellationToken>())).ReturnsAsync((Employee)null);

            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _service.GetEmployeeByCardIdAsync(cardId));
        }
    }
} 