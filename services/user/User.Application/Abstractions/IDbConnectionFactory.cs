using System.Data;

namespace User.Application.Abstractions;

public interface IDbConnectionFactory
{
    IDbConnection Create();
}