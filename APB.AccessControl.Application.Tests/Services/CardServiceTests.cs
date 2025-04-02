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
    public class CardServiceTests
    {
        private readonly Mock<ICardRepository> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<ILogger<CardService>> _mockLogger;
        private readonly CardService _service;

        public CardServiceTests()
        {
            _mockRepository = new Mock<ICardRepository>();
            _mockMapper = new Mock<IMapper>();
            _mockLogger = new Mock<ILogger<CardService>>();
            
            _service = new CardService(
                _mockRepository.Object,
                _mockMapper.Object,
                _mockLogger.Object);
        }

        [Fact]
        public async Task CreateAsync_ShouldReturnMappedCard_WhenCreationSucceeds()
        {
            // Arrange
            var createRequest = new CreateCardReq 
            { 
                EmployeeId = 1,
                Hash = "TestHash"
            };
            
            var card = new Card
            { 
                EmployeeId = 1,
                Hash = "TestHash",
                Id = 1,
                IsActive = true
            };
            
            var cardDto = new CardDto
            {
                Id = 1,
                EmployeeId = 1,
                IsActive = true
            };

            _mockMapper.Setup(m => m.Map<Card>(createRequest)).Returns(card);
            _mockRepository.Setup(r => r.AddAsync(card, It.IsAny<CancellationToken>())).ReturnsAsync(card);
            _mockMapper.Setup(m => m.Map<CardDto>(card)).Returns(cardDto);

            // Act
            var result = await _service.CreateAsync(createRequest);

            // Assert
            Assert.Equal(cardDto, result);
            _mockRepository.Verify(r => r.AddAsync(card, It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_ShouldCallRepositoryUpdateAsync_WhenCardExists()
        {
            // Arrange
            var updateRequest = new UpdateCardReq 
            { 
                Id = 1, 
                IsActive = false
            };
            
            var card = new Card 
            { 
                Id = 1, 
                EmployeeId = 2,
                IsActive = false
            };

            _mockRepository.Setup(r => r.ExistsAsync(1, It.IsAny<CancellationToken>())).ReturnsAsync(true);
            _mockMapper.Setup(m => m.Map<Card>(updateRequest)).Returns(card);

            // Act
            await _service.UpdateAsync(updateRequest);

            // Assert
            _mockRepository.Verify(r => r.UpdateAsync(card, It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_ShouldThrowNotFoundException_WhenCardDoesNotExist()
        {
            // Arrange
            var updateRequest = new UpdateCardReq { Id = 999 };
            
            _mockRepository.Setup(r => r.ExistsAsync(999, It.IsAny<CancellationToken>())).ReturnsAsync(false);

            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _service.UpdateAsync(updateRequest));
            _mockRepository.Verify(r => r.UpdateAsync(It.IsAny<Card>(), It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact]
        public async Task DeleteAsync_ShouldCallRepositoryDeleteAsync_WhenCardExists()
        {
            // Arrange
            var card = new Card { Id = 1, EmployeeId = 1, IsActive = true };
            
            _mockRepository.Setup(r => r.GetByIdAsync(card.Id, It.IsAny<CancellationToken>())).ReturnsAsync(card);

            // Act
            await _service.DeleteAsync(card.Id);

            // Assert
            _mockRepository.Verify(r => r.DeleteAsync(card, It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_ShouldThrowNotFoundException_WhenCardDoesNotExist()
        {
            // Arrange
            var card = new Card { Id = 999, EmployeeId = 1, IsActive = true };
            
            _mockRepository.Setup(r => r.GetByIdAsync(card.Id, It.IsAny<CancellationToken>())).ReturnsAsync((Card)null);

            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _service.DeleteAsync(card.Id));
            _mockRepository.Verify(r => r.DeleteAsync(card, It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnMappedCards()
        {
            // Arrange
            var cards = new List<Card>
            {
                new Card { Id = 1, EmployeeId = 1, IsActive = true },
                new Card { Id = 2, EmployeeId = 2, IsActive = true }
            };
            
            var cardDtos = new List<CardDto>
            {
                new CardDto { Id = 1, EmployeeId = 1, IsActive = true },
                new CardDto { Id = 2, EmployeeId = 2, IsActive = true }
            };

            _mockRepository.Setup(r => r.GetAllAsync(It.IsAny<CancellationToken>())).ReturnsAsync(cards);
            _mockMapper.Setup(m => m.Map<IEnumerable<CardDto>>(cards)).Returns(cardDtos);

            // Act
            var result = await _service.GetAllAsync();

            // Assert
            Assert.Equal(cardDtos, result);
            _mockRepository.Verify(r => r.GetAllAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnMappedCard_WhenCardExists()
        {
            // Arrange
            int cardId = 1;
            var card = new Card { Id = cardId, EmployeeId = 1, IsActive = true };
            var cardDto = new CardDto { Id = cardId, EmployeeId = 1, IsActive = true };

            _mockRepository.Setup(r => r.GetByIdAsync(cardId, It.IsAny<CancellationToken>())).ReturnsAsync(card);
            _mockMapper.Setup(m => m.Map<CardDto>(card)).Returns(cardDto);

            // Act
            var result = await _service.GetByIdAsync(cardId);

            // Assert
            Assert.Equal(cardDto, result);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldThrowNotFoundException_WhenCardDoesNotExist()
        {
            // Arrange
            int cardId = 999;
            
            _mockRepository.Setup(r => r.GetByIdAsync(cardId, It.IsAny<CancellationToken>())).ReturnsAsync((Card)null);

            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _service.GetByIdAsync(cardId));
        }

        [Fact]
        public async Task GetCardByHashAsync_ShouldReturnMappedCard_WhenCardExists()
        {
            // Arrange
            string hash = "TestHash";
            var card = new Card { Id = 1, EmployeeId = 1, Hash = hash, IsActive = true };
            var cardDto = new CardDto { Id = 1, EmployeeId = 1, IsActive = true };

            _mockRepository.Setup(r => r.GetByHashAsync(hash, It.IsAny<CancellationToken>())).ReturnsAsync(card);
            _mockMapper.Setup(m => m.Map<CardDto>(card)).Returns(cardDto);

            // Act
            var result = await _service.GetCardByHashAsync(hash);

            // Assert
            Assert.Equal(cardDto, result);
        }

        [Fact]
        public async Task GetCardByHashAsync_ShouldThrowNotFoundException_WhenCardDoesNotExist()
        {
            // Arrange
            string hash = "NonExistentHash";
            
            _mockRepository.Setup(r => r.GetByHashAsync(hash, It.IsAny<CancellationToken>())).ReturnsAsync((Card)null);

            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _service.GetCardByHashAsync(hash));
        }

        [Fact]
        public async Task GetCardsByEmployeeAsync_ShouldReturnMappedCards_WhenCardsExist()
        {
            // Arrange
            int employeeId = 1;
            var cards = new List<Card>
            {
                new Card { Id = 1, EmployeeId = employeeId, IsActive = true },
                new Card { Id = 2, EmployeeId = employeeId, IsActive = false }
            };
            
            var cardDtos = new List<CardDto>
            {
                new CardDto { Id = 1, EmployeeId = employeeId, IsActive = true },
                new CardDto { Id = 2, EmployeeId = employeeId, IsActive = false }
            };

            _mockRepository.Setup(r => r.GetAllByEmployeeIdAsync(employeeId, It.IsAny<CancellationToken>())).ReturnsAsync(cards);
            _mockMapper.Setup(m => m.Map<IEnumerable<CardDto>>(cards)).Returns(cardDtos);

            // Act
            var result = await _service.GetCardsByEmployeeAsync(employeeId);

            // Assert
            Assert.Equal(cardDtos, result);
        }

        [Fact]
        public async Task GetCardsByEmployeeAsync_ShouldThrowNotFoundException_WhenNoCardsExist()
        {
            // Arrange
            int employeeId = 999;
            
            _mockRepository.Setup(r => r.GetAllByEmployeeIdAsync(employeeId, It.IsAny<CancellationToken>())).ReturnsAsync((IEnumerable<Card>)null);

            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _service.GetCardsByEmployeeAsync(employeeId));
        }
    }
} 