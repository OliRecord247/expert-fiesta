using expert_fiesta.Domain;
using expert_fiesta.Infrastructure.Data.EntityMapping;
using Microsoft.EntityFrameworkCore;

namespace expert_fiesta.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    
    public DbSet<Game> Games => Set<Game>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new GameMapping());
    }
}