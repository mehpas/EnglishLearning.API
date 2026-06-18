using EnglishLearning.Application.Common.Exceptions;
using EnglishLearning.Application.Common.Interfaces;
using EnglishLearning.Application.Features.Kullanicilar.Constants;
using EnglishLearning.Application.Features.Kullanicilar.Dtos;
using EnglishLearning.Application.Features.Kullanicilar.Messages;
using EnglishLearning.Application.Features.Kullanicilar.Mappings;
using MediatR;

namespace EnglishLearning.Application.Features.Kullanicilar.Queries.GetKullaniciById;

public class GetKullaniciByIdQueryHandler : IRequestHandler<GetKullaniciByIdQuery, KullaniciDto>
{
    private readonly IKullaniciRepository _repository;

    public GetKullaniciByIdQueryHandler(IKullaniciRepository repository)
    {
        _repository = repository;
    }

    public async Task<KullaniciDto> Handle(GetKullaniciByIdQuery request, CancellationToken cancellationToken)
    {
        var kullanici = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (kullanici is null)
        {
            throw new NotFoundException(
                KullaniciMessages.NotFound(request.Id),
                KullaniciErrorCodes.Bulunamadi);
        }

        return kullanici.ToDto();
    }
}
