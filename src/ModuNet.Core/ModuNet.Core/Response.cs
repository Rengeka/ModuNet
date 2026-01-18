using ModuNet.Core.Interfaces;

namespace ModuNet.Core;

public class Response : IResponse
{
    public bool IsSuccessful => Error is null;

    public Error? Error { get; init; }

    public static Response Success() => new();

    public static Response NotFound(string? message = null) => Failure(ErrorCode.NotFound, message);

    public static Response ValidationError(string? message = null) => new() { Error = new(ErrorCode.ValidationError, message) };

    public static Response Failure(ErrorCode code, string? message = null) => new() { Error = new(code, message) };
}

public class Response<T> : Response, IResponse<T>
{
    public T? Value { get; init; }

    public static new Response<T> NotFound(string? message = null) => Failure(ErrorCode.NotFound, message);

    public static new Response<T> Failure(ErrorCode code, string? message = null) => new() { Error = new(code, message) };
}

public static class ResponseExtensions
{
    public static IResponse<T> Success<T>(this T value) => new Response<T>() { Value = value };
}