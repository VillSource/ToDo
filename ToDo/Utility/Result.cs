using Microsoft.AspNetCore.Http.HttpResults;

namespace ToDo.Utility;

public class Result : Result<object> { }
public class Result<T>
{
    public bool IsSuccess { get; set; }
    public string? Message { get; set; }
    public ResultStatus Status { get; set; }
    public T? Value { get; set; }

    public static Result<T> Unviable(string? message=default)
    {
        return new()
        {
            IsSuccess = true,
            Status = ResultStatus.Unviable,
            Message = message ?? ResultStatus.Unviable.ToString(),
        };
    }

    public static Result<T> Success(string? message=default)
    {
        return new()
        {
            IsSuccess = true,
            Status = ResultStatus.Success,
            Message = message ?? ResultStatus.Success.ToString(),
        };
    }

    public static Result<T> NotFound(string? message=default)
    {
        return new()
        {
            IsSuccess = false,
            Status = ResultStatus.NotFound,
            Message = message ?? ResultStatus.NotFound.ToString(),
        };
    }

    public static implicit operator Result<T>(T value)
    {
        return new Result<T>
        {
            IsSuccess = true,
            Status = ResultStatus.Success,
            Message = ResultStatus.Success.ToString(),
            Value = value
        };
    }

    public static implicit operator Result<T>(Result<object> result)
    {
        return new Result<T>
        {
            IsSuccess = result.IsSuccess,
            Status = result.Status,
            Message = result.Message,
            Value = default
        };
    }

}

public enum ResultStatus
{
    Success,
    NotFound,
    Unviable,
    Fail
}
