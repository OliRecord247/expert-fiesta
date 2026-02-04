namespace expert_fiesta.Contracts.Responses;

public class GameResponse
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
    public int PlayHours { get; init; }
    public DateOnly ReleaseDate { get; init; }
}