namespace ModuNet.Core.Interfaces
{
    /// <summary>
    /// Represents the result of an operation without a return value.
    /// </summary>
    /// <remarks>
    /// Contains information about whether the operation was successful
    /// and, if not, details about the error.
    /// </remarks>
    public interface IResponse
    {
        /// <summary>
        /// Gets a value indicating whether the operation completed successfully.
        /// </summary>
        bool IsSuccessful { get; }

        /// <summary>
        /// Gets the error information if the operation failed; otherwise, <c>null</c>.
        /// </summary>
        Error? Error { get; }
    }

    /// <summary>
    /// Represents the result of an operation that returns a value.
    /// </summary>
    /// <typeparam name="T">The type of the result value.</typeparam>
    /// <remarks>
    /// Extends <see cref="IResponse"/> by including a value when the operation succeeds.
    /// </remarks>
    public interface IResponse<out T> : IResponse
    {
        /// <summary>
        /// Gets the result value if the operation was successful; otherwise, <c>null</c>.
        /// </summary>
        T? Value { get; }
    }

    /// <summary>
    /// Represents an error that occurred during an operation.
    /// </summary>
    /// <param name="Code">The error code categorizing the failure.</param>
    /// <param name="Message">An optional human-readable error message.</param>
    public record Error(ErrorCode Code, string? Message);

    /// <summary>
    /// Defines a set of standard error codes.
    /// </summary>
    public enum ErrorCode
    {
        /// <summary>
        /// The requested resource was not found.
        /// </summary>
        NotFound,

        /// <summary>
        /// The operation is not allowed for the current user or context.
        /// </summary>
        Forbidden,

        /// <summary>
        /// The request failed validation.
        /// </summary>
        ValidationError
    }
}