using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

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

            return JsonConvert.SerializeObject(obj);
        }
    }
}
