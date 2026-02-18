using expert_fiesta.Application.Data;
using expert_fiesta.Application.Domain;
using Microsoft.EntityFrameworkCore;

namespace expert_fiesta.Application.Repositories;

public class GameRepository : IGameRepository
{
    private readonly ApplicationDbContext _context;
    
    public GameRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<bool> CreateAsync(Game game, CancellationToken cancellationToken = default)
    {
        _context.Games.Add(game);

        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<Game?> GetByIdAsync(Guid id, CancellationToken token = default)
    {
        var game = await _context.Games.SingleOrDefaultAsync(g => g.Id == id, token);
        return game;
    }

    public async Task<IEnumerable<Game>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var games = await _context.Games.ToListAsync(cancellationToken);
        return games;
    }

    public async Task<bool> UpdateAsync(Game game, CancellationToken cancellationToken = default)
    {
        var exitingGame = await _context.Games.FindAsync([game.Id], cancellationToken);
        if (exitingGame is null) return false;
        
        exitingGame.Name = game.Name;
        exitingGame.Description = game.Description;
        exitingGame.ReleaseDate = game.ReleaseDate;
        exitingGame.PlayHours = game.PlayHours;
        
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var game = await _context.Games.FindAsync([id], cancellationToken);
        if (game is null) return false;
        
        _context.Games.Remove(game);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Games.AnyAsync(g => g.Id == id, cancellationToken);
    }
}