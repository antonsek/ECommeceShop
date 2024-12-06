namespace User.Application.Abstractions;

public class IDbConnectionFactory
{
    IDbConnection Create();
}