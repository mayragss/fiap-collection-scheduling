

namespace Presentation.Model
{
    public class ResponseModel<T>
    {
        public ResponseModel(T response)
        {
            Data = response;
            Success = true;
        }
        public ResponseModel(string message, T response, bool success)
        {
            Data = response;
            Message = message;
            Success = success;
        }
        public ResponseModel(string message, bool success)
        {
            Message = message;
            Success = success;
        }
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
