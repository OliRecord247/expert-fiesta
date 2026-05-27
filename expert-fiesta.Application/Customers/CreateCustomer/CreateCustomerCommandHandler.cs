using expert_fiesta.Domain;
using expert_fiesta.Domain.IRepositories;
using MediatR;

namespace expert_fiesta.Application.Customers.CreateCustomer;

public record CreateCustomerCommand(string FirstName, string LastName, string Email) : IRequest<Guid>;

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Guid>
{
    private readonly ICustomerRepository _repository;

    public CreateCustomerCommandHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<Guid> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var emailExists = await _repository.ExistsByEmailAsync(request.Email, cancellationToken);
        if (emailExists)
        {
            throw new Exception($"Een klant met het e-mailadres {request.Email} bestaat al.");
        }
        
        var customer = new Customer
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
        };

        await _repository.AddAsync(customer, cancellationToken);
        return customer.Id;
    }
}