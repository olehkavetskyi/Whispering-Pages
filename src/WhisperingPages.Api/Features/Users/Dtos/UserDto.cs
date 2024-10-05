namespace WhisperingPages.Api.Features.Users.Dtos;

public class UserDto
{
    public string Email { get; set; } = null!;
    public string Token { get; set; } = null!;
    public string RefreshToken { get; set; } = null!;
}
