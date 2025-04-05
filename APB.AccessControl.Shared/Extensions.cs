using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections;
using System;
using System.Linq;

namespace APB.AccessControl.Shared
{
    public static class Extensions
    {
        public class BitArrayConverter : JsonConverter<BitArray>
        {
            public override BitArray ReadJson(JsonReader reader, Type objectType, BitArray existingValue, bool hasExistingValue, JsonSerializer serializer)
            {
                var bools = serializer.Deserialize<bool[]>(reader);
                return bools == null ? null : new BitArray(bools);
            }

            public override void WriteJson(JsonWriter writer, BitArray value, JsonSerializer serializer)
            {
                serializer.Serialize(writer, value.Cast<bool>());
            }
        }
        public static T DeserializeJson<T>(this string json)
        {
            if (string.IsNullOrEmpty(json))
                return default;

            var settings = new JsonSerializerSettings
            {
                Converters = { new BitArrayConverter() }
            };

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
