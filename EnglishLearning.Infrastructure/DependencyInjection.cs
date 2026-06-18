using EnglishLearning.Application.Common.Interfaces;
using EnglishLearning.Infrastructure.Data;
using EnglishLearning.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace EnglishLearning.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<NpgsqlConnectionFactory>();
        services.AddScoped<IKullaniciRepository, KullaniciRepository>();
        return services;
    }
}
