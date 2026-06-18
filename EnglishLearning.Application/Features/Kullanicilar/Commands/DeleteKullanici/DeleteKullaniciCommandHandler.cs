using EnglishLearning.Application.Common.Exceptions;
using EnglishLearning.Application.Common.Interfaces;
using EnglishLearning.Application.Features.Kullanicilar.Constants;
using EnglishLearning.Application.Features.Kullanicilar.Messages;
using MediatR;

namespace EnglishLearning.Application.Features.Kullanicilar.Commands.DeleteKullanici;

public class DeleteKullaniciCommandHandler : IRequestHandler<DeleteKullaniciCommand, Unit>
{
    private readonly IKullaniciRepository _repository;

    public DeleteKullaniciCommandHandler(IKullaniciRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(DeleteKullaniciCommand request, CancellationToken cancellationToken)
    {
        var existing = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (existing is null)
        {
            throw new NotFoundException(
                KullaniciMessages.NotFound(request.Id),
                KullaniciErrorCodes.Bulunamadi);
        }

        var deleted = await _repository.DeleteAsync(request.Id, cancellationToken);
        if (!deleted)
        {
            throw new NotFoundException(
                KullaniciMessages.DeleteFailed(request.Id),
                KullaniciErrorCodes.Silinemedi);
        }

        return Unit.Value;
    }
}
