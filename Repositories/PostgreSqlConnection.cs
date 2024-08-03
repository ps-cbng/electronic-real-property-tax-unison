using Npgsql;
using System.Data;
using ElectronicRealPropertyTaxUnisan.Repositories.Interfaces;

namespace ElectronicRealPropertyTaxUnisan.Repositories;

public class PostgreSqlConnection : IDatabaseConnection
{
    private readonly string _connectionString;

    public PostgreSqlConnection(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("ElectronicRealPropertyTaxUnisan") ?? throw new InvalidOperationException("Connection string 'ElectronicRealPropertyTaxUnisan' not found.");
    }

    public IDbConnection CreateConnection()
    {
        return new NpgsqlConnection(_connectionString);
    }
}
