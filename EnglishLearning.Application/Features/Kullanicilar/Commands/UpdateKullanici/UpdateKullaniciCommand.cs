using MediatR;

namespace EnglishLearning.Application.Features.Kullanicilar.Commands.UpdateKullanici;

public record UpdateKullaniciCommand(int Id, Dtos.UpdateKullaniciDto Dto) : IRequest<Unit>;
