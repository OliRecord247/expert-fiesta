using expert_fiesta.Application.Customers.CreateCustomer;
using MediatR;

namespace expert_fiesta.API.Features.Customers;

public static class CustomerEndpoints
{
    public static void UseCustomerEndpoints(this IEndpointRouteBuilder app)
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