using System.Data;
using Dapper;

namespace AgriTrack.Infrastructure;

public sealed class DapperStoredProcRepository : IStoredProcRepository
{
    private readonly DbConnectionFactory _connectionFactory;

    public DapperStoredProcRepository(DbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<IEnumerable<T>> QueryAsync<T>(string storedProcedure, object? parameters = null)
    {
        using IDbConnection connection = _connectionFactory.CreateConnection();
        return await connection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task<T?> QuerySingleOrDefaultAsync<T>(string storedProcedure, object? parameters = null)
    {
        using IDbConnection connection = _connectionFactory.CreateConnection();
        return await connection.QuerySingleOrDefaultAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task ExecuteAsync(string storedProcedure, object? parameters = null)
    {
        using IDbConnection connection = _connectionFactory.CreateConnection();
        await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
    }
}
