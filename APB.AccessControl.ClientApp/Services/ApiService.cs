using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using APB.AccessControl.Shared.Models.Requests;
using APB.AccessControl.Shared.Models.Responses;
using APB.AccessControl.Shared.Models;
using APB.AccessControl.Shared.Models.Common;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Net.Http.Headers;
using APB.AccessControl.Shared.Models.DTOs;
using APB.AccessControl.Shared.Models.Filters;
using APB.AccessControl.Shared.Models.Identity;
using System.Linq;
using APB.AccessControl.ClientApp.Config;

namespace APB.AccessControl.ClientApp.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;
        private string _authToken;
        private DateTime? _tokenExpiry;

        public ApiService()
        {
            var config = AppConfig.Load();
            _authToken = config.AuthToken;
            _tokenExpiry = config.TokenExpiry;
            _baseUrl = config.ApiUrl;
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<LoginResponse> LoginAsync(string username, string password)
        {
            try
            {
                var loginRequest = new LoginRequest
                {
                    Username = username,
                    Password = password
                };

                var content = new StringContent(
                    JsonSerializer.Serialize(loginRequest),
                    Encoding.UTF8,
                    "application/json");

                var response = await _httpClient.PostAsync($"{_baseUrl}/identity/account/login", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    using JsonDocument document = JsonDocument.Parse(responseContent);

                    if (document.RootElement.TryGetProperty("token", out JsonElement tokenElement))
                    {
                        string token = tokenElement.GetString();
                        DateTime expiresAt = DateTime.Now.AddMinutes(60); // По умолчанию 60 минут

                        if (document.RootElement.TryGetProperty("expiresAt", out JsonElement expiresElement) &&
                            DateTime.TryParse(expiresElement.GetString(), out DateTime serverExpiresAt))
                        {
                            expiresAt = serverExpiresAt;
                        }

                        _authToken = token;
                        _tokenExpiry = expiresAt;

                        return new LoginResponse
                        {
                            Token = token,
                            ExpiresAt = expiresAt,
                            IsSuccess = true
                        };
                    }
                }

                return new LoginResponse
                {
                    IsSuccess = false,
                    ErrorMessage = "Неверное имя пользователя или пароль"
                };
            }
            catch (Exception ex)
            {
                return new LoginResponse
                {
                    IsSuccess = false,
                    ErrorMessage = $"Ошибка авторизации: {ex.Message}"
                };
            }
        }

        private void ApplyAuthToken()
        {
            if (!string.IsNullOrEmpty(_authToken))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _authToken);
            }
        }

        public async Task<ApiResponse<AccessCheckResponse>> CheckAccessAsync(string cardHash, int accessPointId)
        {
            try
            {
                ApplyAuthToken();
                var request = new CheckAccessReq
                {
                    CardHash = cardHash,
                    AcсessPointId = accessPointId,
                    DateAccess = DateTime.UtcNow
                };
                
                var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/api/accesscheck/check", request);
                
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<ApiResponse<AccessCheckResponse>>();
                    return result ?? ApiResponse<AccessCheckResponse>.Failure(new ApiError { Message = $"Ошибка обращения к серверу: не удалось распознать ответ" });
                }
                
                return ApiResponse<AccessCheckResponse>.Failure(new ApiError { Message = $"Ошибка обращения к серверу. Статус запроса {response.StatusCode}" });
            }
            catch (Exception ex)
            {
                return ApiResponse<AccessCheckResponse>.Failure(new ApiError { Message = ex.Message });
            }
        }

        public async Task<IEnumerable<AccessLogDto>> GetPassHistory(DateTime? fromDate = null, DateTime? toDate = null, string searchText = null)
        {
            try
            {
                ApplyAuthToken();
                var filter = new AccessLogFilterDto
                {
                    AccessTimeStart = fromDate,
                    AccessTimeEnd = toDate,
                    CardId = !string.IsNullOrEmpty(searchText) ? int.Parse(searchText) : null
                };

                var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/api/accesslogs/filter", filter);
                
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<ApiResponse<IEnumerable<AccessLogDto>>>();
                    return result?.Data ?? new List<AccessLogDto>();
                }

                return new List<AccessLogDto>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при получении истории проходов: {ex.Message}", ex);
            }
        }

        public async Task<HeartbeatResponse> Heartbeat()
        {
            try
            {
                ApplyAuthToken();
                var config = AppConfig.Load();
                var request = new HeartbeatReq
                {
                    AccessPointId = config.AccessPointId,
                    TimeStamp = DateTime.UtcNow
                };

                var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/api/accesspoints/heartbeat", request);
                
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<ApiResponse<HeartbeatResponse>>();
                    return result?.Data ?? new HeartbeatResponse { Notifications = new List<NotificationDto>() };
                }

                return new HeartbeatResponse { Notifications = new List<NotificationDto>() };
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при выполнении heartbeat: {ex.Message}", ex);
            }
        }

        public async Task<List<AccessPointDto>> GetAccessPoints()
        {
            try
            {
                //ApplyAuthToken();
                var response = await _httpClient.GetAsync($"{_baseUrl}/api/accesspoints");
                
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<ApiResponse<IEnumerable<AccessPointDto>>>();
                    return result?.Data?.ToList() ?? new List<AccessPointDto>();
                }

                return new List<AccessPointDto>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при получении списка точек доступа: {ex.Message}", ex);
            }
        }

        public async Task<ApiResponse<bool>> LogAccessAsync(CreateAccessLogReq accessLog)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/api/accesslogs", accessLog);
                
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<ApiResponse<bool>>();
                    return result ?? ApiResponse<bool>.Failure(new ApiError { Message = "Пустой ответ от сервера" });
                }

                return ApiResponse<bool>.Failure(new ApiError { Message = $"Ошибка сервера: {response.StatusCode}" });
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.Failure(new ApiError { Message = ex.Message });
            }
        }

        public async Task<ApiResponse<bool>> ProcessNotificationAsync(int notificationId)
        {
            try
            {
                var response = await _httpClient.PostAsync($"{_baseUrl}/api/notifications/{notificationId}/process", null);
                
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<ApiResponse<bool>>();
                    return result ?? ApiResponse<bool>.Failure(new ApiError { Message = "Пустой ответ от сервера" });
                }

                return ApiResponse<bool>.Failure(new ApiError { Message = $"Ошибка сервера: {response.StatusCode}" });
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.Failure(new ApiError { Message = ex.Message });
            }
        }

        public async Task<ApiResponse<IEnumerable<AccessLogDto>>> GetAccessLogsAsync(AccessLogFilterDto filter)
        {
            return await PostAsync<IEnumerable<AccessLogDto>, AccessLogFilterDto>($"{_baseUrl}/api/accesslogs/filter", filter);
        }

        private async Task<ApiResponse<T>> GetAsync<T>(string url)
        {
            try
            {
                // Применяем актуальный токен авторизации
                ApplyAuthToken();
                
                var response = await _httpClient.GetAsync(url);
                return await ProcessResponseAsync<T>(response);
            }
            catch (Exception ex)
            {
                return ApiResponse<T>.Failure(new ApiError { Message = ex.Message });
            }
        }
        
        private async Task<ApiResponse<TResponse>> PostAsync<TResponse, TRequest>(string url, TRequest request)
        {
            try
            {
                // Применяем актуальный токен авторизации
                ApplyAuthToken();
                
                var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(url, content);
                return await ProcessResponseAsync<TResponse>(response);
            }
            catch (Exception ex)
            {
                return ApiResponse<TResponse>.Failure(new ApiError { Message = ex.Message });
            }
        }
        
        private async Task<ApiResponse<TResponse>> PutAsync<TResponse, TRequest>(string url, TRequest request)
        {
            try
            {
                // Применяем актуальный токен авторизации
                ApplyAuthToken();
                
                var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync(url, content);
                return await ProcessResponseAsync<TResponse>(response);
            }
            catch (Exception ex)
            {
                return ApiResponse<TResponse>.Failure(new ApiError { Message = ex.Message });
            }
        }
        
        private async Task<ApiResponse<T>> DeleteAsync<T>(string url)
        {
            try
            {
                // Применяем актуальный токен авторизации
                ApplyAuthToken();
                
                var response = await _httpClient.DeleteAsync(url);
                return await ProcessResponseAsync<T>(response);
            }
            catch (Exception ex)
            {
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
                    return ApiResponse<T>.Failure(error);
                }
                
                if (response.IsSuccessStatusCode)
                {
                    try
                    {
                        var _jsonOptions = new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        };

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

                    }
                    
                    try
                    {
                        var _jsonOptions = new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        };
                        // Если не удалось десериализовать как Result<T>, пробуем напрямую в T
                        var data = JsonSerializer.Deserialize<T>(content, _jsonOptions);
                        return ApiResponse<T>.Success(data);
                    }
                    catch (JsonException ex)
                    {
                        // Не удалось десериализовать данные
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
                        return ApiResponse<T>.Failure(new ApiError { 
                            Message = "Отказано в доступе. Возможно, срок действия токена истек. Требуется повторная авторизация." 
                        });
                    }
                    
                    // Пробуем десериализовать ошибку из JSON-ответа сервера
                    try
                    {
                        var _jsonOptions = new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        };
                        var resultWrapper = JsonSerializer.Deserialize<Result>(content, _jsonOptions);
                        if (resultWrapper != null && resultWrapper.Errors != null)
                        {
                            var errorString = string.Join("\r\n", resultWrapper.Errors.Select(x => x.Message));
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
                    return ApiResponse<T>.Failure(error);
                }
            }
            catch (Exception ex)
            {
                // Непредвиденная ошибка при обработке ответа
                return ApiResponse<T>.Failure(new ApiError { 
                    Message = $"Ошибка при обработке ответа: {ex.Message}"
                });
            }
            
            // Если мы дошли до этого места, значит, не удалось обработать ответ
            return ApiResponse<T>.Failure(new ApiError { 
                Message = "Не удалось обработать ответ сервера"
            });
        }
    }
} 