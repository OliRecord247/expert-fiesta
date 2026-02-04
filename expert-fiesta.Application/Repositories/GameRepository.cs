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
        _context.Games.Update(game);
        var result = await _context.SaveChangesAsync(cancellationToken);
        return result > 0;
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        _context.Games.Remove(new Game { Id = id });
        var result =await _context.SaveChangesAsync(cancellationToken);
        return result > 0;
    }

    public async Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Games.AnyAsync(g => g.Id == id, cancellationToken);
    }
}