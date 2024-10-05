using MediatR;
using Microsoft.AspNetCore.Identity;
using WhisperingPages.Api.Features.Users.Entities;
using WhisperingPages.Api.Features.Users.Services;

namespace WhisperingPages.Api.Features.Users.Commands;

public record LoginUserCommand(string Email, string Password) : IRequest<LoginUserResult>;

public record LoginUserResult(string? Token, bool Success, string? ErrorMessage);

public class LoginUserCommandHandler(
    UserManager<AppUser> userManager,
    SignInManager<AppUser> signInManager,
    ITokenService tokenService)
    : IRequestHandler<LoginUserCommand, LoginUserResult>
{
    public async Task<LoginUserResult> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByEmailAsync(request.Email);

        if (user == null)
        {
            return new LoginUserResult(default, false, "Invalid email or password.");
        }

        var result = await signInManager.CheckPasswordSignInAsync(user, request.Password, false);

        if (!result.Succeeded)
        {
            return new LoginUserResult(default, false, "Invalid email or password.");
        }

        var token = tokenService.GenerateJwtToken(user);

        return new LoginUserResult(token, true, default);
    }
}