using EnglishLearning.Application.Features.Kullanicilar.Dtos;
using EnglishLearning.Domain.Entities;

namespace EnglishLearning.Application.Features.Kullanicilar.Mappings;

public static class KullaniciMapper
{
    public static KullaniciDto ToDto(this Kullanici entity) => new()
    {
        Id = entity.Id,
        Isim = entity.Isim,
        Email = entity.Email,
        KayitTarihi = entity.KayitTarihi
    };

    public static Kullanici ToEntity(this CreateKullaniciDto dto) => new()
    {
        Isim = dto.Isim,
        Email = dto.Email,
        KayitTarihi = DateTime.UtcNow
    };
}
