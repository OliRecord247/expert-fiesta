using expert_fiesta.Application.Domain;

namespace expert_fiesta.Application.Repositories;

public interface IGameRepository
{
    Task<bool> CreateAsync(Game game, CancellationToken cancellationToken = default);
    Task<Game?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<Game>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<bool> UpdateAsync(Game game, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default);
}