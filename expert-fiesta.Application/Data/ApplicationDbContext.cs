using expert_fiesta.Application.Data.EntityMapping;
using expert_fiesta.Application.Domain;
using Microsoft.EntityFrameworkCore;

namespace expert_fiesta.Application.Data;

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