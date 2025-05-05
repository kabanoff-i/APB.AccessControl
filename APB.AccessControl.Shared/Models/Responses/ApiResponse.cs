namespace APB.AccessControl.Shared.Models.Responses
{
    /// <summary>
    /// Универсальный класс для передачи ответов API
    /// </summary>
    public class ApiResponse<T>
    {
        /// <summary>
        /// Данные ответа, если запрос успешен
        /// </summary>
        public T Data { get; set; }
        
        /// <summary>
        /// Информация об ошибке, если запрос неуспешен
        /// </summary>
        public ApiError Error { get; set; }
        
        /// <summary>
        /// Признак успешности запроса
        /// </summary>
        public bool IsSuccess { get; set; }
        
        /// <summary>
        /// Создает успешный ответ с данными
        /// </summary>
        public static ApiResponse<T> Success(T data)
        {
            return new ApiResponse<T>
            {
                Data = data,
                IsSuccess = true
            };
        }
        
        /// <summary>
        /// Создает ответ с ошибкой
        /// </summary>
        public static ApiResponse<T> Failure(ApiError error)
        {
            return new ApiResponse<T>
            {
                Error = error,
                IsSuccess = false
            };
        }
    }
    
    /// <summary>
    /// Модель для передачи информации об ошибке
    /// </summary>
    public class ApiError
    {
        /// <summary>
        /// Код ошибки
        /// </summary>
        public string Code { get; set; }
        
        /// <summary>
        /// Сообщение об ошибке
        /// </summary>
        public string Message { get; set; }
        
        /// <summary>
        /// Детальная информация об ошибке
        /// </summary>
        public string Details { get; set; }
    }
} 