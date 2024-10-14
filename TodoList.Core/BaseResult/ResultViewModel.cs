using Microsoft.Extensions.Configuration;

namespace TodoList.Core.BaseResult
{
    public class ResultViewModel
    {
        IConfiguration _conf;
        public ResultViewModel(bool isSuccess = true, string message = "")
        {
            IsSuccess = isSuccess;
            Message = message;
        }
        public bool IsSuccess { get;}
        public string Message { get; } = string.Empty;
        public static ResultViewModel Success(string message) => new ResultViewModel(message: message);
        public static ResultViewModel Failure(string message) => new ResultViewModel(false,message);

    }

    public class ResultViewModel<T> : ResultViewModel  
    {
        public ResultViewModel(T? data = default, bool isSuccess = true, string message = "") 
        : base(isSuccess, message)
        {
            Data = data;
        }
        public T? Data { get; }

        public static ResultViewModel<T> Success(T? data, string message)
         => new ResultViewModel<T>(data, true, message);
        public static ResultViewModel<T> Failure(T? data, string message)
        => new ResultViewModel<T>(data, false, message);

    }
}
