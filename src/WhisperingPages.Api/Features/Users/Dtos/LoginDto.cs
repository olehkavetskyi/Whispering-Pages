using System.ComponentModel.DataAnnotations;

namespace WhisperingPages.Api.Features.Users.Dtos;

public class LoginDto
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}
