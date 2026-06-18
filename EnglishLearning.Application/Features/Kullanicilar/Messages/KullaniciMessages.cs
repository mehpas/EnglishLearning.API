namespace EnglishLearning.Application.Features.Kullanicilar.Messages;

public static class KullaniciMessages
{
    public const string Listed = "Kullanicilar basariyla getirildi.";
    public const string Retrieved = "Kullanici basariyla getirildi.";
    public const string Created = "Kullanici basariyla olusturuldu.";
    public const string Updated = "Kullanici basariyla guncellendi.";
    public const string Deleted = "Kullanici basariyla silindi.";

    public static string NotFound(int id) => $"{id} id'li kullanici bulunamadi.";
    public static string UpdateFailed(int id) => $"{id} id'li kullanici guncellenemedi.";
    public static string DeleteFailed(int id) => $"{id} id'li kullanici silinemedi.";
}
