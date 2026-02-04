namespace expert_fiesta.Contracts.Requests;

public record struct CreateGameRequest
{
    public string Name { get; init; }
    public string Description { get; init; }
    public DateOnly ReleaseDate { get; init; }
    public int PlayHours { get; init; }
}