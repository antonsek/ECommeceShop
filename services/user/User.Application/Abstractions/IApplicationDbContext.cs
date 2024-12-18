using Microsoft.EntityFrameworkCore;

namespace User.Application.Abstractions;

public interface IApplicationDbContext
{
    DbSet<Domain.Entities.User> Users { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}