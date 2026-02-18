using expert_fiesta.Application.Domain;
using expert_fiesta.Application.Repositories;
using FluentValidation;

namespace expert_fiesta.Application.Services;

public class GameService : IGameService
{
    private readonly IGameRepository _gameRepository;
    private readonly IValidator<Game> _validator;
    
    public GameService(IGameRepository gameRepository, IValidator<Game> validator)
    {
        _gameRepository = gameRepository;
        _validator = validator;
    }
    
    public async Task<bool> CreateAsync(Game game, CancellationToken cancellationToken = default)
    {
        await _validator.ValidateAndThrowAsync(game, cancellationToken);
        return await _gameRepository.CreateAsync(game, cancellationToken);
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
        await _validator.ValidateAndThrowAsync(game, cancellationToken);
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