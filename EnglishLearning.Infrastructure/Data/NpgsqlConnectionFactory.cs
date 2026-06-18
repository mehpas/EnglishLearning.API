using Microsoft.Extensions.Configuration;

namespace EnglishLearning.Infrastructure.Data;

public class NpgsqlConnectionFactory
{
    private readonly string _connectionString;

    public NpgsqlConnectionFactory(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException("DefaultConnection bulunamadi.");
    }

    public Npgsql.NpgsqlConnection CreateConnection() => new(_connectionString);
}
