using expert_fiesta.Domain;
using expert_fiesta.Domain.IRepositories;
using Marten;

namespace expert_fiesta.Infrastructure.Repositories;

public class CustomerDocumentRepository : ICustomerRepository
{
    private readonly IDocumentSession _session;
    
    public CustomerDocumentRepository(IDocumentSession session)
    {
        _session = session;
    }
    
    public async Task AddAsync(Customer customer, CancellationToken cancellationToken = default)
    {
        _session.Store(customer);
        await _session.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> ExistsByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        return await _session.Query<Customer>()
            .AnyAsync(c => c.Email == email, cancellationToken);
    }
}