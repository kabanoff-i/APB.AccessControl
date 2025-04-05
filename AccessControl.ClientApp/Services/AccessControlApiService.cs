using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using APB.AccessControl.Shared.Models.Requests;
using APB.AccessControl.Shared.Models.Responses;
using APB.AccessControl.Shared.Models;
using APB.AccessControl.Shared.Models.Common;

namespace AccessControl.ClientApp.Services
{
    public class AccessControlApiService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "http://localhost:5000";

        public AccessControlApiService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(BaseUrl)
            };
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<Result<AccessCheckResponse>> CheckAccessAsync(string cardHash, int accessPointId)
        {
            try
            {
                var request = new CheckAccessReq
                {
                    CardHash = cardHash,
                    AcсessPointId = accessPointId,
                    DateAccess = DateTime.UtcNow
                };
                
                var response = await _httpClient.PostAsJsonAsync("/api/accesscheck/check", request);
                
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<Result<AccessCheckResponse>>() 
                        ?? Result.Failure<AccessCheckResponse>(new Error("Ошибка обращения к серверу"));
                }
                
                return Result.Failure<AccessCheckResponse>(new Error("Ошибка обращения к серверу"));
            }
            catch (Exception ex)
            {
                return Result.Failure<AccessCheckResponse>(new Error($"Ошибка связи с сервером: {ex.Message}"));
            }
        }
    }
} 