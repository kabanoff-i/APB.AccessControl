using System;
using System.IO;
using System.Text.Json;

namespace APB.AccessControl.ClientApp.Config
{
    public class AppConfig
    {
        public string ApiUrl { get; set; }
        public int AccessPointId { get; set; }
        public string RedisConnectionString { get; set; }
        public string AccessPointName { get; set; }
        public bool IsConfigured { get; set; }
        public string Username { get; set; }
        public string AuthToken { get; set; }
        public DateTime? TokenExpiry { get; set; }

        private static readonly string ConfigPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "APB.AccessControl",
            "config.json"
        );

        public static AppConfig Load()
        {
            if (!File.Exists(ConfigPath))
            {
                return new AppConfig
                {
                    ApiUrl = "http://localhost:5000",
                    AccessPointId = 1,
                    RedisConnectionString = "localhost:6379"
                };
            }

            var json = File.ReadAllText(ConfigPath);
            return JsonSerializer.Deserialize<AppConfig>(json);
        }

        public void Save()
        {
            var directory = Path.GetDirectoryName(ConfigPath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            var json = JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(ConfigPath, json);
        }
    }
} 