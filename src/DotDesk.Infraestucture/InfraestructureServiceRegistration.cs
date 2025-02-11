using DotDesk.Infraestucture.Repositories.Abstraction;
using DotDesk.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DotDesk.Application;

public static class InfraestructureServiceRegistration
{
    public static IServiceCollection AddInfraestructureRepositories(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddScoped<IChatRepository, MongoChatRepository>();
        return services;
    }
}