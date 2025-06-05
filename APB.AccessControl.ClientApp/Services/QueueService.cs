using System;
using System.Text.Json;
using System.Threading.Tasks;
using StackExchange.Redis;
using APB.AccessControl.Shared.Models.DTOs;
using APB.AccessControl.Shared.Models.Requests;

namespace APB.AccessControl.ClientApp.Services
{
    public class QueueService
    {
        private readonly ConnectionMultiplexer _redis;
        private const string QueueKey = "access_checks_queue";

        public QueueService(string connectionString)
        {
            _redis = ConnectionMultiplexer.Connect(connectionString);
        }

        public async Task EnqueueAccessCheckAsync(CreateAccessLogReq check)
        {
            var db = _redis.GetDatabase();
            var json = JsonSerializer.Serialize(check);
            await db.ListRightPushAsync(QueueKey, json);
        }

        public async Task<CreateAccessLogReq> DequeueAccessCheckAsync()
        {
            var db = _redis.GetDatabase();
            var json = await db.ListLeftPopAsync(QueueKey);
            
            if (json.IsNull)
            {
                return null;
            }

            return JsonSerializer.Deserialize<CreateAccessLogReq>(json);
        }

        public async Task<long> GetQueueLengthAsync()
        {
            var db = _redis.GetDatabase();
            return await db.ListLengthAsync(QueueKey);
        }
    }
} 