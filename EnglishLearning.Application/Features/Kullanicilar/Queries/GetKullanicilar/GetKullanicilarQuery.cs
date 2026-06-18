using EnglishLearning.Application.Features.Kullanicilar.Dtos;
using MediatR;

namespace EnglishLearning.Application.Features.Kullanicilar.Queries.GetKullanicilar;

public record GetKullanicilarQuery : IRequest<IReadOnlyList<KullaniciDto>>;
