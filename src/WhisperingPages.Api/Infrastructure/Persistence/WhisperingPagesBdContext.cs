using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WhisperingPages.Api.Features.Users.Entities;

namespace WhisperingPages.Api.Infrastructure.Persistence;

public class WhisperingPagesBdContext : IdentityDbContext<AppUser, AppRole, Guid>
{
    public WhisperingPagesBdContext()
    {
    }

    public WhisperingPagesBdContext(DbContextOptions options) : base(options)
    {
    }
}
