using System.Globalization;

namespace EnglishLearning.Application.Common.Localization;

public static class MessageLocalizer
{
    public static string Get(string tr, string en)
    {
        return CultureInfo.CurrentUICulture.TwoLetterISOLanguageName == "en" ? en : tr;
    }

    public static string TranslateKey(string key)
    {
        return key switch
        {
            "validation.nameRequired" => Get("Isim alani zorunludur.", "Name is required."),
            "validation.nameMaxLength" => Get("Isim en fazla 100 karakter olabilir.", "Name cannot exceed 100 characters."),
            "validation.emailRequired" => Get("Email alani zorunludur.", "Email is required."),
            "validation.emailInvalid" => Get("Gecerli bir email adresi giriniz.", "Please enter a valid email address."),
            "validation.emailMaxLength" => Get("Email en fazla 150 karakter olabilir.", "Email cannot exceed 150 characters."),
            _ => key
        };
    }
}
