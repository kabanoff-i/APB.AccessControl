using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using APB.AccessControl.Shared.Models.DTOs;
using APB.AccessControl.Shared.Models.Requests;

namespace APB.AccessControl.ManageApp.Services
{
    /// <summary>
    /// Сервис для работы с сотрудниками
    /// </summary>
    public class EmployeeService
    {
        private readonly ApiService _apiService;
        
        public EmployeeService()
        {
            _apiService = new ApiService();
        }
        
        /// <summary>
        /// Получить список всех сотрудников
        /// </summary>
        public async Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync()
        {
            var response = await _apiService.GetEmployeesAsync();
            if (response.IsSuccess)
            {
                return response.Data;
            }
            
            throw new Exception(response.Error?.Message ?? "Ошибка получения списка сотрудников");
        }
        
        /// <summary>
        /// Получить сотрудника по ID
        /// </summary>
        public async Task<EmployeeDto> GetEmployeeByIdAsync(int id)
        {
            var response = await _apiService.GetEmployeeByIdAsync(id);
            if (response.IsSuccess)
            {
                return response.Data;
            }
            
            throw new Exception(response.Error?.Message ?? "Ошибка получения данных сотрудника");
        }
        
        /// <summary>
        /// Создать нового сотрудника
        /// </summary>
        public async Task<EmployeeDto> CreateEmployeeAsync(CreateEmployeeReq request)
        {
            var response = await _apiService.CreateEmployeeAsync(request);
            if (response.IsSuccess)
            {
                return response.Data;
            }
            
            throw new Exception(response.Error?.Message ?? "Ошибка создания сотрудника");
        }
        
        /// <summary>
        /// Обновить данные сотрудника
        /// </summary>
        public async Task UpdateEmployeeAsync(UpdateEmployeeReq request)
        {
            var response = await _apiService.UpdateEmployeeAsync(request);
            if (!response.IsSuccess)
            {
                throw new Exception(response.Error?.Message ?? "Ошибка обновления данных сотрудника");
            }
        }
        
        /// <summary>
        /// Удалить сотрудника
        /// </summary>
        public async Task DeleteEmployeeAsync(int id)
        {
            var response = await _apiService.DeleteEmployeeAsync(id);
            if (!response.IsSuccess)
            {
                throw new Exception(response.Error?.Message ?? "Ошибка удаления сотрудника");
            }
        }
        
        /// <summary>
        /// Получить карты сотрудника
        /// </summary>
        public async Task<IEnumerable<CardDto>> GetEmployeeCardsAsync(int employeeId)
        {
            var response = await _apiService.GetEmployeeCardsAsync(employeeId);
            if (response.IsSuccess)
            {
                return response.Data;
            }
            
            throw new Exception(response.Error?.Message ?? "Ошибка получения карт сотрудника");
        }
        
        /// <summary>
        /// Добавить карту сотруднику
        /// </summary>
        public async Task<CardDto> CreateCardAsync(CreateCardReq request)
        {
            var response = await _apiService.AddCardToEmployeeAsync(request.EmployeeId, request);
            if (response.IsSuccess)
            {
                return response.Data;
            }
            
            throw new Exception(response.Error?.Message ?? "Ошибка добавления карты сотруднику");
        }
        
        /// <summary>
        /// Удалить карту
        /// </summary>
        public async Task DeleteCardAsync(int cardId)
        {
            var response = await _apiService.DeleteCardAsync(cardId);
            if (!response.IsSuccess)
            {
                throw new Exception(response.Error?.Message ?? "Ошибка удаления карты");
            }
        }

        /// <summary>
        /// Обновить данные карты
        /// </summary>
        public async Task<CardDto> UpdateCardAsync(int cardId, UpdateCardReq request)
        {
            var response = await _apiService.UpdateCardAsync(cardId, request);
            if (response.IsSuccess)
            {
                return response.Data;
            }
            
            throw new Exception(response.Error?.Message ?? "Ошибка обновления данных карты");
        }

        /// <summary>
        /// Активировать карту
        /// </summary>
        public async Task ActivateCardAsync(int cardId)
        {
            var request = new UpdateCardReq { Id = cardId, IsActive = true };
            await UpdateCardAsync(cardId, request);
        }

        /// <summary>
        /// Деактивировать карту
        /// </summary>
        public async Task DeactivateCardAsync(int cardId)
        {
            var request = new UpdateCardReq {Id = cardId, IsActive = false };
            await UpdateCardAsync(cardId, request);
        }
    }
}
