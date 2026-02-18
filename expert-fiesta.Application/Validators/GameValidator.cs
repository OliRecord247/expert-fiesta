using expert_fiesta.Application.Domain;
using FluentValidation;

namespace expert_fiesta.Application.Validators;

public class GameValidator : AbstractValidator<Game>
{
    public GameValidator()
    {
        RuleFor(game => game.Id)
            .NotEmpty();

        RuleFor(game => game.Name)
            .NotEmpty();
            
        RuleFor(game => game.Description)
            .NotEmpty();
            
        RuleFor(game => game.ReleaseDate)
            .LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.UtcNow))
            .WithMessage("Release date cannot be in the future.")
            .When(game => game.ReleaseDate.HasValue);
        
        RuleFor(game => game.PlayHours)
            .GreaterThanOrEqualTo(2);
    }
}