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
                    return result ?? ApiResponse<AccessCheckResponse>.Failure(new ApiError { Message = "Ошибка обращения к серверу" });
                }
                
                return ApiResponse<AccessCheckResponse>.Failure(new ApiError { Message = "Ошибка обращения к серверу" });
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
                ApplyAuthToken();
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
                var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/api/access/log", accessLog);
                
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
    }
} 