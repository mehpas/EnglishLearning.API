using System.ComponentModel.DataAnnotations;
using EnglishLearning.Application.Features.Kullanicilar.Messages;

namespace EnglishLearning.Application.Features.Kullanicilar.Dtos;

public class CreateKullaniciDto
{
    [Required(ErrorMessage = KullaniciValidationMessages.IsimRequired)]
    [MaxLength(100, ErrorMessage = KullaniciValidationMessages.IsimMaxLength)]
    public string Isim { get; set; } = string.Empty;

    [Required(ErrorMessage = KullaniciValidationMessages.EmailRequired)]
    [EmailAddress(ErrorMessage = KullaniciValidationMessages.EmailInvalid)]
    [MaxLength(150, ErrorMessage = KullaniciValidationMessages.EmailMaxLength)]
    public string Email { get; set; } = string.Empty;
}
