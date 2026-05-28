namespace expert_fiesta.Domain;

public class Customer
{
    public Guid Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public bool IsGamer { get; set; }
    public List<Address> Addresses { get; set; } = [];
}

public record Address(string Street, string HouseNumber, string City, string PostalCode);