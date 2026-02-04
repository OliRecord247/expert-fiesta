using expert_fiesta.API.Mapping;
using expert_fiesta.Application.Services;
using expert_fiesta.Contracts.Requests;

namespace expert_fiesta.API.Features.Games;

public static class GameEndpoints
{
    public static void UseGameEndpoints(this WebApplication app)
    {
        var gameGroup = app.MapGroup("/games");
        var gameGroupWithValidators = gameGroup.MapGroup("/");
        
        gameGroupWithValidators
            .MapPost("/", async (CreateGameRequest request, IGameService gameService, CancellationToken token) =>
            {
                var game = request.MapToGame();
                await gameService.CreateAsync(game, token);
                return TypedResults.CreatedAtRoute(
                    routeName: "GetGameById",
                    routeValues: new { id = game.Id },
                    value: game
                );
            })
            .WithName("CreateGame");
        
        gameGroup
            .MapGet("/", async (IGameService service, CancellationToken token) =>
            {
                var games = await service.GetAllAsync(token);
                var gamesResponse = games.MapToResponse();
                return TypedResults.Ok(gamesResponse);
            })
            .WithName("GetAllGames");
        
        gameGroup
            .MapGet("/{id:guid}", async (Guid id, IGameService service, CancellationToken token) => 
            {
                var game = await service.GetByIdAsync(id, token);
                return game is null ? Results.NotFound() : TypedResults.Ok(game.MapToResponse());
            })
            .WithName("GetGameById");
        
        
        gameGroupWithValidators
            .MapPut("/{id:guid}", async (Guid id, UpdateGameRequest request,  IGameService service, CancellationToken token) =>
            {
                var game = request.MapToGame(id);
                var updatedGame = await service.UpdateAsync(game, token);
                if (updatedGame is null) return Results.NotFound();
                
                var response = updatedGame.MapToResponse();
                return TypedResults.Ok(response);
            })
            .WithName("UpdateGame");
        
        gameGroupWithValidators
            .MapDelete("/{id:guid}", async (Guid id, IGameService service, CancellationToken token) =>
            {
                var deleted = await service.DeleteAsync(id, token);
                return !deleted ? Results.NotFound() : Results.Ok();
            })
            .WithName("DeleteGame");
    }
}