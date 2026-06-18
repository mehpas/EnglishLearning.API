namespace EnglishLearning.Application.Common.Exceptions;

public class ValidationException : Exception
{
    public string ErrorCode { get; }
    public IDictionary<string, string[]> Errors { get; }

    public ValidationException(string message, IDictionary<string, string[]> errors, string errorCode)
        : base(message)
    {
        ErrorCode = errorCode;
        Errors = errors;
    }
}
