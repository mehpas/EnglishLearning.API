using MediatR;

namespace EnglishLearning.Application.Features.Kullanicilar.Commands.DeleteKullanici;

public record DeleteKullaniciCommand(int Id) : IRequest<Unit>;
