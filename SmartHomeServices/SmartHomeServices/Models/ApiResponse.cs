namespace SmartHomeServices.Models
{
    public class ApiResponse<T>
    {
        /// <summary>
        /// 获取或设置响应的状态码，通常使用数字，200代表成功，其他代表不同类型的错误。
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// 获取或设置响应的状态，通常使用 "success" 或 "error"。
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// 获取或设置响应的信息，通常是操作结果的描述。
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 获取或设置返回的数据，泛型参数可以适应不同类型的返回数据。
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// 获取或设置错误代码，用于标识具体错误类型（可选）。
        /// </summary>
        public string ErrorCode { get; set; }

        public ApiResponse(int statusCode, string status, string message, T data = default, string errorCode = null)
        {
            StatusCode = statusCode;
            Status = status;
            Message = message;
            Data = data;
            ErrorCode = errorCode;
        }

        // 成功返回数据
        public static ApiResponse<T> Success(T data, string message = "Operation successful")
        {
            return new ApiResponse<T>(200, "success", message, data);
        }

        // 失败返回错误信息
        public static ApiResponse<T> Failure(string message, int statusCode = 400, string errorCode = null)
        {
            return new ApiResponse<T>(statusCode, "error", message, default, errorCode);
        }
    }

}
