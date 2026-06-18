using EnglishLearning.Application.Common.Interfaces;
using EnglishLearning.Application.Features.Kullanicilar.Mappings;
using MediatR;

namespace EnglishLearning.Application.Features.Kullanicilar.Commands.CreateKullanici;

public class CreateKullaniciCommandHandler : IRequestHandler<CreateKullaniciCommand, int>
{
    private readonly IKullaniciRepository _repository;

    public CreateKullaniciCommandHandler(IKullaniciRepository repository)
    {
        _repository = repository;
    }

    public async Task<int> Handle(CreateKullaniciCommand request, CancellationToken cancellationToken)
    {
        var entity = request.Dto.ToEntity();
        return await _repository.CreateAsync(entity, cancellationToken);
    }
}
