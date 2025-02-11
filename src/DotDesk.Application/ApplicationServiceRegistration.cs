using DotDesk.Application.Services;
using DotDesk.Application.Services.Abstraction;
using Microsoft.Extensions.DependencyInjection;

namespace DotDesk.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IChatService, ChatService>();
        services.AddScoped<IDotDeskClientService, DotDeskClientService>();
        return services;
    }
}