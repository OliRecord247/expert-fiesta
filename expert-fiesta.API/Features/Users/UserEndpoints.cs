using expert_fiesta.Application.Customers.CreateCustomer;
using MediatR;

namespace expert_fiesta.API.Features.Users;

public static class UserEndpoints
{
    public static void UseUserEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/users", async (CreateCustomerCommand command,
            IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            Guid customerId = await mediator.Send(command, cancellationToken);
            return Results.Created($"/api/customers/{customerId}", new { id = customerId });
        });
    }
}