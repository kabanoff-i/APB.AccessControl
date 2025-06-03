using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using APB.AccessControl.Shared.Models.DTOs;
using APB.AccessControl.Shared.Models.Requests;
using APB.AccessControl.Shared.Models.Responses;
using APB.AccessControl.Shared.Models.Common;
using APB.AccessControl.Shared.Models.Filters;
using System.Linq;
using APB.AccessControl.Shared.Models.Identity;

namespace APB.AccessControl.ManageApp.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions;
        
        public ApiService()
        {
            _httpClient = new HttpClient();
            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }
        
        #region Сотрудники
        
        public async Task<ApiResponse<IEnumerable<EmployeeDto>>> GetEmployeesAsync()
        {
            return await GetAsync<IEnumerable<EmployeeDto>>($"{ApiSettings.BaseUrl}/api/employee");
        }
        
        public async Task<ApiResponse<EmployeeDto>> GetEmployeeByIdAsync(int id)
        {
            return await GetAsync<EmployeeDto>($"{ApiSettings.BaseUrl}/api/employee/{id}");
        }
        
        public async Task<ApiResponse<EmployeeDto>> CreateEmployeeAsync(CreateEmployeeReq request)
        {
            return await PostAsync<EmployeeDto, CreateEmployeeReq>($"{ApiSettings.BaseUrl}/api/employee", request);
        }
        
        public async Task<ApiResponse<EmployeeDto>> UpdateEmployeeAsync(UpdateEmployeeReq request)
        {
            return await PutAsync<EmployeeDto, UpdateEmployeeReq>($"{ApiSettings.BaseUrl}/api/employee/{request.Id}", request);
        }
        
        public async Task<ApiResponse<bool>> DeleteEmployeeAsync(int id)
        {
            return await DeleteAsync<bool>($"{ApiSettings.BaseUrl}/api/employee/{id}");
        }
        
        #endregion
        
        #region Карты
        
        public async Task<ApiResponse<IEnumerable<CardDto>>> GetCardsAsync()
        {
            return await GetAsync<IEnumerable<CardDto>>($"{ApiSettings.BaseUrl}/api/cards");
        }
        
        public async Task<ApiResponse<IEnumerable<CardDto>>> GetEmployeeCardsAsync(int employeeId)
        {
            return await GetAsync<IEnumerable<CardDto>>($"{ApiSettings.BaseUrl}/api/cards/employee/{employeeId}");
        }
        
        public async Task<ApiResponse<CardDto>> AddCardToEmployeeAsync(int employeeId, CreateCardReq request)
        {
            return await PostAsync<CardDto, CreateCardReq>($"{ApiSettings.BaseUrl}/api/cards", request);
        }
        
        public async Task<ApiResponse<CardDto>> UpdateCardAsync(int cardId, UpdateCardReq request)
        {
            return await PutAsync<CardDto, UpdateCardReq>($"{ApiSettings.BaseUrl}/api/cards/{cardId}", request);
        }
        
        public async Task<ApiResponse<bool>> DeleteCardAsync(int cardId)
        {
            return await DeleteAsync<bool>($"{ApiSettings.BaseUrl}/api/cards/{cardId}");
        }
        
        #endregion
        
        #region Группы доступа
        
        public async Task<ApiResponse<IEnumerable<AccessGroupDto>>> GetAccessGroupsAsync()
        {
            return await GetAsync<IEnumerable<AccessGroupDto>>($"{ApiSettings.BaseUrl}/api/accessgroups");
        }
        
        public async Task<ApiResponse<AccessGroupDto>> GetAccessGroupByIdAsync(int accessGroupId)
        {
            return await GetAsync<AccessGroupDto>($"{ApiSettings.BaseUrl}/api/accessgroups/{accessGroupId}");
        }
        
        public async Task<ApiResponse<IEnumerable<EmployeeDto>>> GetEmployeesInGroupAsync(int accessGroupId)
        {
            return await GetAsync<IEnumerable<EmployeeDto>>($"{ApiSettings.BaseUrl}/api/accessgroups/{accessGroupId}/employees");
        }
        
        public async Task<ApiResponse<IEnumerable<AccessGroupDto>>> GetEmployeeAccessGroupsAsync(int employeeId)
        {
            return await GetAsync<IEnumerable<AccessGroupDto>>($"{ApiSettings.BaseUrl}/api/accessgroups/employee/{employeeId}");
        }
        
        public async Task<ApiResponse<AccessGroupDto>> CreateAccessGroupAsync(CreateGroupReq request)
        {
            return await PostAsync<AccessGroupDto, CreateGroupReq>($"{ApiSettings.BaseUrl}/api/accessgroups", request);
        }
        
        public async Task<ApiResponse<bool>> UpdateAccessGroupAsync(UpdateGroupReq request)
        {
            return await PutAsync<bool, UpdateGroupReq>($"{ApiSettings.BaseUrl}/api/accessgroups/{request.Id}", request);
        }
        
        public async Task<ApiResponse<bool>> DeleteAccessGroupAsync(int accessGroupId)
        {
            return await DeleteAsync<bool>($"{ApiSettings.BaseUrl}/api/accessgroups/{accessGroupId}");
        }
        
        public async Task<ApiResponse<bool>> AddEmployeeToGroupAsync(int employeeId, int accessGroupId)
        {
            return await PostAsync<bool, object>($"{ApiSettings.BaseUrl}/api/accessgroups/{accessGroupId}/employees/{employeeId}", null);
        }
        
        public async Task<ApiResponse<bool>> RemoveEmployeeFromGroupAsync(int employeeId, int accessGroupId)
        {
            return await DeleteAsync<bool>($"{ApiSettings.BaseUrl}/api/accessgroups/{accessGroupId}/employees/{employeeId}");
        }
        
        #endregion
        
        #region Точки доступа
        
        public async Task<ApiResponse<IEnumerable<AccessPointDto>>> GetAccessPointsAsync()
        {
            return await GetAsync<IEnumerable<AccessPointDto>>($"{ApiSettings.BaseUrl}/api/accesspoints");
        }
        
        public async Task<ApiResponse<AccessPointDto>> GetAccessPointByIdAsync(int id)
        {
            return await GetAsync<AccessPointDto>($"{ApiSettings.BaseUrl}/api/accesspoints/{id}");
        }
        
        public async Task<ApiResponse<AccessPointDto>> CreateAccessPointAsync(CreateAccessPointReq request)
        {
            return await PostAsync<AccessPointDto, CreateAccessPointReq>($"{ApiSettings.BaseUrl}/api/accesspoints", request);
        }
        
        public async Task<ApiResponse<object>> UpdateAccessPointAsync(UpdateAccessPointReq request)
        {
            return await PutAsync<object, UpdateAccessPointReq>($"{ApiSettings.BaseUrl}/api/accesspoints/{request.Id}", request);
        }
        
        public async Task<ApiResponse<object>> DeleteAccessPointAsync(int id)
        {
            return await DeleteAsync<object>($"{ApiSettings.BaseUrl}/api/accesspoints/{id}");
        }
        
        public async Task<ApiResponse<IEnumerable<AccessPointTypeDto>>> GetAccessPointTypesAsync()
        {
            return await GetAsync<IEnumerable<AccessPointTypeDto>>($"{ApiSettings.BaseUrl}/api/accesspointtypes");
        }
        
        public async Task<ApiResponse<object>> SendHeartbeatAsync(HeartbeatReq request)
        {
            return await PostAsync<object, HeartbeatReq>($"{ApiSettings.BaseUrl}/api/accesspoints/heartbeat", request);
        }
        
        #endregion
        
        #region Правила доступа
        
        public async Task<ApiResponse<IEnumerable<AccessRuleDto>>> GetAccessRulesAsync()
        {
            return await GetAsync<IEnumerable<AccessRuleDto>>($"{ApiSettings.BaseUrl}/api/accessrules");
        }
        
        public async Task<ApiResponse<IEnumerable<AccessRuleDto>>> GetAccessRulesByGroupAsync(int accessGroupId)
        {
            return await GetAsync<IEnumerable<AccessRuleDto>>($"{ApiSettings.BaseUrl}/api/accessrules/group/{accessGroupId}");
        }
        
        public async Task<ApiResponse<IEnumerable<AccessRuleDto>>> GetAccessRulesByPointAsync(int accessPointId)
        {
            return await GetAsync<IEnumerable<AccessRuleDto>>($"{ApiSettings.BaseUrl}/api/accessrules/point/{accessPointId}");
        }
        
        public async Task<ApiResponse<AccessRuleDto>> GetAccessRuleByIdAsync(int accessRuleId)
        {
            return await GetAsync<AccessRuleDto>($"{ApiSettings.BaseUrl}/api/accessrules/{accessRuleId}");
        }
        
        public async Task<ApiResponse<AccessRuleDto>> CreateAccessRuleAsync(CreateAccessRuleReq request)
        {
            return await PostAsync<AccessRuleDto, CreateAccessRuleReq>($"{ApiSettings.BaseUrl}/api/accessrules", request);
        }
        
        public async Task<ApiResponse<AccessRuleDto>> UpdateAccessRuleAsync(UpdateAccessRuleReq request)
        {
            return await PutAsync<AccessRuleDto, UpdateAccessRuleReq>($"{ApiSettings.BaseUrl}/api/accessrules/{request.Id}", request);
        }
        
        public async Task<ApiResponse<bool>> DeleteAccessRuleAsync(int accessRuleId)
        {
            return await DeleteAsync<bool>($"{ApiSettings.BaseUrl}/api/accessrules/{accessRuleId}");
        }
        
        #endregion
        
        #region Логи доступа
        
        public async Task<ApiResponse<IEnumerable<AccessLogDto>>> GetAccessLogsAsync(AccessLogFilterDto filter)
        {
            // Выполняем запрос к API
            return await PostAsync<IEnumerable<AccessLogDto>, AccessLogFilterDto>($"{ApiSettings.BaseUrl}/api/accesslogs/filter", filter);
        }
        
        #endregion
        
        #region Уведомления
        
        public async Task<ApiResponse<IEnumerable<NotificationDto>>> GetNotificationsAsync()
        {
            return await GetAsync<IEnumerable<NotificationDto>>($"{ApiSettings.BaseUrl}/api/notifications");
        }
        
        public async Task<ApiResponse<NotificationDto>> GetNotificationByIdAsync(int id)
        {
            return await GetAsync<NotificationDto>($"{ApiSettings.BaseUrl}/api/notifications/{id}");
        }
        
        public async Task<ApiResponse<NotificationDto>> CreateNotificationAsync(CreateNotificationReq request)
        {
            return await PostAsync<NotificationDto, CreateNotificationReq>($"{ApiSettings.BaseUrl}/api/notifications", request);
        }
        
        public async Task<ApiResponse<object>> UpdateNotificationAsync(UpdateNotificationReq request)
        {
            return await PutAsync<object, UpdateNotificationReq>($"{ApiSettings.BaseUrl}/api/notifications/{request.Id}", request);
        }
        
        public async Task<ApiResponse<object>> DeleteNotificationAsync(int id)
        {
            return await DeleteAsync<object>($"{ApiSettings.BaseUrl}/api/notifications/{id}");
        }
        
        public async Task<ApiResponse<IEnumerable<NotificationDto>>> GetNotificationsByAccessPointAsync(int accessPointId)
        {
            return await GetAsync<IEnumerable<NotificationDto>>($"{ApiSettings.BaseUrl}/api/notifications/accesspoint/{accessPointId}");
        }
        
        public async Task<ApiResponse<IEnumerable<NotificationDto>>> GetNotificationsByEmployeeAsync(int employeeId)
        {
            return await GetAsync<IEnumerable<NotificationDto>>($"{ApiSettings.BaseUrl}/api/notifications/employee/{employeeId}");
        }

        #endregion

        #region Управление пользователями

        public async Task<ApiResponse<IEnumerable<UserDto>>> GetAllUsersAsync()
        {
            return await GetAsync<IEnumerable<UserDto>>($"{ApiSettings.BaseUrl}/identity/account/users");
        }

        public async Task<ApiResponse<UserDto>> GetUserByIdAsync(int userId)
        {
            return await GetAsync<UserDto>($"{ApiSettings.BaseUrl}/identity/account/users/{userId}");
        }

        public async Task<ApiResponse<IEnumerable<RoleDto>>> GetAllRolesAsync()
        {
            return await GetAsync<IEnumerable<RoleDto>>($"{ApiSettings.BaseUrl}/identity/role");
        }

        public async Task<ApiResponse<UserDto>> CreateUserAsync(RegisterRequest request)
        {
            return await PostAsync<UserDto, RegisterRequest>($"{ApiSettings.BaseUrl}/identity/account/register", request);
        }

        public async Task<ApiResponse<UserDto>> UpdateUserAsync(UpdateUserReq request)
        {
            return await PutAsync<UserDto, UpdateUserReq>($"{ApiSettings.BaseUrl}/identity/account/users/{request.Id}", request);
        }

        public async Task<ApiResponse<bool>> DeleteUserAsync(string userId)
        {
            return await DeleteAsync<bool>($"{ApiSettings.BaseUrl}/identity/account/users/{userId}");
        }

        public async Task<ApiResponse<bool>> ChangePasswordAsync(ChangePasswordReq request)
        {
            return await PostAsync<bool, ChangePasswordReq>($"{ApiSettings.BaseUrl}/identity/account/users/change-password", request);
        }

        public async Task<ApiResponse<bool>> AssignRoleAsync(UserRole userRole)
        {
            return await PostAsync<bool, UserRole>($"{ApiSettings.BaseUrl}/identity/role/assign", userRole);
        }

        #endregion

        #region Базовые методы HTTP

        /// <summary>
        /// Применяет актуальный токен авторизации перед каждым запросом
        /// </summary>
        private void ApplyCurrentAuthToken()
        {
            // Удаляем текущий заголовок авторизации, если он есть
            if (_httpClient.DefaultRequestHeaders.Contains("Authorization"))
            {
                _httpClient.DefaultRequestHeaders.Remove("Authorization");
            }
            
            // Применяем актуальный токен, если пользователь аутентифицирован
            AuthService.ApplyTokenToClient(_httpClient);
        }
        
        private async Task<ApiResponse<T>> GetAsync<T>(string url)
        {
            try
            {
                // Применяем актуальный токен авторизации
                ApplyCurrentAuthToken();
                
                var response = await _httpClient.GetAsync(url);
                return await ProcessResponseAsync<T>(response);
            }
            catch (Exception ex)
            {
                LogService.LogError(ex, $"GetAsync: {url}");
                return ApiResponse<T>.Failure(new ApiError { Message = ex.Message });
            }
        }
        
        private async Task<ApiResponse<TResponse>> PostAsync<TResponse, TRequest>(string url, TRequest request)
        {
            try
            {
                // Применяем актуальный токен авторизации
                ApplyCurrentAuthToken();
                
                var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(url, content);
                return await ProcessResponseAsync<TResponse>(response);
            }
            catch (Exception ex)
            {
                LogService.LogError(ex, $"PostAsync: {url}");
                return ApiResponse<TResponse>.Failure(new ApiError { Message = ex.Message });
            }
        }
        
        private async Task<ApiResponse<TResponse>> PutAsync<TResponse, TRequest>(string url, TRequest request)
        {
            try
            {
                // Применяем актуальный токен авторизации
                ApplyCurrentAuthToken();
                
                var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync(url, content);
                return await ProcessResponseAsync<TResponse>(response);
            }
            catch (Exception ex)
            {
                LogService.LogError(ex, $"PutAsync: {url}");
                return ApiResponse<TResponse>.Failure(new ApiError { Message = ex.Message });
            }
        }
        
        private async Task<ApiResponse<T>> DeleteAsync<T>(string url)
        {
            try
            {
                // Применяем актуальный токен авторизации
                ApplyCurrentAuthToken();
                
                var response = await _httpClient.DeleteAsync(url);
                return await ProcessResponseAsync<T>(response);
            }
            catch (Exception ex)
            {
                LogService.LogError(ex, $"DeleteAsync: {url}");
                return ApiResponse<T>.Failure(new ApiError { Message = ex.Message });
            }
        }
        
        private async Task<ApiResponse<T>> ProcessResponseAsync<T>(HttpResponseMessage response)
        {
            string content = await response.Content.ReadAsStringAsync();
            
            try
            {
                // Проверка на пустой ответ
                if (string.IsNullOrWhiteSpace(content))
                {
                    var error = new ApiError { 
                        Message = $"Сервер вернул пустой ответ. Код состояния: {(int)response.StatusCode} {response.StatusCode}",
                        Details = $"URL: {response.RequestMessage?.RequestUri}"
                    };
                    LogService.LogError($"Пустой ответ: {response.RequestMessage?.RequestUri}, Код: {(int)response.StatusCode}", "ApiService");
                    return ApiResponse<T>.Failure(error);
                }
                
                if (response.IsSuccessStatusCode)
                {
                    try
                    {
                        // Сначала пробуем десериализовать в формате Result<T>
                        var resultWrapper = JsonSerializer.Deserialize<Result<T>>(content, _jsonOptions);
                        if (resultWrapper != null)
                        {
                            // Возвращаем данные из обертки Result
                            return ApiResponse<T>.Success(resultWrapper.Data);
                        }
                    }
                    catch (JsonException ex)
                    {
                        // Логируем ошибку десериализации Result<T> и пробуем другой формат
                        LogService.LogError(ex, $"Десериализация Result<T>: {response.RequestMessage?.RequestUri}");
                    }
                    
                    try
                    {
                        // Если не удалось десериализовать как Result<T>, пробуем напрямую в T
                        var data = JsonSerializer.Deserialize<T>(content, _jsonOptions);
                        return ApiResponse<T>.Success(data);
                    }
                    catch (JsonException ex)
                    {
                        // Не удалось десериализовать данные
                        LogService.LogError(ex, $"Десериализация ответа: {response.RequestMessage?.RequestUri}");
                        return ApiResponse<T>.Failure(new ApiError { 
                            Message = $"Ошибка десериализации ответа: {ex.Message}",
                            Details = $"Контент: {content.Substring(0, Math.Min(content.Length, 500))}"
                        });
                    }
                }
                else
                {
                    // Проверяем, связана ли ошибка с авторизацией (401 Unauthorized)
                    if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    {
                        LogService.LogError($"Ошибка авторизации: {response.RequestMessage?.RequestUri}", "ApiService");
                        return ApiResponse<T>.Failure(new ApiError { 
                            Message = "Отказано в доступе. Возможно, срок действия токена истек. Требуется повторная авторизация." 
                        });
                    }
                    
                    // Пробуем десериализовать ошибку из JSON-ответа сервера
                    try
                    {
                        var resultWrapper = JsonSerializer.Deserialize<Result>(content, _jsonOptions);
                        if (resultWrapper != null && resultWrapper.Errors != null)
                        {
                            var errorString = string.Join("\r\n", resultWrapper.Errors.Select(x => x.Message));
                            LogService.LogError($"Ошибка API: {response.RequestMessage?.RequestUri}, {errorString}", "ApiService");
                            return ApiResponse<T>.Failure(new ApiError { 
                                Message = errorString
                            });
                        }
                    }
                    catch (JsonException)
                    {
                        // Игнорируем ошибку десериализации и используем стандартное сообщение
                    }
                    
                    // Если не удалось извлечь детали ошибки, возвращаем общее сообщение
                    var error = new ApiError { 
                        Message = $"Ошибка {(int)response.StatusCode} {response.StatusCode} при обращении к API",
                        Details = $"URL: {response.RequestMessage?.RequestUri}"
                    };
                    LogService.LogError($"HTTP Ошибка: {response.RequestMessage?.RequestUri}, Код: {(int)response.StatusCode}", "ApiService");
                    return ApiResponse<T>.Failure(error);
                }
            }
            catch (Exception ex)
            {
                // Непредвиденная ошибка при обработке ответа
                LogService.LogError(ex, $"Обработка ответа: {response.RequestMessage?.RequestUri}");
                return ApiResponse<T>.Failure(new ApiError { 
                    Message = $"Ошибка при обработке ответа: {ex.Message}"
                });
            }
            
            // Если мы дошли до этого места, значит, не удалось обработать ответ
            LogService.LogError($"Не удалось обработать ответ: {response.RequestMessage?.RequestUri}", "ApiService");
            return ApiResponse<T>.Failure(new ApiError { 
                Message = "Не удалось обработать ответ сервера"
            });
        }
        
        #endregion
    }
} 