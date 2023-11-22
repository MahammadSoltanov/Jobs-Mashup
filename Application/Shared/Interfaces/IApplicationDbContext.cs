using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Shared.Interfaces;

public interface IApplicationDbContext
{
    public DbSet<Company> Companies{ get; }
    public DbSet<Job> Jobs { get; }    
    public DbSet<Country> Countries{ get; }    
    

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
