using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace APB.AccessControl.Shared
{
    public static class Extensions
    {
        public static T DeserializeJson<T>(this string json)
        {
            if (string.IsNullOrEmpty(json))
                return default;

            return JsonConvert.DeserializeObject<T>(json);
        }

        public static string SerializeJson<T>(this T obj)
        {
            if (obj == null)
                return null;

            DefaultContractResolver contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            var settings = new JsonSerializerSettings
            {
                ContractResolver = contractResolver,
                Formatting = Formatting.Indented
            };

            return JsonConvert.SerializeObject(obj, settings);
        }
    }
}
