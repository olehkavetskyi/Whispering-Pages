using MediatR;
using Microsoft.AspNetCore.Identity;
using WhisperingPages.Api.Features.Users.Entities;
using WhisperingPages.Api.Features.Users.Services;

namespace WhisperingPages.Api.Features.Users.Commands;

public record RegisterUserCommand(string Email, string Password, string ConfirmPassword) : IRequest<RegisterUserResult>;

public record RegisterUserResult(string? Token, bool Success, string? ErrorMessage);


public class RegisterUserCommandHandler(
    UserManager<AppUser> userManager, 
    ITokenService tokenService) 
    : IRequestHandler<RegisterUserCommand, RegisterUserResult>
{
    public async Task<RegisterUserResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        if (request.Password != request.ConfirmPassword)
        {
            return new RegisterUserResult(null, false, "Passwords do not match.");
        }

        var user = new AppUser { UserName = request.Email, Email = request.Email };
        var result = await userManager.CreateAsync(user, request.Password);

        if (result.Succeeded)
        {

            return new RegisterUserResult(tokenService.GenerateJwtToken(user), true, null);
        }

        return new RegisterUserResult(null, true, string.Join(", ", result.Errors.Select(e => e.Description)));
    }
}