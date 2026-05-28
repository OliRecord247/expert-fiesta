namespace expert_fiesta.Domain.Exceptions;

public class EmailAlreadyExistsException : Exception
{
    public EmailAlreadyExistsException(string email) 
        : base($"Een klant met het e-mailadres '{email}' bestaat al.") {}
}