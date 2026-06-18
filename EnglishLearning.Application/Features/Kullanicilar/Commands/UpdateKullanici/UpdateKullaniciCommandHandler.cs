using EnglishLearning.Application.Common.Exceptions;
using EnglishLearning.Application.Common.Interfaces;
using EnglishLearning.Application.Features.Kullanicilar.Constants;
using EnglishLearning.Application.Features.Kullanicilar.Messages;
using MediatR;

namespace EnglishLearning.Application.Features.Kullanicilar.Commands.UpdateKullanici;

public class UpdateKullaniciCommandHandler : IRequestHandler<UpdateKullaniciCommand, Unit>
{
    private readonly IKullaniciRepository _repository;

    public UpdateKullaniciCommandHandler(IKullaniciRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(UpdateKullaniciCommand request, CancellationToken cancellationToken)
    {
        var existing = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (existing is null)
        {
            throw new NotFoundException(
                KullaniciMessages.NotFound(request.Id),
                KullaniciErrorCodes.Bulunamadi);
        }

        existing.Isim = request.Dto.Isim;
        existing.Email = request.Dto.Email;

        var updated = await _repository.UpdateAsync(existing, cancellationToken);
        if (!updated)
        {
            throw new NotFoundException(
                KullaniciMessages.UpdateFailed(request.Id),
                KullaniciErrorCodes.Guncellenemedi);
        }

        return Unit.Value;
    }
}
