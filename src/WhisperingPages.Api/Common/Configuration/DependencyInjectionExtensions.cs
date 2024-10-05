using Microsoft.EntityFrameworkCore;
using WhisperingPages.Api.Features.Users.Services;
using WhisperingPages.Api.Infrastructure.Persistence;

namespace WhisperingPages.Api.Common.Configuration;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddDb(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<WhisperingPagesBdContext>(options =>
        {
            options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        });

        return services;
    }

    public static IServiceCollection AddDependencies(this IServiceCollection services)
    {
        services.AddScoped<ITokenService, TokenService>();

        services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(Program).Assembly));

        return services;
    }
}
