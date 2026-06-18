using EnglishLearning.Application.Features.Kullanicilar.Dtos;
using MediatR;

namespace EnglishLearning.Application.Features.Kullanicilar.Queries.GetKullaniciById;

public record GetKullaniciByIdQuery(int Id) : IRequest<KullaniciDto>;
