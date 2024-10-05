using Microsoft.AspNetCore.Identity;

namespace WhisperingPages.Api.Features.Users;

public class AppRole : IdentityRole<Guid>
{
    public Roles Role { get; set; }
}
