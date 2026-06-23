using EnglishLearning.Application.Common.Localization;

namespace EnglishLearning.Application.Features.Kullanicilar.Messages;

public static class KullaniciMessages
{
    public static string Listed => MessageLocalizer.Get(
        "Kullanicilar basariyla getirildi.",
        "Users were retrieved successfully.");

    public static string Retrieved => MessageLocalizer.Get(
        "Kullanici basariyla getirildi.",
        "User was retrieved successfully.");

    public static string Created => MessageLocalizer.Get(
        "Kullanici basariyla olusturuldu.",
        "User was created successfully.");

    public static string Updated => MessageLocalizer.Get(
        "Kullanici basariyla guncellendi.",
        "User was updated successfully.");

    public static string Deleted => MessageLocalizer.Get(
        "Kullanici basariyla silindi.",
        "User was deleted successfully.");

    public static string NotFound(int id) => MessageLocalizer.Get(
        $"{id} id'li kullanici bulunamadi.",
        $"User with ID {id} was not found.");

    public static string UpdateFailed(int id) => MessageLocalizer.Get(
        $"{id} id'li kullanici guncellenemedi.",
        $"User with ID {id} could not be updated.");

    public static string DeleteFailed(int id) => MessageLocalizer.Get(
        $"{id} id'li kullanici silinemedi.",
        $"User with ID {id} could not be deleted.");
}
