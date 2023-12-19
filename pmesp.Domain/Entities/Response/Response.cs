namespace pmesp.Domain.Entities.Response;

public sealed class Response<T>
{
    public T Data { get; private set; }
    public string Message { get; private set; }
    public bool Success { get; private set; }
    public int StatusCode { get; private set; }

    public Response() { }
    public Response(T data, List<string> errors, string message, bool success)
    {
        Data = data;
        Message = message;
        Success = success;
    }

    public void setData(T data){ this.Data = data; }
    public T getData() { return this.Data; }
    public void setMessage(string message) {  this.Message = message; }
    public string getMessage() { return this.Message; }
    public void setSuccess(bool success) {  this.Success = success; }

    public void setResponse(T data, string message, bool success, int statusCode) 
    {
        Data = data;
        Message = message;
        Success = success;
        StatusCode = statusCode;
    }
}
