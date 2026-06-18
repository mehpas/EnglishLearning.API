using Dapper;
using EnglishLearning.Application.Common.Interfaces;
using EnglishLearning.Domain.Entities;
using EnglishLearning.Infrastructure.Data;

namespace EnglishLearning.Infrastructure.Repositories;

public class KullaniciRepository : IKullaniciRepository
{
    private readonly NpgsqlConnectionFactory _connectionFactory;

    public KullaniciRepository(NpgsqlConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<IReadOnlyList<Kullanici>> GetAllAsync(CancellationToken cancellationToken)
    {
        const string sql = """
            SELECT id AS Id, isim AS Isim, email AS Email, kayit_tarihi AS KayitTarihi
            FROM kullanicilar
            ORDER BY id
            """;

        await using var connection = _connectionFactory.CreateConnection();
        var result = await connection.QueryAsync<Kullanici>(new CommandDefinition(sql, cancellationToken: cancellationToken));
        return result.ToList();
    }

    public async Task<Kullanici?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        const string sql = """
            SELECT id AS Id, isim AS Isim, email AS Email, kayit_tarihi AS KayitTarihi
            FROM kullanicilar
            WHERE id = @Id
            """;

        await using var connection = _connectionFactory.CreateConnection();
        return await connection.QuerySingleOrDefaultAsync<Kullanici>(
            new CommandDefinition(sql, new { Id = id }, cancellationToken: cancellationToken));
    }

    public async Task<int> CreateAsync(Kullanici kullanici, CancellationToken cancellationToken)
    {
        const string sql = """
            INSERT INTO kullanicilar (isim, email, kayit_tarihi)
            VALUES (@Isim, @Email, @KayitTarihi)
            RETURNING id
            """;

        await using var connection = _connectionFactory.CreateConnection();
        return await connection.ExecuteScalarAsync<int>(
            new CommandDefinition(sql, kullanici, cancellationToken: cancellationToken));
    }

    public async Task<bool> UpdateAsync(Kullanici kullanici, CancellationToken cancellationToken)
    {
        const string sql = """
            UPDATE kullanicilar
            SET isim = @Isim, email = @Email
            WHERE id = @Id
            """;

        await using var connection = _connectionFactory.CreateConnection();
        var affected = await connection.ExecuteAsync(
            new CommandDefinition(sql, kullanici, cancellationToken: cancellationToken));
        return affected > 0;
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        const string sql = "DELETE FROM kullanicilar WHERE id = @Id";

        await using var connection = _connectionFactory.CreateConnection();
        var affected = await connection.ExecuteAsync(
            new CommandDefinition(sql, new { Id = id }, cancellationToken: cancellationToken));
        return affected > 0;
    }
}
