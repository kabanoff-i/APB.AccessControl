using System;

namespace APB.AccessControl.Application.Common
{
    internal static class ValidationMessage
    {
        public static Func<string, string> NotNull { get; set; } =
            (propertyName) => $"Свойство {propertyName} не может быть NULL";
        public static Func<string, string> NotEmpty { get; set; } =
            (propertyName) => $"Свойство {propertyName} не может быть пустым";
        public static Func<string, string> InvalidProperty { get; set; } =
            (propertyName) => $"Свойство {propertyName} имеет недопустимое значение";
    }
}
