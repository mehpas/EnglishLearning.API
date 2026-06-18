namespace EnglishLearning.Application.Common.Models;

public class ApiErrorResponse
{
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
    public string ErrorCode { get; set; } = string.Empty;
    public IDictionary<string, string[]>? Errors { get; set; }
}
