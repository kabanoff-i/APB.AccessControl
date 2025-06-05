using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using APB.AccessControl.Shared.Models.Identity;
using APB.AccessControl.Shared.Models.Responses;

namespace APB.AccessControl.ManageApp.Services
{
    public class AuthService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions;
        
        // Время жизни токена в минутах (по умолчанию)
        private readonly int _defaultTokenLifetime = 60;
        
        public AuthService()
        {
            _httpClient = new HttpClient();
            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }
        
        /// <summary>
        /// Авторизация пользователя
        /// </summary>
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
                
                var response = await _httpClient.PostAsync($"{ApiSettings.BaseUrl}/identity/account/login", content);
                
                if (response.IsSuccessStatusCode)
                {
                    var stringResponse = await response.Content.ReadAsStringAsync();
                    var loginResponse = JsonSerializer.Deserialize<LoginResponse>(stringResponse, _jsonOptions);

                    
                    // Сохраняем токен и время его истечения в ApiSettings
                    ApiSettings.AuthToken = loginResponse.Token;
                    ApiSettings.TokenExpiry = loginResponse.ExpiresAt;

                    return loginResponse;

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
        
        /// <summary>
        /// Выход пользователя
        /// </summary>
        public void Logout()
        {
            ApiSettings.AuthToken = null;
            ApiSettings.TokenExpiry = null;
        }
        
        /// <summary>
        /// Проверка авторизации
        /// </summary>
        public bool IsAuthenticated()
        {
            return !string.IsNullOrEmpty(ApiSettings.AuthToken) && ApiSettings.TokenExpiry.HasValue && ApiSettings.TokenExpiry.Value > DateTime.Now;
        }
        
        /// <summary>
        /// Получение токена для запросов
        /// </summary>
        public string GetToken()
        {
            return ApiSettings.AuthToken;
        }
        
        /// <summary>
        /// Получает оставшееся время до истечения срока действия токена
        /// </summary>
        public TimeSpan GetTokenExpiryTimeLeft()
        {
            if (IsAuthenticated() && ApiSettings.TokenExpiry.HasValue)
            {
                return ApiSettings.TokenExpiry.Value - DateTime.Now;
            }
            
            return TimeSpan.Zero;
        }
        
        /// <summary>
        /// Применяет токен авторизации к HTTP клиенту
        /// </summary>
        public static void ApplyTokenToClient(HttpClient client)
        {
            if (!string.IsNullOrEmpty(ApiSettings.AuthToken))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ApiSettings.AuthToken);
            }
        }
    }
} 