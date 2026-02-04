using expert_fiesta.Application.Domain;
using expert_fiesta.Application.Repositories;

namespace expert_fiesta.Application.Services;

public class GameService : IGameService
{
    private readonly IGameRepository _gameRepository;
    
    public GameService(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }
    
    public Task<bool> CreateAsync(Game game, CancellationToken cancellationToken = default)
    {
        return _gameRepository.CreateAsync(game, cancellationToken);
    }

    public Task<Game?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return _gameRepository.GetByIdAsync(id, cancellationToken);
    }

    public Task<IEnumerable<Game>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return _gameRepository.GetAllAsync(cancellationToken);
    }

    public async Task<Game?> UpdateAsync(Game game, CancellationToken cancellationToken = default)
    {
        var gameExists = await _gameRepository.ExistsAsync(game.Id, cancellationToken);
        if (!gameExists) return null;
        
        await _gameRepository.UpdateAsync(game, cancellationToken);
        return game;
    }

    public Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return _gameRepository.DeleteAsync(id, cancellationToken);
    }
}