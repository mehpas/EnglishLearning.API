using EnglishLearning.Application.Common.Interfaces;
using EnglishLearning.Application.Features.Kullanicilar.Dtos;
using EnglishLearning.Application.Features.Kullanicilar.Mappings;
using MediatR;

namespace EnglishLearning.Application.Features.Kullanicilar.Queries.GetKullanicilar;

public class GetKullanicilarQueryHandler : IRequestHandler<GetKullanicilarQuery, IReadOnlyList<KullaniciDto>>
{
    private readonly IKullaniciRepository _repository;

    public GetKullanicilarQueryHandler(IKullaniciRepository repository)
    {
        _repository = repository;
    }

    public async Task<IReadOnlyList<KullaniciDto>> Handle(GetKullanicilarQuery request, CancellationToken cancellationToken)
    {
        var kullanicilar = await _repository.GetAllAsync(cancellationToken);
        return kullanicilar.Select(k => k.ToDto()).ToList();
    }
}
