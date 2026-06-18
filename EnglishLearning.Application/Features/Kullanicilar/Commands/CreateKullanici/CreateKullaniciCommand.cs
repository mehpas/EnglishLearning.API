using EnglishLearning.Application.Features.Kullanicilar.Dtos;
using MediatR;

namespace EnglishLearning.Application.Features.Kullanicilar.Commands.CreateKullanici;

public record CreateKullaniciCommand(CreateKullaniciDto Dto) : IRequest<int>;
