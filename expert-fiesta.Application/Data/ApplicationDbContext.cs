using expert_fiesta.Application.Data.EntityMapping;
using expert_fiesta.Application.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace expert_fiesta.Application.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    
    public DbSet<Game> Games => Set<Game>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new GameMapping());

        modelBuilder.Entity<ApplicationUser>(entity =>
        {
            entity.Property(e => e.EnableNotifcations).HasDefaultValue(true);
            entity.Property(e => e.Initials).HasMaxLength(5);
        });
    }
}