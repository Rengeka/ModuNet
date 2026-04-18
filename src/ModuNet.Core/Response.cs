using ModuNet.Core.Interfaces;

namespace ModuNet.Core
{
    /// <summary>
    /// Represents the result of an operation without a return value.
    /// </summary>
    /// <remarks>
    /// A successful response has a <c>null</c> <see cref="Error"/>.
    /// </remarks>
    public class Response : IResponse
    {
        /// <inheritdoc />
        public bool IsSuccessful => Error is null;

        /// <inheritdoc />
        public Error? Error { get; init; }

        /// <summary>
        /// Creates a successful response.
        /// </summary>
        public static Response Success() => new();

        /// <summary>
        /// Creates a failure response with <see cref="ErrorCode.NotFound"/>.
        /// </summary>
        /// <param name="message">An optional error message.</param>
        public static Response NotFound(string? message = null) =>
            Failure(ErrorCode.NotFound, message);

        /// <summary>
        /// Creates a failure response with <see cref="ErrorCode.ValidationError"/>.
        /// </summary>
        /// <param name="message">An optional error message.</param>
        public static Response ValidationError(string? message = null) =>
            new() { Error = new(ErrorCode.ValidationError, message) };

        /// <summary>
        /// Creates a failure response with the specified error code.
        /// </summary>
        /// <param name="code">The error code.</param>
        /// <param name="message">An optional error message.</param>
        public static Response Failure(ErrorCode code, string? message = null) =>
            new() { Error = new(code, message) };
    }

    /// <summary>
    /// Represents the result of an operation that returns a value.
    /// </summary>
    /// <typeparam name="T">The type of the result value.</typeparam>
    /// <remarks>
    /// Inherits from <see cref="Response"/> and adds a result value.
    /// The <see cref="Value"/> is expected to be non-null when the operation succeeds.
    /// </remarks>
    public class Response<T> : Response, IResponse<T>
    {
        /// <inheritdoc />
        public T? Value { get; init; }

        /// <summary>
        /// Creates a failure response with <see cref="ErrorCode.NotFound"/>.
        /// </summary>
        /// <param name="message">An optional error message.</param>
        public static new Response<T> NotFound(string? message = null) =>
            Failure(ErrorCode.NotFound, message);

        /// <summary>
        /// Creates a failure response with the specified error code.
        /// </summary>
        /// <param name="code">The error code.</param>
        /// <param name="message">An optional error message.</param>
        public static new Response<T> Failure(ErrorCode code, string? message = null) =>
            new() { Error = new(code, message) };
    }

    /// <summary>
    /// Provides extension methods for creating <see cref="IResponse{T}"/> instances.
    /// </summary>
    public static class ResponseExtensions
    {
        /// <summary>
        /// Wraps a value into a successful <see cref="IResponse{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <param name="value">The value to wrap.</param>
        /// <returns>A successful response containing the specified value.</returns>
        public static IResponse<T> Success<T>(this T value) =>
            new Response<T> { Value = value };
    }
}