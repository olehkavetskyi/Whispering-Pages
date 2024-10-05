using WhisperingPages.Api.Features.Users.Entities;

namespace WhisperingPages.Api.Features.Users.Services;

public interface ITokenService
{
    string GenerateJwtToken(AppUser user);
}
