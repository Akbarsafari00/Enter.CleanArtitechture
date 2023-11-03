using ECA.Domain.AggregateModels.UserAggregates;
using ECA.Infrastructure.DataAccess.Configurations;
using Microsoft.EntityFrameworkCore;

namespace ECA.Infrastructure.DataAccess;

public class AppDbContext : DbContext
{

    public DbSet<User> Users { get; set; }
    
    public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
    }
}