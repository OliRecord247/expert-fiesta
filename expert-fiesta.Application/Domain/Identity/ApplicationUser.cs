using Microsoft.AspNetCore.Identity;

namespace expert_fiesta.Application.Domain;

public sealed class ApplicationUser : IdentityUser
{
    public bool EnableNotifcations { get; set; }
    public string Initials { get; set; } = string.Empty;
}