using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace AgriTrack.Infrastructure;

public sealed class DbConnectionFactory
{
    private readonly string _connectionString;

    public DbConnectionFactory(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("AgriTrack")
            ?? throw new InvalidOperationException("Missing 'ConnectionStrings:AgriTrack' configuration.");
    }

    public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
}
