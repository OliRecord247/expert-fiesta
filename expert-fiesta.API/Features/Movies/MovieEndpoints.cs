namespace expert_fiesta.API.Features.Movies;

public static class MovieEndpoints
{
    public static void RegisterMovieEndpoints(this WebApplication app)
    {
        var _movieGroup = app.MapGroup("/movies");

        _movieGroup.MapGet("/", () =>
        {
            
        });
    }
}