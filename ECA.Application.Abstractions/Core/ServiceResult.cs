namespace ECA.Application.Core;

public class ServiceResult <TResult>
{
    public ServiceResult(bool isSuccess, string message)
    {
        IsSuccess = isSuccess;
        Message = message;
        Result = default;
    }
    
    public ServiceResult(TResult? result)
    {
        Result = result;
        IsSuccess = true;
    }

    public bool IsSuccess { get; set; } = false;
    public string Message { get; set; } = string.Empty;
    public TResult? Result { get; set; } = default!;
}