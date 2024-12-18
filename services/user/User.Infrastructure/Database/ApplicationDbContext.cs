using Microsoft.EntityFrameworkCore;
using User.Application.Abstractions;

namespace User.Infrastructure;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    
    public DbSet<Domain.Entities.User> Users { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }
    
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
        await base.SaveChangesAsync(cancellationToken);
}