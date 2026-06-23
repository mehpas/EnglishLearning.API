using EnglishLearning.Application.Common.Localization;

namespace EnglishLearning.Application.Common.Messages;

public static class CommonMessages
{
    public static string ValidationFailed => MessageLocalizer.Get(
        "Gonderilen veriler gecerli degil.",
        "The submitted data is invalid.");

    public static string UnexpectedError => MessageLocalizer.Get(
        "Beklenmeyen bir hata olustu.",
        "An unexpected error occurred.");

    public static string DefaultSuccess => MessageLocalizer.Get(
        "Islem basarili.",
        "Operation completed successfully.");
}
