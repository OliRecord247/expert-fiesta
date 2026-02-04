namespace expert_fiesta.Application.Domain;

public class Game
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateOnly ReleaseDate { get; set; }
    public int PlayHours { get; set; }
}