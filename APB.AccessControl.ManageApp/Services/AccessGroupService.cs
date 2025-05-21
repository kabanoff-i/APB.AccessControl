using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using APB.AccessControl.Shared.Models.DTOs;
using APB.AccessControl.Shared.Models.Requests;

namespace APB.AccessControl.ManageApp.Services
{
    /// <summary>
    /// Сервис для работы с группами доступа
    /// </summary>
    public class AccessGroupService
    {
        private readonly ApiService _apiService;

        public AccessGroupService()
        {
            _apiService = new ApiService();
        }

        /// <summary>
        /// Получить все группы доступа
        /// </summary>
        public async Task<IEnumerable<AccessGroupDto>> GetAccessGroupsAsync()
        {
            var response = await _apiService.GetAccessGroupsAsync();
            if (response.IsSuccess)
            {
                return response.Data;
            }
            throw new Exception($"Не удалось получить список групп доступа: {response.Error?.Message}");
        }
        
        /// <summary>
        /// Получить группу доступа по ID
        /// </summary>
        public async Task<AccessGroupDto> GetAccessGroupByIdAsync(int id)
        {
            var response = await _apiService.GetAccessGroupByIdAsync(id);
            if (response.IsSuccess)
            {
                return response.Data;
            }
            throw new Exception($"Не удалось получить группу доступа: {response.Error?.Message}");
        }
        
        /// <summary>
        /// Получить список сотрудников в группе доступа
        /// </summary>
        public async Task<IEnumerable<EmployeeDto>> GetEmployeesInGroupAsync(int groupId)
        {
            var response = await _apiService.GetEmployeesInGroupAsync(groupId);
            if (response.IsSuccess)
            {
                return response.Data;
            }
            throw new Exception($"Не удалось получить список сотрудников в группе: {response.Error?.Message}");
        }
        
        /// <summary>
        /// Получить все группы доступа сотрудника
        /// </summary>
        public async Task<IEnumerable<AccessGroupDto>> GetEmployeeAccessGroupsAsync(int employeeId)
        {
            var response = await _apiService.GetEmployeeAccessGroupsAsync(employeeId);
            if (response.IsSuccess)
            {
                return response.Data;
            }
            throw new Exception($"Не удалось получить группы доступа сотрудника: {response.Error?.Message}");
        }
        
        /// <summary>
        /// Создать новую группу доступа
        /// </summary>
        public async Task CreateAccessGroupAsync(string name)
        {
            var request = new CreateGroupReq { Name = name };
            var response = await _apiService.CreateAccessGroupAsync(request);
            if (!response.IsSuccess)
            {
                throw new Exception($"Не удалось создать группу доступа: {response.Error?.Message}");
            }
        }
        
        /// <summary>
        /// Обновить группу доступа
        /// </summary>
        public async Task UpdateAccessGroupAsync(int id, string name, bool isActive)
        {
            var request = new UpdateGroupReq { Id = id, Name = name, IsActive = isActive };
            var response = await _apiService.UpdateAccessGroupAsync(request);
            if (!response.IsSuccess)
            {
                throw new Exception($"Не удалось обновить группу доступа: {response.Error?.Message}");
            }
        }
        
        /// <summary>
        /// Удалить группу доступа
        /// </summary>
        public async Task DeleteAccessGroupAsync(int id)
        {
            var response = await _apiService.DeleteAccessGroupAsync(id);
            if (!response.IsSuccess)
            {
                throw new Exception($"Не удалось удалить группу доступа: {response.Error?.Message}");
            }
        }
        
        /// <summary>
        /// Добавить сотрудника в группу доступа
        /// </summary>
        public async Task AddEmployeeToGroupAsync(int employeeId, int groupId)
        {
            var response = await _apiService.AddEmployeeToGroupAsync(employeeId, groupId);
            if (!response.IsSuccess)
            {
                throw new Exception($"Не удалось добавить сотрудника в группу доступа: {response.Error?.Message}");
            }
        }
        
        /// <summary>
        /// Удалить сотрудника из группы доступа
        /// </summary>
        public async Task RemoveEmployeeFromGroupAsync(int employeeId, int groupId)
        {
            var response = await _apiService.RemoveEmployeeFromGroupAsync(employeeId, groupId);
            if (!response.IsSuccess)
            {
                throw new Exception($"Не удалось удалить сотрудника из группы доступа: {response.Error?.Message}");
            }
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
            throw new Exception($"Не удалось получить список сотрудников: {response.Error?.Message}");
        }
    }
} 