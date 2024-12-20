using System.Data;
using Microsoft.Extensions.Configuration;
using Npgsql;
using User.Application.Abstractions;

namespace User.Infrastructure;

public class DbConnectionFactory : IDbConnectionFactory
{
    private readonly string? _connectionString;
    
    public DbConnectionFactory(string connectionString)
    {
        _connectionString = connectionString;
    }
    
    public IDbConnection Create()
    {
        return new NpgsqlConnection(_connectionString);
    }
}