namespace expert_fiesta.Contracts.Responses;

public class GamesResponse
{
    public required IEnumerable<GameResponse> Items { get; init; } = Enumerable.Empty<GameResponse>();
}