using System.Globalization;
using expert_fiesta.Application.Domain;
using expert_fiesta.Contracts.Requests;
using expert_fiesta.Contracts.Responses;

namespace expert_fiesta.API.Mapping;

public static class ContractMapping
{
    private const string DateFormat = "yyyy-MM-dd";
    
    public static Game MapToGame(this CreateGameRequest request)
    {
        DateOnly.TryParse(request.ReleaseDate, CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsedDate);
        return new Game
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description,
            ReleaseDate = parsedDate == default ? null : parsedDate,
            PlayHours = request.PlayHours
        };
    }
    
    public static Game MapToGame(this UpdateGameRequest request, Guid id)
    {
        return new Game
        {
            Id = id,
            Name = request.Name,
            Description = request.Description,
            ReleaseDate = request.ReleaseDate,
            PlayHours = request.PlayHours
        };
    }

    public static GameResponse MapToResponse(this Game game)
    {
        return new GameResponse
        {
            Id = game.Id,
            Name = game.Name,
            Description = game.Description,
            PlayHours = game.PlayHours,
            ReleaseDate = game.ReleaseDate?.ToString(DateFormat, CultureInfo.InvariantCulture) 
                          ?? string.Empty,
        };
    }

    public static GamesResponse MapToResponse(this IEnumerable<Game> games)
    {
        return new GamesResponse
        {
            Items = games.Select(MapToResponse)
        };
    }
}