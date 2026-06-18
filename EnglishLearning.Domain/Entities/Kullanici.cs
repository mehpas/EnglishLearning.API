namespace EnglishLearning.Domain.Entities;

public class Kullanici
{
    public int Id { get; set; }
    public string Isim { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime KayitTarihi { get; set; }
}
