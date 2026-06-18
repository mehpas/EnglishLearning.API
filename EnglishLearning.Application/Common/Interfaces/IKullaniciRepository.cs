using EnglishLearning.Domain.Entities;

namespace EnglishLearning.Application.Common.Interfaces;

public interface IKullaniciRepository
{
    Task<IReadOnlyList<Kullanici>> GetAllAsync(CancellationToken cancellationToken);
    Task<Kullanici?> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<int> CreateAsync(Kullanici kullanici, CancellationToken cancellationToken);
    Task<bool> UpdateAsync(Kullanici kullanici, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
}
