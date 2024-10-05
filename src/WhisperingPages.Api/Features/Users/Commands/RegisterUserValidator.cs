using FluentValidation;

namespace WhisperingPages.Api.Features.Users.Commands;

public class RegisterUserValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserValidator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Password).Matches("(?=^.{6,10}$)(?=.*\\\\d)(?=.*[a-z])(?=.*[A-Z])\" +\r\n\"(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\\\\s).*$");
        RuleFor(x => x.ConfirmPassword).Equal(x => x.Password).WithMessage("Passwords must match.");
    }
}
