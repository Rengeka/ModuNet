namespace ModuNet.Core.Interfaces;


public interface IResponse
{
    public bool IsSuccessful { get; }
    public Error? Error { get; }
}

public interface IResponse<out T> : IResponse
{
    public T? Value { get; }
}

public record Error(ErrorCode Code, string? Message);

public enum ErrorCode
{
    NotFound,
    Forbidden,
    ValidationError
}